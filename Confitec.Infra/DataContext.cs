using Microsoft.EntityFrameworkCore;
using Confitec.Domain.Entities;
using Confitec.Infra.Maps;
using System.Reflection;

namespace Confitec.Infra
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserMap).GetTypeInfo().Assembly);
        }
    }
}
