using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Niculae_Ana_Maria_Proiect.Models;
using Niculae_Ana_Maria_Proiect.Models.View;

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
        {// Configurarea relației one-to-many între Manager și Proiect
            modelBuilder.Entity<Manager>()
                .HasMany(m => m.Proiecte)
                .WithOne(p => p.ManagerProiect)
                .HasForeignKey(p => p.ManagerId);

            // Configurarea relației one-to-many între Proiect și Sarcina
            modelBuilder.Entity<Proiect>()
                .HasMany(p => p.Sarcini)
                .WithOne(s => s.ProiectAsociat)
                .HasForeignKey(s => s.ProiectId);

            modelBuilder.Entity<SarcinaMembruEchipa>()
              .HasKey(sm => new { sm.SarcinaId, sm.MembruEchipaId });

            modelBuilder.Entity<SarcinaMembruEchipa>()
                .HasOne(sm => sm.Sarcina)
                .WithMany(s => s.SarcinaMembriEchipa)
                .HasForeignKey(sm => sm.SarcinaId);

            modelBuilder.Entity<SarcinaMembruEchipa>()
                .HasOne(sm => sm.MembruEchipa)
                .WithMany(m => m.SarcinaMembriEchipa)
                .HasForeignKey(sm => sm.MembruEchipaId);

            modelBuilder.Entity<Comentariu>()
                .HasOne(c => c.Proiect)
                .WithMany(p => p.Comentarii)
                .HasForeignKey(c => c.ProiectId);

            modelBuilder.Entity<Comentariu>()
                .HasOne(c => c.Sarcina)
                .WithMany(s => s.Comentarii)
                .HasForeignKey(c => c.SarcinaId);
        }

    }


}