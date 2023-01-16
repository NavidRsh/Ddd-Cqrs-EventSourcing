using DddCqrs.Crud.Api.ViewModels.Customer;
using DddCqrs.Crud.Application.Features.Customers.Queries;
using DddCqrs.Crud.Application.Features.Customers.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DddCqrs.Crud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<ActionResult<ListCustomerQueryDto>> Get()
        {
            return Ok(await _mediator.Send(new ListCustomerQuery()));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCustomerQueryDto>> Get(string id)
        {
            return Ok(await _mediator.Send(new GetCustomerQuery() { 
                Id = id
            }));
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<ActionResult<AddCustomerDto>> Post([FromBody] AddCustomerVm value)
        {
            return Ok(await _mediator.Send(new AddCustomerCommand
            {
                FirstName = value.FirstName,
                LastName = value.LastName,
                BankAccountNumber = value.BankAccountNumber,
                DateOfBirth = value.DateOfBirth,
                Email = value.Email,
                PhoneNumber = value.PhoneNumber
            }));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateCustomerDto>> Put(string id, [FromBody] UpdateCustomerVm value)
        {
            if (id != value.Id)
                return BadRequest("Customer Id is not valid!");

            return Ok(await _mediator.Send(new UpdateCustomerCommand
            {
                Id = value.Id,
                FirstName = value.FirstName,
                LastName = value.LastName,
                BankAccountNumber = value.BankAccountNumber,
                DateOfBirth = value.DateOfBirth,
                Email = value.Email,
                PhoneNumber = value.PhoneNumber
            }));
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteCustomerDto>> Delete(string id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommand
            {
                Id = id
            }));
        }
    }
}
