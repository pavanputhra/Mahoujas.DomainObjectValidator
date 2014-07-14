using System;
using System.Collections;
using System.Collections.Generic;
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
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringIsNotEmptyAttribute)));
        }

        [TestMethod]
        public void String_Containing_Non_Empty_String_Should_Pass()
        {
            var person = new Person
            {
                Name = "A"
            };
            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count());
        }

        [TestMethod]
        public void String_In_Array_Containing_Empty_String_Must_Fail()
        {
            var person = new Person
            {
                Name = "ABC",
                Friends = new List<string>
                {
                    "Hello",
                    "",
                    "World!"
                }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringIsNotEmptyAttribute)));
        }

        [TestMethod]
        public void String_In_Array_Containing_Non_Emtyp_String_Must_Pass()
        {
            var person = new Person
            {
                Name = "ABC",
                Friends = new List<string>
                {
                    "Hello",
                    "A",
                    "World!"
                }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }


        public class Person
        {
            [StringIsNotEmpty]
            public string Name { get; set; }

            [StringIsNotEmpty]
            public ICollection<string> Friends { get; set; }
        }
    }
}
