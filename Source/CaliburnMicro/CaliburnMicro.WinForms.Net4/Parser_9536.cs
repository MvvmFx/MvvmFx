using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using MvvmFx.Windows.Data;
using Binding = MvvmFx.Windows.Data.Binding;
#if WEBGUI
using Gizmox.WebGUI.Forms;
using FrameworkElement = Gizmox.WebGUI.Forms.Control;
#else
using System.Windows.Forms;
using FrameworkElement = System.Windows.Forms.Control;
#endif

namespace MvvmFx.CaliburnMicro
{
    /// <summary>
    /// Parses text into a fully functional set of <see cref="MessageDetail"/> instances for use by <see cref="ActionMessage"/>.
    /// </summary>
    public static class Parser
    {
        private static readonly Regex LongFormatRegularExpression =
            new Regex(@"^[\s]*\[[^\]]*\][\s]*=[\s]*\[[^\]]*\][\s]*$");

        private static IEnumerable<Control> _namedElements;

        /// <summary>
        /// Parses the specified message text.
        /// </summary>
        /// <param name="target">The event trigger control.</param>
        /// <param name="text">The message text.</param>
        /// <param name="namedElements">All the <see cref="Control"/> instances with names in the scope.</param>
        /// <returns>
        /// The message details parsed from the text.
        /// </returns>
        public static IEnumerable<MessageDetail> Parse(Control target, string text, IEnumerable<Control> namedElements)
        {
            _namedElements = namedElements;
            var messageDetails = new List<MessageDetail>();
            var messageTexts = Split(text, ';');

            foreach (var messageText in messageTexts)
            {
                var triggerPlusMessage = LongFormatRegularExpression.IsMatch(messageText)
                    ? Split(messageText, '=')
                    : new[] {null, messageText};

                var messageDetail = CreateMessageDetail(target, triggerPlusMessage.Last()
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty)
                    .Trim());

                messageDetail.EventName = GetTriggerEventName(target,
                    triggerPlusMessage.Length == 1 ? null : triggerPlusMessage[0]);

                messageDetails.Add(messageDetail);
            }

            return messageDetails;
        }

        /// <summary>
        /// The function used to get the trigger event name.
        /// </summary>
        /// <remarks>The parameters passed to the method are the the trigger control and string representing the trigger event.</remarks>
        public static Func<Control, string, string> GetTriggerEventName = (control, triggerText) =>
        {
            // if no event is specified, use the conventional event
            if (triggerText == null)
            {
                var defaults = ConventionManager.GetElementConvention(control.GetType());
                return defaults.EventName;
            }

            var triggerDetail = triggerText
                .Replace("[", string.Empty)
                .Replace("]", string.Empty)
                .Replace("Event", string.Empty)
                .Trim();

            return triggerDetail;
        };

        /// <summary>
        /// Creates an instance of <see cref="MessageDetail"/> by parsing out the textual dsl.
        /// </summary>
        /// <param name="target">The target of the message.</param>
        /// <param name="messageText">The textual message dsl.</param>
        /// <returns>The created message detail.</returns>
        public static MessageDetail CreateMessageDetail(Control target, string messageText)
        {
            var openingParenthesisIndex = messageText.IndexOf('(');
            if (openingParenthesisIndex < 0)
            {
                openingParenthesisIndex = messageText.Length;
            }

            var closingParenthesisIndex = messageText.LastIndexOf(')');
            if (closingParenthesisIndex < 0)
            {
                closingParenthesisIndex = messageText.Length;
            }

            var core = messageText.Substring(0, openingParenthesisIndex).Trim();
            var message = InterpretMessageText(core);

            if (closingParenthesisIndex - openingParenthesisIndex > 1)
            {
                var paramString = messageText.Substring(openingParenthesisIndex + 1,
                    closingParenthesisIndex - openingParenthesisIndex - 1);
                var parameters = SplitParameters(paramString);

                foreach (var parameter in parameters)
                    message.Parameters.Add(CreateParameter(target, parameter.Trim()));
            }

            return message;
        }

        /// <summary>
        /// Function used to parse a string identified as a message.
        /// </summary>
        public static Func<string, MessageDetail> InterpretMessageText =
            text => { return new MessageDetail {MethodName = Regex.Replace(text, "^Action", string.Empty).Trim()}; };

        internal static List<string> SplitParameter(string parameterText)
        {
            var nameAndBindingMode = parameterText.Split(':').Select(x => x.Trim()).ToArray();
            var index = nameAndBindingMode[0].IndexOf('.');

            var parameterMembers = new List<string>();
            parameterMembers.Add(index == -1 ? nameAndBindingMode[0] : nameAndBindingMode[0].Substring(0, index));
            parameterMembers.Add(index == -1 ? null : nameAndBindingMode[0].Substring(index + 1));
            parameterMembers.Add(nameAndBindingMode.Length == 2
                ? (string) Enum.Parse(typeof (BindingMode), nameAndBindingMode[1], true)
                : "OneWayToTarget");

            return parameterMembers;
        }

