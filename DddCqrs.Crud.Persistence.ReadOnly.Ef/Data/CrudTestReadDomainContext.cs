namespace DddCqrs.Crud.Persistence.ReadDomain.Ef.Data
{
    using DddCqrs.Crud.ReadDomain.Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CrudTestReadDomainContext : DbContext
    {
        public CrudTestReadDomainContext()
        {

        }
        public CrudTestReadDomainContext(DbContextOptions<CrudTestReadDomainContext> options)
      : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=192.168.242.121,30033;Database=Bond;User Id=sa;password=mssqltest;");
                optionsBuilder.UseSqlServer("Server=.;Database=CrudReadModel;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudTestReadDomainContext).Assembly);
        }

        public virtual DbSet<CustomerReadEntity> Customers { get; set; }
    }
}
