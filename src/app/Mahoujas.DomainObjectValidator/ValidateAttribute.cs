using System;

namespace Mahoujas.DomainObjectValidator
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidateAttribute : Attribute
    {
    }
}
