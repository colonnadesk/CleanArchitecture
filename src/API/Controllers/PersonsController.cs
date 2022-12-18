using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.DeletePerson;
using Application.Persons.Commands.UpdatePerson;
using Application.Persons.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Controllers
{
    public class PersonsController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(Guid id)
        {
            return await Mediator.Send(new GetPersonByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreatePersonCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeletePersonCommand(id));

            return NoContent();
        }
    }
}
