using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Application.Common.Exceptions;
using Application.Common.Interfaces;

namespace Application.Companies.Commands.DeleteCompany
{
    public record DeleteCompanyCommand(Guid Id) : IRequest;

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        public DeleteCompanyCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            _applicationDbContext.Companies.Remove(entity);

            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
