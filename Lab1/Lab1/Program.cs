using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalMinutes = 0;
            int totalMessages = 0;
            string targetNumber = "911926375";

            using (var reader = new StreamReader("data.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Billing>();
                var targetNumberRows = records.Where(el => el.Origin == targetNumber || el.Destination == targetNumber).ToList();
                totalMinutes = targetNumberRows.Sum(el => el.CallDuration);
                totalMessages = targetNumberRows.Sum(el => el.SmsNumber);
            }

            decimal messagesBill = totalMessages - 5;
            Console.WriteLine($"Calls bill: {totalMinutes} rub");
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"SMS bill: {messagesBill} rub");
            Console.WriteLine("_____________________________________");
            Console.WriteLine($"Total: {totalMinutes + messagesBill}");
            Console.ReadLine();
        }
    }
}
