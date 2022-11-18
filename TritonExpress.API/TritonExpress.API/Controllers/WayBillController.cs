﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using TritonExpress.API.Service.Features.WayBillFeatures.Command;
using TritonExpress.API.Service.Features.WayBillFeatures.Query;

namespace TritonExpress.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WayBillController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllWayBillQuery()));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await Mediator.Send(new GetWayBillByIdQuery { Id = Id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsertWayBillComman command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateWayBillCommand command)
        {
            if (id != command.WayBillId)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await Mediator.Send(new DeleteWayBillCommand { Id = Id }));
        }
    }
}
