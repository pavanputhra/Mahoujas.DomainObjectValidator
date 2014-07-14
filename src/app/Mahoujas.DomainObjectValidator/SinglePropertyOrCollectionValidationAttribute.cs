using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class SinglePropertyOrCollectionValidationAttribute : ValidationAttribute,ISinglePropertyValidation
    {
        public override ValidationError Validate(PropertyInfo propertyInfo, object objectToBeValidated)
        {
            base.Validate(propertyInfo, objectToBeValidated);

            var collection = propertyInfo.GetValue(objectToBeValidated) as ICollection;

            if (collection != null)
            {
                foreach (var c in collection)
                {
                    var error = Validate(c);
                    if (error != null)
                    {
                        return error;
                    }
                }
            }
            else
            {
                return Validate(propertyInfo.GetValue(objectToBeValidated));
            }

            return null;
        }

        public virtual ValidationError Validate(object value)
        {
            throw new NotSupportedException();
        }
    }
}
