using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Persons.Queries
{
    public class GetPersonByIdQuery : IRequest<PersonDto>
    {
        public Guid Id { get; set; }
    }

    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
    {
        private readonly IApplicationDbContext context;

        public GetPersonByIdQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Persons.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }

            return new PersonDto
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };
        }
    }
}
