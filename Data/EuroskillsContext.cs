using Euroskills2018.Razor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Euroskills2018.Razor.Data;

public class EuroskillsContext : DbContext
{
    public EuroskillsContext(DbContextOptions<EuroskillsContext> options) : base(options) { }

    public DbSet<Szakma> Szakmak => Set<Szakma>();
    public DbSet<Orszag> Orszagok => Set<Orszag>();
    public DbSet<Versenyzo> Versenyzok => Set<Versenyzo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Szakma>(e =>
        {
            e.ToTable("szakma");
            e.HasKey(s => s.Id);
            e.Property(s => s.Id).HasColumnName("id").HasMaxLength(2);
            e.Property(s => s.SzakmaNev).HasColumnName("szakmaNev").HasMaxLength(31).IsRequired();
        });

        modelBuilder.Entity<Orszag>(e =>
        {
            e.ToTable("orszag");
            e.HasKey(o => o.Id);
            e.Property(o => o.Id).HasColumnName("id").HasMaxLength(2);
            e.Property(o => o.OrszagNev).HasColumnName("orszagNev").HasMaxLength(31).IsRequired();
        });

        modelBuilder.Entity<Versenyzo>(e =>
        {
            e.ToTable("versenyzo");
            e.HasKey(v => v.Id);
            e.Property(v => v.Id).HasColumnName("id");
            e.Property(v => v.Nev).HasColumnName("nev").HasMaxLength(31).IsRequired();
            e.Property(v => v.Pont).HasColumnName("pont").IsRequired();
            e.Property(v => v.SzakmaId).HasColumnName("szakmaId").HasMaxLength(2).IsRequired();
            e.Property(v => v.OrszagId).HasColumnName("orszagId").HasMaxLength(2).IsRequired();

            e.HasOne(v => v.Szakma)
             .WithMany(s => s.Versenyzok)
             .HasForeignKey(v => v.SzakmaId)
             .HasConstraintName("fk_versenyzoSzakma");

            e.HasOne(v => v.Orszag)
             .WithMany(o => o.Versenyzok)
             .HasForeignKey(v => v.OrszagId)
             .HasConstraintName("fk_versenyzoOrszag");
        });
    }
}


