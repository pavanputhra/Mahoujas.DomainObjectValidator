using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class PropertyIsNotNullAttribute : ValidationAttribute
    {
        public PropertyIsNotNullAttribute()
        {
            ConstraintType = null;
        }

        public override ValidationError Validate(string propertyName, object value)
        {
            base.Validate(propertyName, value);

            if (value == null)
            {
                ErrorMessage = string.Format("Property {0} must not be null", PropertyName);
                return new ValidationError(this);
            }

            return null;
        }
    }
}
