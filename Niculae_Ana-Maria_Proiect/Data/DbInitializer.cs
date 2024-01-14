using Niculae_Ana_Maria_Proiect.Models;
using System;
using Microsoft.EntityFrameworkCore;

namespace Niculae_Ana_Maria_Proiect.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LibraryContext(serviceProvider.GetRequiredService<DbContextOptions<LibraryContext>>()))
            {
                // Verifică dacă există deja proiecte în baza de date
                if (context.Proiecte.Any())
                {
                    return; // Baza de date a fost deja inițializată
                }

                // Crează câțiva manageri
                var manager1 = new Manager { Nume = "Ion Popescu" };
                var manager2 = new Manager { Nume = "Maria Ionescu" };

                // Adaugă managerii în context
                context.Manageri.AddRange(manager1, manager2);
                context.SaveChanges();

                // Crează câteva proiecte
                var proiect1 = new Proiect { Nume = "Proiectul A", ManagerId = manager1.ManagerId };
                var proiect2 = new Proiect { Nume = "Proiectul B", ManagerId = manager2.ManagerId };

                // Adaugă proiectele în context
                context.Proiecte.AddRange(proiect1, proiect2);
                context.SaveChanges();

                // Crează membri ai echipei
                var membru1 = new MembruEchipa { Nume = "Andrei Georgescu" };
                var membru2 = new MembruEchipa { Nume = "Elena Vasilescu" };

                // Adaugă membrii echipei în context
                context.MembriEchipa.AddRange(membru1, membru2);
                context.SaveChanges();

                // Crează sarcini și asociază-le cu proiecte
                var sarcina1 = new Sarcina { Descriere = "Analiza cerințe", ProiectId = proiect1.ProiectId };
                var sarcina2 = new Sarcina { Descriere = "Dezvoltare funcționalități", ProiectId = proiect2.ProiectId };

                // Adaugă sarcinile în context
                context.Sarcini.AddRange(sarcina1, sarcina2);
                context.SaveChanges();

                // Asociază membrii echipei cu sarcini (many-to-many)
                sarcina1.MembriEchipa.Add(membru1);
                sarcina2.MembriEchipa.Add(membru2);

                // Salvează toate modificările în baza de date
                context.SaveChanges();
            }
        }

    }
}

