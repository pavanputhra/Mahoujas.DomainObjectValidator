using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class StringIsNotEmptyTest
    {
        [TestMethod]
        public void String_Is_Not_Empty()
        {
            var person = new Person
            {
                Name = ""
            };
            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count());
            Assert.AreEqual(true,errors.Any(e => e.AttributeType == typeof(StringIsNotEmptyAttribute)));
        }

        [TestMethod]
        public void String_Is_Not_Null_And_Not_Empty()
        {
            var person = new Person();
            var errors = person.ValidateDomainObject();
            Assert.AreEqual(2, errors.Count());
            Assert.AreEqual(true, errors.Any(e => e.AttributeType == typeof(StringIsNotEmptyAttribute)));
            Assert.AreEqual(true, errors.Any(e => e.AttributeType == typeof(PropertyIsNotNullAttribute)));
        }


        public class Person
        {
            [PropertyIsNotNull]
            [StringIsNotEmpty]
            public string Name { get; set; }
        }
    }
}
