using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Niculae_Ana_Maria_Proiect.Models;

namespace Niculae_Ana_Maria_Proiect.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) :
       base(options)
        {
        }

        public DbSet<Proiect> Proiecte { get; set; }
        public DbSet<Sarcina> Sarcini { get; set; }
        public DbSet<Manager> Manageri { get; set; }
        public DbSet<MembruEchipa> MembriEchipa { get; set; }
        public DbSet<Comentariu> Comentarii { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {    // Configurarea relației one-to-many între Manager și Proiect
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Proiecte)
                .WithOne(p => p.ManagerProiect)
                .HasForeignKey(p => p.ManagerId);

            // Configurarea relației one-to-many între Proiect și Sarcina
            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Sarcini)
                .WithOne(s => s.ProiectAsociat)
                .HasForeignKey(s => s.ProiectId);

            // Configurarea relației many-to-many între Sarcina și MembruEchipa
            modelBuilder.Entity<Sarcina>()
                .HasMany(s => s.MembriEchipa)
                .WithMany(m => m.Sarcini)
                .UsingEntity<Dictionary<string, object>>(
                    "SarcinaMembruEchipa", // Numele tabelului de joncțiune
                    j => j.HasOne<MembruEchipa>().WithMany().HasForeignKey("MembruEchipaId"),
                    j => j.HasOne<Sarcina>().WithMany().HasForeignKey("SarcinaId"),
                    j =>
                    {
                        j.HasKey("SarcinaId", "MembruEchipaId"); // Chei primare compuse pentru tabelul de joncțiune
                    });

            // Configurarea relației one-to-many între Proiect/Sarcina și Comentariu
            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Comentarii)
                .WithOne(c => c.Proiect)
                .HasForeignKey(c => c.ProiectId)
                .OnDelete(DeleteBehavior.Cascade); // Opțional, setează comportamentul de ștergere

            modelBuilder.Entity<Sarcina>()
                .HasMany(s => s.Comentarii)
                .WithOne(c => c.Sarcina)
                .HasForeignKey(c => c.SarcinaId)
                .OnDelete(DeleteBehavior.Cascade); // Opțional, setează comportamentul de ștergere
        }
    }
}