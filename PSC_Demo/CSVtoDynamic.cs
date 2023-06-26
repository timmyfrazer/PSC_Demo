using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using CsvHelper;
using CsvHelper.Configuration;

namespace PSC_Demo
{
    class CSVtoDynamic
    {
        public static List<dynamic> ConvertCSVtoDynamic(string url)
        {
            using (WebClient client = new WebClient())
            {
                System.Net.ServicePointManager.ServerCertificateValidationCallback = (senderX, certificate, chain, sslPolicyErrors) => { return true; };

                // Download the CSV file as a byte array
                byte[] csvData = client.DownloadData(url);

                // Configure CsvHelper options using CsvConfiguration
                CsvConfiguration csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true, // Skip the header row
                    HeaderValidated = null, // Disable header validation
                };

                // Create a memory stream from the byte array
                using (MemoryStream stream = new MemoryStream(csvData))
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, csvConfig))
                {
                    // Read the CSV records as dynamic objects
                    List<dynamic> records = csv.GetRecords<dynamic>().ToList();

                    return records;
                }
            }
        }
    }
}
