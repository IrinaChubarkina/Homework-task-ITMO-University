using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Billing
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(1)]
        public string Origin { get; set; }
        [Index(2)]
        public string Destination { get; set; }
        [Index(3)]
        public decimal CallDuration { get; set; }
        [Index(4)]
        public int SmsNumber { get; set; }
    }
}
