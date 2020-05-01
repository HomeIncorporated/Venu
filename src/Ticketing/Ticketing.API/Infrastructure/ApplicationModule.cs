﻿using Autofac;
using Venu.Ticketing.Domain.AggregatesModel.CustomerAggregate;
using Venu.Ticketing.Domain.AggregatesModel.EventAggregate;
using Venu.Ticketing.Domain.AggregatesModel.SeatingAggregate;
using Venu.Ticketing.Domain.AggregatesModel.TicketAggregate;
using Venu.Ticketing.Domain.AggregatesModel.VenueAggregate;
using Venu.Ticketing.Infrastructure.Repositories;

namespace Venu.Ticketing.API.Infrastructure
{

    public class ApplicationModule :Autofac.Module
    {
        
        public ApplicationModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<EventRepository>()
                .As<IEventRepository>()
                .InstancePerLifetimeScope();
            
            builder.RegisterType<VenueRepository>()
                .As<IVenueRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<SeatingRepository>()
               .As<ISeatingRepository>()
               .InstancePerLifetimeScope();
            
            builder.RegisterType<TicketRepository>()
                .As<ITicketRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
