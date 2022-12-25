using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.DeletePerson
{
    public record DeletePersonCommand(Guid Id) : IRequest;

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext context;

        public DeletePersonCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Persons.FindAsync(request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            this.context.Persons.Remove(entity);

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
