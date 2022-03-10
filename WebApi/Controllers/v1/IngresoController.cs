using Application.Features.Ingreso.Commands.Create;
using Application.Features.Ingreso.Commands.Delete;
using Application.Features.Ingreso.Commands.Update;
using Application.Features.Ingreso.Queries.GetAll;
using Application.Features.Ingreso.Queries.GetById;
using Application.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class IngresoController : BaseApiController
    {
        //POST api/<controler>
        [HttpPost]
        public async Task<ActionResult> Post(CreateIngresoCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        //GET: api/<controler>
        [HttpGet()]
        public async Task<ActionResult> Get([FromQuery] RequestParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllIngresoQuery 
            { 
                PageNumber = filter.PageNumber, 
                PageSize = filter.PageSize, 
                //Name = filter.Name,
                //LastName = filter.LastName 
            }));
        }

        //GET: api/<controler>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetIngresoByIdQuery { Id = id }));
        }

        //PUT api/<controler>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateIngresoCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            return Ok(await Mediator.Send(command));
        }

        //DELETE api/<controler>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteIngresoCommand { Id = id }));
        }
    }
}
