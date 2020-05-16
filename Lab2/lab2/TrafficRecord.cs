using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class TrafficRecord
    {
        [Index(0)]
        public DateTime Date { get; set; }
        [Index(4)]
        public string SourceIp { get; set; }
        [Index(5)]
        public string DestinationIp { get; set; }
        [Index(8)]
        public long InByte { get; set; }
        [Index(9)]
        public long OutByte { get; set; }
    }
}
