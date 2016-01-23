// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollapseWhiteSpace.cs" company="Marimer LLC">
//   Copyright (c) Marimer LLC. All rights reserved. Website: http://www.lhotka.net/cslanet
// </copyright>
// <summary>
//   Removes leading, trailing, duplicate white space characters.
//   Rule should run on client when a property is changed or when CheckRules is called.
//   Rule must run before any validation rules.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Text.RegularExpressions;
using Csla.Core;
using Csla.Rules;

namespace CslaGenFork.Rules.TransformationRules
{
    /// <summary>
    /// Removes leading, trailing, duplicate white space characters.<br/>
    /// Rule should run on client when a property is changed or when CheckRules is called.
    /// Rule must run before any validation rules.
    /// </summary>
    public class CollapseWhiteSpace : PropertyRule
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollapseWhiteSpace"/> class.
        /// </summary>
        /// <param name="primaryProperty">The primary property.</param>
        public CollapseWhiteSpace(IPropertyInfo primaryProperty)
            : base(primaryProperty)
        {
            InputProperties = new List<IPropertyInfo> {primaryProperty};

            CanRunOnServer = false;
        }

        /// <summary>
        /// Business rule implementation.
        /// </summary>
        /// <param name="context">Rule context object.</param>
        protected override void Execute(RuleContext context)
        {
            var value = (string) context.InputPropertyValues[PrimaryProperty];
            if (string.IsNullOrEmpty(value)) return;

            var newValue = value.Trim();
            var r = new Regex(@"\s+");
            newValue = r.Replace(newValue, @" ");
            context.AddOutValue(PrimaryProperty, newValue);
        }
    }
}
