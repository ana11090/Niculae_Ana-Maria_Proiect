using Niculae_Ana_Maria_Proiect.Models;
using System;
using Microsoft.EntityFrameworkCore;
using Niculae_Ana_Maria_Proiect.Models.View;

namespace Niculae_Ana_Maria_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                // Check if there are already projects in the database
                if (context.Proiecte.Any())
                {
                    return; // The database has already been initialized
                }

                // Create some managers
                var manager1 = new Manager { Nume = "Ion Popescu" };
                var manager2 = new Manager { Nume = "Maria Ionescu" };

                // Add managers to the context
                context.Manageri.AddRange(manager1, manager2);
                context.SaveChanges();

                // Create some projects
                var proiect1 = new Proiect { Nume = "Proiectul A", ManagerId = manager1.ManagerId };
                var proiect2 = new Proiect { Nume = "Proiectul B", ManagerId = manager2.ManagerId };

                // Add projects to the context
                context.Proiecte.AddRange(proiect1, proiect2);
                context.SaveChanges();

                // Create team members
                var membru1 = new MembruEchipa { Nume = "Andrei Georgescu" };
                var membru2 = new MembruEchipa { Nume = "Elena Vasilescu" };

                // Add team members to the context
                context.MembriEchipa.AddRange(membru1, membru2);
                context.SaveChanges();

                // Create tasks and associate them with projects
                var sarcina1 = new Sarcina { Descriere = "Analiza cerințe", ProiectId = proiect1.ProiectId };
                var sarcina2 = new Sarcina { Descriere = "Dezvoltare funcționalități", ProiectId = proiect2.ProiectId };

                // Add tasks to the context
                context.Sarcini.AddRange(sarcina1, sarcina2);
                context.SaveChanges();

                // Associate team members with tasks (many-to-many)
                sarcina1.SarcinaMembriEchipa.Add(new SarcinaMembruEchipa { Sarcina = sarcina1, MembruEchipa = membru1 });
                sarcina2.SarcinaMembriEchipa.Add(new SarcinaMembruEchipa { Sarcina = sarcina2, MembruEchipa = membru2 });

                // Save all changes to the database
                context.SaveChanges();
            }
        }

    }
}

