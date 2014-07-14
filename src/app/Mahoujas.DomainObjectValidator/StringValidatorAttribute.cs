using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public abstract class StringValidatorAttribute : SinglePropertyOrCollectionValidationAttribute
    {
        protected StringValidatorAttribute()
        {
            ConstraintTypes = new List<Type>
            {
                typeof(string),
                typeof(ICollection<string>)
            };
        }
    }
}
