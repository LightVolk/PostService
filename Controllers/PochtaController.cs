using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PostServiceWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PochtaController : ControllerBase
    {        
        private readonly ILogger<PochtaController> _logger;
        private IClient _client;

        public PochtaController(IClient client,ILogger<PochtaController> logger)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        public OperationHistoryResponce GetOperationHistory(string trackId)
        {
            try
            {
                var task = _client.GetOperationHistory(trackId);
                var result = task.Result;

                return new OperationHistoryResponce()
                {
                    OperationHistoryRecords = result.OperationHistoryData
                };
            }
            catch(Exception ex)
            {
                _logger.LogError($"{ex.Message} {ex.StackTrace}");
            }

            return null;
            
        }
    }

    
}
