using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeDataApi.Models
{
    public class StockDataModel
    {
        public int Time { get; set; }
        public int RowId { get; set; }
        public string Action { get; set; } 
        public string Portfolio { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
