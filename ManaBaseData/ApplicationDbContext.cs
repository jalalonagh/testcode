using Common.Utilities;
using ManaBaseEntity.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManaBaseData
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IEnumerable<Assembly> assemblies = new List<Assembly>();
            assemblies = ReadAssemblies();
            base.OnModelCreating(modelBuilder);
            assemblies = assemblies.Append(typeof(IEntity).Assembly);
            modelBuilder.RegisterAllEntities<IEntity>(assemblies.ToArray());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntity).Assembly);
            modelBuilder.RegisterEntityTypeConfiguration(assemblies.ToArray());
            modelBuilder.AddRestrictDeleteBehaviorConvention();
            modelBuilder.AddSequentialGuidForIdConvention();
            modelBuilder.AddPluralizingTableNameConvention();
        }

        private List<Assembly> ReadAssemblies()
        {
            if (!File.Exists("datarepositoryconfiguration.json"))
                using (FileStream sw = File.Create("datarepositoryconfiguration.json"))
                {
                    var json = Newtonsoft.Json.JsonConvert.SerializeObject(new DataRepositoryConfiguration()
                    {
                        EntityAssemblies = new string[] { "Entities" },
                        MigrationAssembly = "Data"
                    });
                    byte[] bytes = new UTF8Encoding(true).GetBytes(json);
                    sw.Write(bytes, 0, bytes.Length);
                }
            var configurationJson = File.ReadAllText("datarepositoryconfiguration.json");
            if (!string.IsNullOrEmpty(configurationJson))
            {
                var conf = Newtonsoft.Json.JsonConvert.DeserializeObject<DataRepositoryConfiguration>(configurationJson);
                if (conf != null && conf.EntityAssemblies.Any())
                    return conf.EntityAssemblies.Select(s => Assembly.Load(s)).ToList();
            }
            return new List<Assembly>();
        }

        public override int SaveChanges()
        {
            _cleanString();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            _cleanString();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            _cleanString();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void _cleanString()
        {
            var changedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var item in changedEntities)
            {
                if (item.Entity == null)
                    continue;
                var properties = item.Entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead && p.CanWrite && p.PropertyType == typeof(string));
                foreach (var property in properties)
                {
                    var propName = property.Name;
                    var val = (string)property.GetValue(item.Entity, null);
                    if (val.HasValue())
                    {
                        var newVal = val.Fa2En().FixPersianChars();
                        if (newVal == val)
                            continue;
                        property.SetValue(item.Entity, newVal, null);
                    }
                }
            }
        }
    }
}
