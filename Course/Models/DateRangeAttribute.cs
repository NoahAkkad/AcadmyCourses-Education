using System.ComponentModel.DataAnnotations;

namespace Course.Models
{
    public class DateRangeAttribute : RangeAttribute
    {
        public DateRangeAttribute(string minimum) : base(typeof(DateTime), minimum, DateTime.Now.ToShortDateString())
        {
        }
    }
}

