using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.CreatePerson
{
    public record CreatePersonCommand : IRequest<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IApplicationDbContext context;

        public CreatePersonCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName
            };

            context.Persons.Add(entity);
            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
