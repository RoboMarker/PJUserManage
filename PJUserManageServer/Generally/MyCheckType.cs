using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generally
{
    public class MyCheckType
    {
        public static bool IsEnumerableType(Type type)
        {
            return typeof(IEnumerable<dynamic>).IsAssignableFrom(type);
        }
    }
}
