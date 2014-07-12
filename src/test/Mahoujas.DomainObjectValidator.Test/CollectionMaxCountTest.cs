using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class CollectionMaxCountTest
    {
        [TestMethod]
        public void Array_Count_More_Than_Specified_Must_Fail()
        {
            var person = new PersonArray
            {
                Friends = new string[] {"Ramesh", "Suresh", "Giresh", "Paresh"}
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(CollectionMaxCountAttribute)));
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
            [CollectionMaxCount(3)]
            public string [] Friends { get; set; }
        }
    }
}
