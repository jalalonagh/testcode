using Common.Utilities;
using Entities;
using Microsoft.EntityFrameworkCore;
using SupplierSystem.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Data
{
    public class DataContext : ApplicationDbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Assembly> assemblies = new List<Assembly>();
            base.OnModelCreating(modelBuilder);
            assemblies = assemblies.Append(typeof(IEntity).Assembly);
            assemblies = assemblies.Append(typeof(ISMSEntities).Assembly);
            assemblies = assemblies.Append(typeof(ISupplierSystemEntity).Assembly);
            assemblies = assemblies.Append(typeof(IData).Assembly);
            modelBuilder.RegisterAllEntities<IEntity>(assemblies.ToArray());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IData).Assembly);
            modelBuilder.RegisterEntityTypeConfiguration(assemblies.ToArray());
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }
    }
}
