using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.UpdatePerson
{
    public record UpdatePersonCommand(Guid Id, string FirstName, string LastName) : IRequest;

    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IApplicationDbContext context;

        public UpdatePersonCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
