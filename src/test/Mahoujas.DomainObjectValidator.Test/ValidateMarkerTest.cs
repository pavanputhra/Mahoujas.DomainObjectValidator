using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class ValidateMarkerTest
    {
        [TestMethod]
        public void Validation_should_pass_without_validate_attribute()
        {
            var person = new Person
            {
                SomeType = new SomeType
                {
                    Value = 15
                }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0,errors.Count);
        }

        [TestMethod]
        public void Validation_should_fail_with_validate_attribute()
        {
            var person = new PersonError
            {
                SomeType = new SomeType
                {
                    Value = 15
                }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(NumberRangeAttribute)));
        }

        private class Person
        {
            public SomeType SomeType { get; set; }
        }

        private class PersonError
        {
            [Validate]
            public SomeType SomeType { get; set; }
        }

        private class SomeType
        {
            [NumberRange(5,10)]
            public int Value { get; set; }
        }
    }
}
