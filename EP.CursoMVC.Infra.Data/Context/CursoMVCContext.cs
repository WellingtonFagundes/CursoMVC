using EP.CursoMVC.Domain;
using EP.CursoMVC.Domain.Models;
using EP.CursoMVC.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.CursoMVC.Infra.Data.Context
{
    public class CursoMVCContext:DbContext
    {
        public CursoMVCContext():base("DefaultConnection")
        {
            /*
             * O Lazy Loading faz com que o AutoMapper verifica todos os campos
             * pois o proxy simula a classe que temos carregando vários campos
             * que pode diminuir a performance, por isso desabilitamos
            */
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;

        }
     
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());

            //modelBuilder.HasDefaultSchema("Sistema1");

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //ChangeTracker - Mapeia as mudanças de qualquer coisa que está modificando
            foreach(var entry in ChangeTracker.Entries()
                    .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                    entry.Property("DataCadastro").IsModified = false;
            }

            return base.SaveChanges();
        }

    }
}
