using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var targetIp = "17.248.150.51:443";
            long totalBytes = 0;
            List<TrafficRecord> records = new List<TrafficRecord>();
            using (var reader = new StreamReader("traffic.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                records = csv.GetRecords<TrafficRecord>().Where(el => el.SourceIp != "UDP").ToList();
                var targetNumberRows = records.Where(el => el.SourceIp == targetIp || el.DestinationIp == targetIp).ToList();
                totalBytes = targetNumberRows.Sum(el => el.InByte + el.OutByte);
            }
            var totalMb = (totalBytes / 1024f) / 1024f;
            label1.Text = $"Bill for 17.248.150.51 user is {totalMb * 0.5:F2} rub";

            for (var hour = 0; hour < 2; hour++)
            for (var minute = 0; minute < 60; minute++)
            {
                var currHour = hour > 0 ? 9 : 8;
                var hourBytes = records.Where(el => el.Date.Hour == currHour && el.Date.Minute == minute).Sum(el => el.InByte + el.OutByte);
                chart1.Series["megabytes"].Points.AddXY($"{currHour}:{minute}", (hourBytes / 1024f) / 1024f);
            }
        }
    }
}