        /// <summary>
        /// Function used to parse a string identified as a message parameter.
        /// </summary>
        public static Func<Control, string, Parameter> CreateParameter = (target, parameterText) =>
        {
            var actualParameter = new Parameter();
            var parameterMembers = SplitParameter(parameterText);

            if (parameterText.StartsWith("'") && parameterText.EndsWith("'"))
            {
                actualParameter.Value = parameterText.Substring(1, parameterText.Length - 2);
            }
            else if (MessageBinder.SpecialValues.ContainsKey(parameterMembers[0].ToLower()) ||
                     char.IsNumber(parameterText[0]))
            {
                actualParameter.Value = parameterText;
                actualParameter.MustEvaluate = true;
            }
            else
            {
                if (parameterMembers[0] == "$this")
                {
                    actualParameter.Value = target;
                    //View.ExecuteOnLoad(target, delegate
                    //{
                    BindParameter(
                        target,
                        actualParameter,
                        target,
                        parameterMembers[1],
                        (BindingMode) Enum.Parse(typeof (BindingMode), parameterMembers[2])
                        );
                    //});
                }
                else
                {
                    //View.ExecuteOnLoad(target, delegate
                    //{
                    BindParameter(
                        target,
                        actualParameter,
                        parameterMembers[0],
                        parameterMembers[1],
                        (BindingMode) Enum.Parse(typeof (BindingMode), parameterMembers[2])
                        );
                    //});
                }
            }

            return actualParameter;
        };

        /// <summary>
        /// Creates a binding on a <see cref="Parameter" />.
        /// </summary>
        /// <param name="target">The target to which the message is applied.</param>
        /// <param name="parameter">The parameter object.</param>
        /// <param name="controlName">The name of the control to bind to.</param>
        /// <param name="propertyName">The name of the property to bind to.</param>
        /// <param name="bindingMode">The binding mode to use.</param>
        public static void BindParameter(FrameworkElement target, Parameter parameter, string controlName,
            string propertyName, BindingMode bindingMode)
        {
            var control = _namedElements.FindName(controlName);
            if (control == null)
                return;

            BindParameter(target, parameter, control, propertyName, bindingMode);
        }

        /// <summary>
        /// Creates a binding on a <see cref="Parameter" />.
        /// </summary>
        /// <param name="target">The target to which the message is applied.</param>
        /// <param name="parameter">The parameter object.</param>
        /// <param name="control">The actual control to bind to.</param>
        /// <param name="propertyName">The name of the property to bind to.</param>
        /// <param name="bindingMode">The binding mode to use.</param>
        public static void BindParameter(FrameworkElement target, Parameter parameter, FrameworkElement control,
            string propertyName, BindingMode bindingMode)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                propertyName = ConventionManager.GetElementConvention(control.GetType()).ParameterProperty;
            }

            if (!string.IsNullOrEmpty(propertyName))
            {
                var binding = new Binding()
                {
                    SourceObject = control,
                    SourcePath = propertyName,
                    TargetObject = parameter,
                    TargetPath = "Value",
                    Mode = bindingMode
                };

                parameter.BindingManager.Bindings.Add(binding);
            }
        }

        private static string[] Split(string message, char separator)
        {
            //Splits a string using the specified separator, if it is found outside of relevant places
            //delimited by [ and ]
            string str;
            var list = new List<string>();
            var builder = new StringBuilder();

            int squareBrackets = 0;

            foreach (var current in message)
            {
                //Square brackets are used as delimiters, so only separators outside them count...
                if (current == '[')
                {
                    squareBrackets++;
                }
                else if (current == ']')
                {
                    squareBrackets--;
                }
                else if (current == separator)
                {
                    if (squareBrackets == 0)
                    {
                        str = builder.ToString();
                        if (!string.IsNullOrEmpty(str))
                            list.Add(builder.ToString());
                        builder.Length = 0;
                        continue;
                    }
                }

                builder.Append(current);
            }

            str = builder.ToString();
            if (!string.IsNullOrEmpty(str))
            {
                list.Add(builder.ToString());
            }

            return list.ToArray();
        }

        private static string[] SplitParameters(string parameters)
        {
            //Splits parameter string taking into account brackets...
            var list = new List<string>();
            var builder = new StringBuilder();

            bool isInString = false;

            int curlyBrackets = 0;
            int squareBrackets = 0;
            int roundBrackets = 0;
            for (int i = 0; i < parameters.Length; i++)
            {
                var current = parameters[i];

                if (current == '"')
                {
                    if (i == 0 || parameters[i - 1] != '\\')
                    {
                        isInString = !isInString;
                    }
                }

                if (!isInString)
                {
                    switch (current)
                    {
                        case '{':
                            curlyBrackets++;
                            break;
                        case '}':
                            curlyBrackets--;
                            break;
                        case '[':
                            squareBrackets++;
                            break;
                        case ']':
                            squareBrackets--;
                            break;
                        case '(':
                            roundBrackets++;
                            break;
                        case ')':
                            roundBrackets--;
                            break;
                        default:
                            if (current == ',' && roundBrackets == 0 && squareBrackets == 0 && curlyBrackets == 0)
                            {
                                //The only commas to be considered as parameter separators are outside:
                                //- Strings
                                //- Square brackets (to ignore indexers)
                                //- Parantheses (to ignore method invocations)
                                //- Curly brackets (to ignore initializers and Bindings)
                                list.Add(builder.ToString());
                                builder.Length = 0;
                                continue;
                            }
                            break;
                    }
                }

                builder.Append(current);
            }

            list.Add(builder.ToString());

            return list.ToArray();
        }
    }
}