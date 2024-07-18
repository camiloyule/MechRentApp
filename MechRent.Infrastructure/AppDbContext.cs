using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MechRent.Core.Models;


namespace MechRent.Infrastructure
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Maquina> Maquinas { get; set; }
        public DbSet<ObraPublica> ObrasPublicas { get; set; }
        public DbSet<EstimacionMaquina> EstimacionMaquinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstimacionMaquina>()
                .HasKey(cm => new { cm.obraId, cm.maquinaId });

            modelBuilder.Entity<EstimacionMaquina>()
                .HasOne(cm => cm.obraPublica)
                .WithMany(c => c.estimacionMaquinas)
                .HasForeignKey(cm => cm.obraId);

            modelBuilder.Entity<EstimacionMaquina>()
                .HasOne(cm => cm.maquina)
                .WithMany()
                .HasForeignKey(cm => cm.maquinaId);
        }

    }
}
