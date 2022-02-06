using Microsoft.EntityFrameworkCore;
using PontoSysStore.Catalogo.Domain;
using PontoSysStore.Core.Comunications.Mediator;
using PontoSysStore.Core.Data;
using PontoSysStore.Core.Messages;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PontoSysStore.Catalogo.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        private readonly IMediatrHandler _mediatorHandler;
        public CatalogoContext(DbContextOptions<CatalogoContext> options, IMediatrHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            };
            return await base.SaveChangesAsync() > 0;
        }
    }
}
