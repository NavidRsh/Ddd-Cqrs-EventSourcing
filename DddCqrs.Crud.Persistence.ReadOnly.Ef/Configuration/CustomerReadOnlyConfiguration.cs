using DddCqrs.Crud.ReadDomain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DddCqrs.Crud.Persistence.ReadDomain.Ef.Configuration
{
    public class CustomerReadOnlyConfiguration : IEntityTypeConfiguration<CustomerReadEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerReadEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Email).IsUnique();

            builder.HasIndex(e => new { e.Firstname, e.Lastname, e.DateOfBirth }).IsUnique(); 
        }
    }
}
