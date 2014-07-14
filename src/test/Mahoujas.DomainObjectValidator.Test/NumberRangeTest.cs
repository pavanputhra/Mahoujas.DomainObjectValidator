using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mahoujas.DomainObjectValidator.Test
{
    [TestClass]
    public class NumberRangeTest
    {
        [TestMethod]
        public void Validation_must_fail_when_number_is_less_than_specified_range()
        {
            var person = new Person
            {
                Age = 17,
                Salary = 20000
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1,errors.Count);
            Assert.AreEqual(true,errors.Any(e => e.ValidatorType == typeof(NumberRangeAttribute)));
        }

        [TestMethod]
        public void Validation_must_pass_when_value_is_in_specified_range()
        {
            var person = new Person
            {
                Age = 60,
                Salary = 20000
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }

        [TestMethod]
        public void Validation_must_fail_when_number_is_greater_than_specified_range()
        {
            var person = new Person
            {
                Age = 61,
                Salary = 20000
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(true, errors.Any(e => e.ValidatorType == typeof(NumberRangeAttribute)));
        }

        [TestMethod]
        public void Validation_must_fail_when_decimal_is_greater_than_specified_range()
        {
            var person = new Person
            {
                Age = 18,
                Salary = 2000000
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(true, errors.Any(e => e.ValidatorType == typeof(NumberRangeAttribute)));
        }

        [TestMethod]
        public void Validation_must_fail_when_array_of_decimal_not_in_range()
        {
            var person = new Person
            {
                Age = 18,
                Salary = 20000,
                Score = new long[] { 0, 15 , 16, 25, 26}
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(1, errors.Count);
            Assert.AreEqual(true, errors.Any(e => e.ValidatorType == typeof(NumberRangeAttribute)));
        }

        [TestMethod]
        public void Validation_must_pass_when_array_of_decimal_is_in_range()
        {
            var person = new Person
            {
                Age = 18,
                Salary = 20000,
                Score = new long[] { 0, 15, 16, 25, 21 }
            };

            var errors = person.ValidateDomainObject();
            Assert.AreEqual(0, errors.Count);
        }


        private class Person
        {
            [NumberRange(18,60)]
            public uint Age { get; set; }

            [NumberRange(10000,100000)]
            public decimal Salary { get; set; }

            [NumberRange(0,25)]
            public long [] Score { get; set; }
        }
    }
}
