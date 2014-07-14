using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class CollectionMaxCountAttribute : SinglePropertyValidationAttribute
    {
        public CollectionMaxCountAttribute(int length)
        {
            ConstraintTypes = new List<Type>
            {
                typeof (ICollection)
            };
            Length =length;
        }

        public override ValidationError Validate(object value)
        {
            var val = value as ICollection;

            if (val != null && val.Count > Length)
            {
                ErrorMessage = ErrorMessage ?? string.Format("Collection {0} must contain {1} or less items.", PropertyName, Length);
                return new ValidationError(this);
            }

            return null;
        }

        public int Length { get; set; }
    }
}
