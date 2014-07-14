using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class RegexTest
    {
        [TestMethod]
        public void Regex_not_maching_must_fail()
        {
            var person = new Person
            {
                Email = "Hello_World"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(RegexAttribute)));
        }

        [TestMethod]
        public void Regex_matches_must_pass()
        {
            var person = new Person
            {
                Email = "Hello_World@example.com"
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }

        private class Person
        {
            [Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?")]
            public string Email { get; set; }
        }
    }
}
