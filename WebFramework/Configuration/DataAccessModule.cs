using Autofac;
using ManaBaseData;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Infrastructure;

namespace WebFramework.Configuration
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;
        public DataAccessModule(string databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<IDbConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();
            builder.Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
                    dbContextOptionsBuilder.UseSqlServer(_databaseConnectionString);
                    return new ApplicationDbContext(dbContextOptionsBuilder.Options);
                }).AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
