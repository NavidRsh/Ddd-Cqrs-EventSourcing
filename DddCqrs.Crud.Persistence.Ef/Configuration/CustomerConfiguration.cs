using DddCqrs.Crud.Domain.Aggregates;
using DddCqrs.Crud.Domain.Events;
using DddCqrs.Crud.ReadDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.EventStore.Ef.Configuration
{
    public class EventDataConfiguration : IEntityTypeConfiguration<EventData>
    {
        public void Configure(EntityTypeBuilder<EventData> builder)
        {
            builder.HasKey(e => e.EventId);            
        }
    }
}
