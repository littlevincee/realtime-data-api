using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using RealtimeDataApi.Models;
using System.Linq.Expressions;

namespace RealtimeDataApi.Services
{
    public interface IReadFromCsvService
    {
        List<StockDataModel> ReadCsvFile();
    }

    public class ReadFromCsv : IReadFromCsvService
    {
        private readonly string _filePath = Directory.GetCurrentDirectory() + "\\Files\\data.csv";

        public List<StockDataModel> ReadCsvFile()
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                Delimiter = ","
            };
            using var reader = new StreamReader(_filePath);
            using var csv = new CsvReader(reader, config);

            return csv.GetRecords<StockDataModel>().ToList();
        }
    }
}
