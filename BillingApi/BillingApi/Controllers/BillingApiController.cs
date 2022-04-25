using BillingApi.Core.Services;
using BillingApi.Database;
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
        private readonly IBillingService _billingService;
        private readonly IEnumerable<IValidator> _validators;
        protected readonly IBillingApiDbContext _context;

        public BillingApiController(IEnumerable<IValidator> validators, IBillingService billingService, IBillingApiDbContext context)
        {
            _billingService = billingService;
            _validators = validators;
            _context = context;
        }

        [HttpPut]
        [Route("confirmation")]
        public IActionResult ConfirmOrder(Order order)
        {
            if (!_validators.All(v => v.IsValid(order)))
                return BadRequest();

            _billingService.Create(order);

            var receipt = _billingService.MapPayementGateway(order);
            return Ok(receipt);
        }
    }
}
