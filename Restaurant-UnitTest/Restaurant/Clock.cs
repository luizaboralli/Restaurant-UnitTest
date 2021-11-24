using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant
{
    public interface IClock
    {
        public DateTime Now { get; }

        public DateTime GetDate(int year);
    }

    public class Clock: IClock
    {
        public DateTime Now => DateTime.Now;
        
        public DateTime GetDate(int year)
        {
            return new DateTime(year, 11, 1);
        }
    }
}
