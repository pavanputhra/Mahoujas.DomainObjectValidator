using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class PropertyIsNotNullTest
    {
        [TestMethod]
        public void Property_Pointing_To_Null_Must_Fail()
        {
            var person = new Person
            {
                Name = null
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(PropertyIsNotNullAttribute)));
        }

        [TestMethod]
        public void Property_Pointing_To_Valid_Object_Must_Pass()
        {
            var person = new Person
            {
                Name = "Hello"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }

        private class Person
        {
            [PropertyIsNotNull]
            public string Name { get; set; }
        }
    }
}
