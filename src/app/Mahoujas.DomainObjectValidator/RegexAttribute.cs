using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Mahoujas.DomainObjectValidator
{
    public class RegexAttribute : SinglePropertyOrCollectionValidationAttribute
    {
        public RegexAttribute(string pattern)
        {
            ConstraintTypes = new List<Type>
            {
                typeof(string),
                typeof(ICollection<string>)
            };

            Pattern = pattern;
        }

        public override ValidationError Validate(object value)
        {
            var val = value as string;

            if (val != null && !Regex.IsMatch(val, Pattern))
            {
                ErrorMessage = ErrorMessage ??
                               string.Format("Property {0} must match specified regular expression.", PropertyName);
                return new ValidationError(this);
            }

            return null;
        }

        public string Pattern { get; set; }
    }
}
