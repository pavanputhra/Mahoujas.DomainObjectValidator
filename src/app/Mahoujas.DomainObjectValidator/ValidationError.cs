using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class ValidationError
    {
        public ValidationError()
        {
        }

        public ValidationError(ValidationAttribute validatorAttribute)
        {
            ValidatorType = validatorAttribute.GetType();
            PropertyName = validatorAttribute.PropertyName;
            ErrorMessage = validatorAttribute.ErrorMessage;
        }

        public Type ValidatorType { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return string.Format("{0} property failed with following error: {1}", PropertyName, ErrorMessage);
        }
    }
}
