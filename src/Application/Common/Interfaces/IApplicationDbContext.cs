using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Documentation> Documentations { get; }
        DbSet<Company> Companies { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
