using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using CsvHelper;
using CsvHelper.Configuration;

namespace PSC_Demo
{
    class Program
    {
        static void Main()
        {
            string url = "https://qldpsc.smartersoft-integra.com/index.php?_m=251450&_f=3599";
            List<dynamic> records = CSVtoDynamic.ConvertCSVtoDynamic(url);
            
            // Process each record
            foreach (dynamic record in records)
            {
                // Access properties of the record dynamically
                Console.WriteLine(record.ID);
                Console.WriteLine(record.Code);
                Console.WriteLine(record.Description);
                // ... other properties 
            }
        }
    }
}
