using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Companies.Commands.DeleteCompany
{
    public record DeleteCompanyCommand(Guid Id) : IRequest;

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
    {
        private readonly IApplicationDbContext applicationDbContext;
        public DeleteCompanyCommandHandler(IApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.applicationDbContext.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            this.applicationDbContext.Companies.Remove(entity);

            await this.applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
