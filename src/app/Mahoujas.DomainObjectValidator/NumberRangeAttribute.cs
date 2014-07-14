using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahoujas.DomainObjectValidator
{
    public class NumberRangeAttribute : SinglePropertyOrCollectionValidationAttribute
    {
        public NumberRangeAttribute(double min,double max)
        {
            ConstraintTypes = new List<Type>
            {
                typeof(short),
                typeof(ICollection<short>),
                typeof(ushort),
                typeof(ICollection<ushort>),
                typeof(int),
                typeof(ICollection<int>),
                typeof(uint),
                typeof(ICollection<uint>),
                typeof(long),
                typeof(ICollection<long>),
                typeof(ulong),
                typeof(ICollection<ulong>),
                typeof(float),
                typeof(ICollection<float>),
                typeof(double),
                typeof(ICollection<double>),
                typeof(decimal),
                typeof(ICollection<double>),
            };
            Min = min;
            Max = max;
        }

        public override ValidationError Validate(object value)
        {
            double val = Convert.ToDouble(value);
            if (val < Min || val > Max)
            {
                ErrorMessage = ErrorMessage ?? string.Format("Property {0} must be in the specified range.",PropertyName);
                return new ValidationError(this);
            }
            return null;
        }


        public double Min { get; set; }
        public double Max { get; set; }
    }
}
