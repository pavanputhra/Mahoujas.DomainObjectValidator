using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class CollectionMinCountTest
    {
        [TestMethod]
        public void Array_Count_Less_Than_Specified_Must_Fail()
        {
            var person = new PersonArray
            {
                Friends = new string[] {"Ramesh", "Suresh"}
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(CollectionMinCountAttribute)));
        }

        [TestMethod]
        public void Array_Count_Equal_To_Specified_Must_Pass()
        {
            var person = new PersonArray
            {
                Friends = new string[] { "Ramesh", "Suresh", "Giresh" }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }

        private class PersonArray
        {
            [CollectionMinCount(3)]
            public string [] Friends { get; set; }
        }
    }
}
