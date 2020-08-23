namespace APICount.Controllers
{
    using APICount.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class CountController : ControllerBase
    {       
        private readonly ILogger<CountController> _logger;
        private static readonly Count _COUNT = new Count();
        private readonly IConfiguration _configuration;

        public CountController(ILogger<CountController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public object Get()
        {
            lock (_COUNT)
            {
                _COUNT.Increment();
                _logger.LogInformation($"Count - Actual value: {_COUNT.ActualValue}");

                return new
                {
                    _COUNT.ActualValue,
                    _COUNT.Local,
                    _COUNT.Kernel,
                    _COUNT.TargetFramework,
                    MensagemFixa = "Test",
                    MensagemVariavel = _configuration["VariableMessage"]
                };
            }
        }
    }
}
