using BillingApi.Models;
using BillingApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace BillingApi.Controllers
{
    [Route("billing")]
    [ApiController]
    public class BillingApiController : ControllerBase
    {
        private readonly BillingService _billingService;
        private readonly IEnumerable<IValidator> _validators;

        public BillingApiController(IEnumerable<IValidator> validators)
        {
            _billingService = new BillingService();
            _validators = validators;
        }

        [HttpGet]
        [Route("confirmation")]
        public IActionResult ConfirmOrder(Order order)
        {
            if (!_validators.All(v => v.IsValid(order)))
                return BadRequest();



            return Ok(_billingService.ConfirmOrder(order));
        }
    }
}
