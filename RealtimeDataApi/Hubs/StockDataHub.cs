using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RealtimeDataApi.Services;
using RealtimeDataApi.Models;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;
using CsvHelper;

namespace RealtimeDataApi.Hubs
{
    public interface IStockDataHub
    {
        Task Connected(string state);
        IAsyncEnumerable<IEnumerable<StockDataModel>> GetData();
    }

    public class StockDataHub : Hub<IStockDataHub>
    {
        private IReadFromCsvService _readFromCsv;

        public StockDataHub(IReadFromCsvService readFromCsv) => (_readFromCsv) = (readFromCsv);

        public async IAsyncEnumerable<IEnumerable<StockDataModel>> GetData()
        {
            var datasFromCsv = _readFromCsv.ReadCsvFile();

            var maxTimeInData = datasFromCsv.OrderBy(x => x.Time).Last().Time;

            var counter = 0;

            while (true)
            {
                yield return datasFromCsv.Where(x => x.Time == counter);
                counter++;

                if (counter > maxTimeInData)
                {
                    counter = 0;
                }
                await Task.Delay(1000);
            }
        }
    }
}
