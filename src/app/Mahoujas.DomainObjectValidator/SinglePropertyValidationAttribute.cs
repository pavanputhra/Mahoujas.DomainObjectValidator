using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public abstract class SinglePropertyValidationAttribute : ValidationAttribute,ISinglePropertyValidation
    {
        public override ValidationError Validate(PropertyInfo propertyInfo, object objectToBeValidated)
        {
            base.Validate(propertyInfo, objectToBeValidated);

            return Validate(propertyInfo.GetValue(objectToBeValidated));
        }

        public virtual ValidationError Validate(object value)
        {
            throw new NotSupportedException();
        }
    }
}
