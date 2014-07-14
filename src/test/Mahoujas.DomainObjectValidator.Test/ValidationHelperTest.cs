using System;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class ValidationHelperTest
    {
        [TestMethod]
        public void Validation_Must_Give_Error_While_No_Catagory()
        {
            var person = new Person
            {
                Name = "ABCD",
                Nickname = "ABCDE"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringMinLengthAttribute)));
        }


        [TestMethod]
        public void Validation_Must_Not_Give_Error_While_Catagory()
        {
            var person = new Person
            {
                Name = "A",
                Nickname = "ABCDE"
            };

            var errors = person.ValidateDomainObject("ServerValidation");
            Assert.AreEqual(0, errors.Count);
        }


        [TestMethod]
        public void Validation_Must_Not_Give_Error_While_Catagory_Exclude()
        {
            var person = new Person
            {
                Name = "A",
                Nickname = "ABCDE"
            };

            var errors = person.ValidateDomainObject("ServerValidation",true);
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(StringMinLengthAttribute)));
        }

        private class Person
        {
            [StringMinLength(5)]
            public string Name { get; set; }

            [StringMinLength(5,Category = "ServerValidation")]
            public string Nickname { get; set; }
        }
    }
}
