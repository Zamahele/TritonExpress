﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TritonExpress.API.Service.Features.LocationFeatures.Command;
using TritonExpress.API.Service.Features.LocationFeatures.Query;

namespace TritonExpress.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocationController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllAllocationsQuery()));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await Mediator.Send(new GetAllocationByIdQuery { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertAllocationComman command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateAllocationCommand command)
        {
            if (id != command.AllocationId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await Mediator.Send(new DeleteAllocationCommand { Id = Id }));
        }
    }
}