using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class StringMaxLengthTest
    {
        [TestMethod]
        public void String_Execeding_Length_Must_Fail()
        {
            var person = new Person
            {
                Name = "123456789"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringMaxLengthAttribute)));

        }

        [TestMethod]
        public void String_Equal_To_Length_Must_Pass()
        {
            var person = new Person
            {
                Name = "12345678"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);

        }

        private class Person
        {
            [StringMaxLength(8)]
            public string Name { get; set; }
        }
    }
}
