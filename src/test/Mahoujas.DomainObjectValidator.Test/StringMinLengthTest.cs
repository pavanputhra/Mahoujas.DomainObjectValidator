using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class StringMinLengthTest
    {
        [TestMethod]
        public void String_Less_Than_Length_Should_Fail()
        {
            var person = new Person
            {
                Name = "123"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringMinLengthAttribute)));
        }

        [TestMethod]
        public void String_Equal_To_Length_Should_Pass()
        {
            var person = new Person
            {
                Name = "1234"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }

        private class Person
        {
            [StringMinLength(4)]
            public string Name { get; set; }
        }
    }
}
