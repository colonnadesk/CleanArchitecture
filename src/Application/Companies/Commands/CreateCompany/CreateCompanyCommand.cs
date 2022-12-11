﻿using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.CreateCompany
{
    public record CreateCompanyCommand(string Name, Person Statutory) : IRequest<Guid>;

    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public CreateCompanyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Company
            {
                Name = request.Name,
                Statutory = request.Statutory
            };

            _context.Companies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}