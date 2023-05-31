using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObjects.Model
{
    public class Account
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public string Location { get; set; }
    }
}
