using System;

namespace Mahoujas.DomainObjectValidator
{
    public interface ISinglePropertyValidation
    {
        ValidationError Validate(object value);
    }
}