using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class SinglePropertyOrCollectionValidationAttribute : SinglePropertyValidationAttribute
    {
        public override ValidationError Validate(PropertyInfo propertyInfo, object objectToBeValidated)
        {
            var returnValue = base.Validate(propertyInfo, objectToBeValidated);

            if (returnValue != null)
            {
                return returnValue;
            }

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

            return null;
        }
    }
}
