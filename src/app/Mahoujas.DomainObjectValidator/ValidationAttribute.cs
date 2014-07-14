using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mahoujas.DomainObjectValidator
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public abstract class ValidationAttribute : Attribute
    {

        #region Properties

        public ICollection<Type> ConstraintTypes { get; protected set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string Category { get; set; }

        #endregion

        public virtual ValidationError Validate(PropertyInfo propertyInfo, object objectToBeValidated)
        {
            PropertyName = PropertyName ?? propertyInfo.Name;
            object value = propertyInfo.GetValue(objectToBeValidated);
            if (value != null && ConstraintTypes != null && !ConstraintTypes.Any( c => c.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo())))
            {
                throw new NotSupportedException(
                    string.Format("Attribute is not supported for type {0}. Use with type(s) {1}", value.GetType(), ConstraintTypes));
            }

            return null;
        }

        #region Construction

        protected ValidationAttribute()
        {
            ConstraintTypes = new List<Type>
            {
                typeof (object)
            };
            PropertyName = "";
            ErrorMessage = "";
        }

        #endregion
    }
}
