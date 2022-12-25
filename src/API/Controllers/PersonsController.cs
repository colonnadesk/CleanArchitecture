using Application.Persons.Commands.CreatePerson;
using Application.Persons.Commands.DeletePerson;
using Application.Persons.Commands.UpdatePerson;
using Application.Persons.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Controllers
{
    public class PersonsController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> Get(Guid id)
        {
            return await this.Mediator.Send(new GetPersonByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreatePersonCommand command)
        {
            return await this.Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdatePersonCommand command)
        {
            if (id != command.Id)
            {
                return this.BadRequest();
            }

            await this.Mediator.Send(command);

            return this.NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await this.Mediator.Send(new DeletePersonCommand(id));

            return this.NoContent();
        }
    }
}
