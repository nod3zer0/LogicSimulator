using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Object1
    {
        public Object1()
        {
            object2 = new List<Object2>();

        }
        public List<Object2> object2 {get;set;}
    }
}
