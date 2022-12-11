﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Person> Persons { get; }
        DbSet<Documentation> Documentations { get; }
        DbSet<Company> Companies { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
