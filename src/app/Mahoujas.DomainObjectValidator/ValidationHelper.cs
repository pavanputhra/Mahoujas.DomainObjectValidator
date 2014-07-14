using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mahoujas.DomainObjectValidator
{
    public static class ValidationHelper
    {
        public static IList<ValidationError> ValidateDomainObject(this object objToBeValidated)
        {
            var errors = new List<ValidationError>();

            var type = objToBeValidated.GetType();
            var properties = type.GetRuntimeProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes<ValidationAttribute>();
                foreach (ValidationAttribute attribute in attributes)
                {
                    var validationError = attribute.Validate(property, objToBeValidated);
                    if (validationError != null)
                    {
                        errors.Add(validationError);
                    }
                }
            }

            return errors;
        }

        public static IList<ValidationError> ValidateDomainObject(this object objToBeValidated,string category,bool excludeCatogory = false)
        {
            var errors = new List<ValidationError>();

            var type = objToBeValidated.GetType();
            var properties = type.GetRuntimeProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes<ValidationAttribute>();
                foreach (ValidationAttribute attribute in attributes.Where(a => (a.Category == category) == !excludeCatogory))
                {
                    var validationError = attribute.Validate(property, objToBeValidated);
                    if (validationError != null)
                    {
                        errors.Add(validationError);
                    }
                }
            }

            return errors;
        }
    }
}
