using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain;
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
            var entity = await context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
