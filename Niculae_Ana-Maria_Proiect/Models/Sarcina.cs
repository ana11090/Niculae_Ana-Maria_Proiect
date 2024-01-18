using Niculae_Ana_Maria_Proiect.Models.View;

namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Sarcina
    {
        public int SarcinaId { get; set; }
        public string Descriere { get; set; }
        public DateTime? DataIncepere { get; set; }
        public DateTime? DataFinalizare { get; set; }
        public StatusSarcina Status { get; set; }
        public int ProiectId { get; set; } // Cheie străină pentru Proiect
        public Proiect? ProiectAsociat { get; set; } // Proprietatea de navigație

        public List<Comentariu> Comentarii { get; set; } // Colecția de comentarii asociate sarcinii

        public List<SarcinaMembruEchipa> SarcinaMembriEchipa { get; set; } // Pentru relația many-to-many cu membrii echipei

        public Sarcina()
        {
            Status = StatusSarcina.Neinceputa; // Un status inițial, de exemplu "Neîncepută"
            SarcinaMembriEchipa = new List<SarcinaMembruEchipa>(); // Inițializăm lista many-to-many cu o listă goală
        }
    }

    public enum StatusSarcina
    {
        Neinceputa,
        InDesfasurare,
        Finalizata
    }

}
