using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Ticketing.DbContexts;
using TicketingSystem.Ticketing.Repositories;
using TicketingSystem.Ticketing.Services;
using TicketingSystem.Ticketing.UnitOfWorks;

namespace TicketingSystem.Ticketing
{
    public class TicketingModule:Module
    {
        private readonly string _connectionString;
        private readonly string _assemblyName;

        public TicketingModule(string connectionString, string assemblyName)
        {
            _connectionString = connectionString;
            _assemblyName = assemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TicketingDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("assemblyName", _assemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<TicketingDbContext>().As<ITicketingDbContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("assemblyName", _assemblyName)
            //    .InstancePerLifetimeScope();

            builder.RegisterType<TicketingUnitOfWork>().As<ITicketingUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketPurchaseRepository>().As<ITicketPurchaseRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TicketPurchaseService>().As<ITicketPurchaseService>()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }

    }
}
