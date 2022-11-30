using ASLPaymentGateway.Model.CIMB.Config;
using ASLPaymentGateway.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ASLPaymentGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CIMBPaymentController : ControllerBase
    {
        ILogger<PaymentCIMBService> _logger;
        IOptions<CIMBConfig> _options;
        PaymentCIMBService service;
        public CIMBPaymentController(ILogger<PaymentCIMBService> logger, IOptions<CIMBConfig> options ) {
            _logger= logger;
            _options= options;
            service = new PaymentCIMBService(logger, options.Value);
            service.Url = "https://partnercloud.cimbthai.com/api/v0/api-gateway/v1/partner/oauth/token";
        }
        [HttpGet]
        public string Get()
        {
            service.Login();
            return "Hello";
        }
    }
}
