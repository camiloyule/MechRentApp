using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MechRent.Core.Models;
using System.Reflection.PortableExecutable;


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

        public static void SeedData(AppDbContext context)
        {
            if (!context.Maquinas.Any())
            {
                context.Maquinas.AddRange(
                    new Maquina { nombreMaquina = "Caterpillar 320d2", description="heavy 1", precioHora = 200000, frecuenciaMantenimiento = 1440 },
                    new Maquina { nombreMaquina = "Hyundai Hx340sl", description = "heavy 2", precioHora = 450000, frecuenciaMantenimiento = 1080 },
                    new Maquina { nombreMaquina = "Hitachi Zx 200-6", description = "heavy 3", precioHora = 300000, frecuenciaMantenimiento = 720 }
                );
                context.SaveChanges();
            }
        }

    }
}
