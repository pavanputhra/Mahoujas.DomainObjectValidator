using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class StringIsNotEmptyAttribute: ValidationAttribute
    {
        public StringIsNotEmptyAttribute()
        {
            ConstraintType = typeof (string);
        }

        public override ValidationError Validate(string propertyName,object value)
        {
            base.Validate(propertyName,value);

            var val = value as string;

            if (string.IsNullOrEmpty(val))
            {
                ErrorMessage = ErrorMessage ?? string.Format("Property {0} must not be empty", PropertyName);
                return new ValidationError(this);
            }

            return null;
        }
    }
}
