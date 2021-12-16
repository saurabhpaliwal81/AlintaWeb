using Application.Customers.Commands;
using Application.Customers.Commands.DeleteCustomer;
using Application.Customers.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/Customers")]
    [ApiController]
    public class CustomerController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        public async Task<ActionResult<int>> Update(UpdateCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> Delete(DeleteCustomerCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> Get([FromQuery] SearchCustomerQuery query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}