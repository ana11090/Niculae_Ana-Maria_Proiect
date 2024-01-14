namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Sarcina
    {
        //public int SarcinaId { get; set; }
        //public string Descriere { get; set; }
        //public DateTime DataIncepere { get; set; }
        //public DateTime? DataFinalizare { get; set; }
        //public StatusSarcina Status { get; set; }
        //public int ProiectId { get; set; }
        //public Proiect ProiectAsociat { get; set; }
        //public MembruEchipa MembruResponsabil { get; set; }
        public int SarcinaId { get; set; }
        public string Descriere { get; set; }
        public DateTime? DataIncepere { get; set; }
        public DateTime? DataFinalizare { get; set; }
        public StatusSarcina Status { get; set; }
        public int ProiectId { get; set; } // Cheie străină pentru Proiect
        public Proiect? ProiectAsociat { get; set; } // Proprietatea de navigație

        public List<Comentariu> Comentarii { get; set; } // Colecția de comentarii asociate sarcinii

        public List<MembruEchipa> MembriEchipa { get; set; } // Pentru relația many-to-many

        public Sarcina()
        {
            Status = StatusSarcina.Neinceputa; // Un status inițial, de exemplu "Neîncepută"
            MembriEchipa = new List<MembruEchipa>();
        }
    }

    public enum StatusSarcina
    {
        Neinceputa,
        InDesfasurare,
        Finalizata
    }

}
