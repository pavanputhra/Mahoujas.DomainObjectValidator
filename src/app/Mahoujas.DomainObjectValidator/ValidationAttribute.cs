using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Mahoujas.DomainObjectValidator
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public abstract class ValidationAttribute : Attribute
    {

        #region Properties

        public Type ConstraintType { get; protected set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        #endregion

        public virtual ValidationError Validate(PropertyInfo propertyInfo, object objectToBeValidated)
        {
            PropertyName = PropertyName ?? propertyInfo.Name;
            object value = propertyInfo.GetValue(objectToBeValidated);
            if (value != null && ConstraintType != null && ConstraintType != value.GetType())
            {
                throw new NotSupportedException(
                    string.Format("Attribute is not supported for type {0}. Use with type {1}", value.GetType(), ConstraintType.FullName));
            }

            return null;
        }

        #region Construction

        protected ValidationAttribute()
        {
            ConstraintType = typeof (object);
            PropertyName = "";
            ErrorMessage = "";
        }

        #endregion
    }
}
