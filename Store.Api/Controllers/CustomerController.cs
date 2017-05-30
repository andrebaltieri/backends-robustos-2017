using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Domain.Commands.Handlers;
using Store.Domain.Commands.Inputs;

namespace Store.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(CustomerCommandHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("v1/customers")]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            var result = _handler.Handle(command);

            if (!_handler.IsValid())
                return BadRequest(new { success = false, errors = _handler.Notifications });

            return Ok(result);
        }
    }
}