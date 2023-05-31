using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDALLib.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public decimal AvailableBalance { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }

        public Account Account { get; set; }
    }
}
