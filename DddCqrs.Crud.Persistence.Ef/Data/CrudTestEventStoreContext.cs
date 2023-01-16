namespace DddCqrs.Crud.Persistence.EventStore.Ef.Data
{
    using DddCqrs.Crud.Domain.Aggregates;
    using DddCqrs.Crud.Domain.Events;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CrudTestEventStoreContext : DbContext
    {
        public CrudTestEventStoreContext()
        {

        }

        public CrudTestEventStoreContext(DbContextOptions<CrudTestEventStoreContext> options)
       : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseSqlServer("Server=192.168.242.121,30033;Database=Bond;User Id=sa;password=mssqltest;");
                optionsBuilder.UseSqlServer("Server=.;Database=CrudEventStore;Integrated Security=True;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrudTestEventStoreContext).Assembly);
        }

        public virtual DbSet<EventData> Events { get; set; }
    }
}
