using System;
using System.ComponentModel.DataAnnotations;
using Csla;

namespace CslaGenFork.Rules.DateRules
{
    /// <summary>
    /// Business rule for checking a date property is valid and not in the future.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class DateNotInFutureAttr : ValidationAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateNotInFutureAttr"/> class.
        /// </summary>
        public DateNotInFutureAttr()
        {
            ErrorMessage = "{0} can't be in the future.";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateNotInFutureAttr"/> class.
        /// </summary>
        /// <param name="errorMessage">The error message.</param>
        public DateNotInFutureAttr(string errorMessage)
            : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Validation rule implementation.
        /// </summary>
        /// <param name="value">The date to validate.</param>
        /// <param name="validationContext">The context information about the validation operation.</param>
        /// <returns>
        /// An instance of the <see cref="T:System.ComponentModel.DataAnnotations.ValidationResult"/> class.
        /// </returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((SmartDate) value > DateTime.Now)
            {
                string message = (string.Format(ErrorMessage, validationContext.DisplayName));
                return new ValidationResult(message);
            }

            try
            {
                if ((SmartDate) value >= DateTime.MinValue)
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new ValidationResult(
                    string.Format(string.Format("{0}{1} isn't valid.",
                                                ex.Message + Environment.NewLine,
                                                validationContext.DisplayName)));
            }
            return null;
        }
    }
}