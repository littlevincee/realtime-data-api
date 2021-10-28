using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RealtimeDataApi.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealtimeDataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        protected readonly IHubContext<StockDataHub> _dataHub;

        public DataController(IHubContext<StockDataHub> dataHub)
        {
            _dataHub = dataHub;
        }

        [HttpGet]
        public async Task<IActionResult> GetData(int str)
        {
            await _dataHub.Clients.All.SendAsync("sendToReact", "The message " + str + "received");
            
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
