using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkApp
{
    public class RandomDateTimeOffsetGenerator
    {
        /// <summary>
        /// DateTimeOffset generator
        /// </summary>
        /// <param name="gen">Random generator</param>
        /// <returns>Random DateTimeOffset</returns>
        public static DateTimeOffset RandomDateTimeOffset(Random gen)
        {
            DateTimeOffset start = new DateTimeOffset();
            int range = (DateTimeOffset.Now - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
