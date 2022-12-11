using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public class ApplicationDbContextInitialiser
    {
        private readonly ApplicationDbContext context;

        public ApplicationDbContextInitialiser(ApplicationDbContext context)
        {
            this.context = context;
        }
        
        public async Task InitialiseAsync()
        {         
            if(this.context.Database.IsSqlServer())
            {
                await this.context.Database.MigrateAsync();
            }
        }
    }
}
