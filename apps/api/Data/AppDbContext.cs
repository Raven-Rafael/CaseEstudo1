﻿using CaseEstudo1.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaseEstudo1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Borda> Bordas { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Sabor> Sabores { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Bebida> Bebidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<PizzaSabor> PizzasSabores { get; set; }
        public DbSet<SaborIngrediente> SaboresIngredientes { get; set; }
        public DbSet<PrecoBebidaPorTamanho> PrecosBebidaPorTamanho { get; set; }
        public DbSet<BordaPrecoPorTamanho> BordasPrecosPorTamanhos { get; set; }
        public DbSet<SaborPrecoPorTamanho> SaboresPrecosPorTamanhos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PizzaSabor>()
                .HasKey(ps => new { ps.PizzaId, ps.SaborId });

           /* modelBuilder.Entity<PizzaSabor>()
                .HasOne(ps => ps.Pizza)
                .WithMany(p => p.PizzasSabores)
                .HasForeignKey(ps => ps.PizzaId);

            modelBuilder.Entity<PizzaSabor>()
                .HasOne(ps => ps.Sabor)
                .WithMany(s => s.PizzasSabores) 
                .HasForeignKey(ps => ps.SaborId);*/

            modelBuilder.Entity<SaborIngrediente>()
                .HasKey(si => new { si.SaborId, si.IngredienteId });

            modelBuilder.Entity<SaborIngrediente>()
                .HasOne(si => si.Sabor)
                .WithMany(s => s.SaboresIngredientes)
                .HasForeignKey(si => si.SaborId);

            modelBuilder.Entity<SaborIngrediente>()
                .HasOne(si => si.Ingrediente)
                .WithMany(i => i.SaboresIngredientes)
                .HasForeignKey(si => si.IngredienteId);

            modelBuilder.Entity<BordaPrecoPorTamanho>()
                .Property(b => b.Tamanho)
                .HasConversion<string>();

            modelBuilder.Entity<SaborPrecoPorTamanho>()
                .Property(s => s.Tamanho)
                .HasConversion<string>();

            modelBuilder.Entity<PrecoBebidaPorTamanho>()
                .Property(p => p.Tamanho)
                .HasConversion<string>();

            modelBuilder.Entity<PrecoBebidaPorTamanho>()
                .HasOne(p => p.Bebida)
                .WithMany(b => b.Precos)
                .HasForeignKey(p => p.BebidaId);
        }
    }
}
