using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class StringMaxLengthAttribute : StringValidatorAttribute
    {
        public StringMaxLengthAttribute(int length)
        {
            Length = length;
        }

        public override ValidationError Validate(string propertyName, object value)
        {
            var val = value as string;

            if (val != null && val.Length > Length)
            {
                ErrorMessage = ErrorMessage ?? string.Format("Property {0} must be less than or equal to {1}", PropertyName,Length);
                return new ValidationError(this);
            }

            return null;
        }

        public int Length { get; private set; }
    }
}
