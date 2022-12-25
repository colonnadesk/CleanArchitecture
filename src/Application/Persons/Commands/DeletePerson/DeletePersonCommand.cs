using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Commands.DeletePerson
{
    public record DeletePersonCommand(Guid Id) : IRequest;

    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            _context.Persons.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
