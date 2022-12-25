using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Companies.Commands.UpdateCompany
{
    public record UpdateCompanyCommand(Guid Id, string Name, Person Statutory) : IRequest;

    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
    {
        private readonly IApplicationDbContext context;

        public UpdateCompanyCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = await this.context.Companies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Company), request.Id);
            }

            entity.Name = request.Name;
            entity.Statutory = request.Statutory;

            await this.context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
