using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppEFCore.Models
{
    public class Supplier
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string MyProperty { get; set; }
    }
}
