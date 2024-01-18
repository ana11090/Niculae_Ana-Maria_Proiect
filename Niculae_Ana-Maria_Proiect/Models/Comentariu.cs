namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Comentariu
    {
        public int ComentariuId { get; set; }
        public string Text { get; set; }
        public DateTime DataOra { get; set; }
        public int AutorId { get; set; }

        public int? ProiectId { get; set; }
        public Proiect Proiect { get; set; }

        public int? SarcinaId { get; set; }
        public Sarcina Sarcina { get; set; }

        // Adăugați aici și orice alte relații necesare cu alte entități, dacă există.

        // Constructorul implicit
        public Comentariu()
        {
            // Inițializare a proprietăților sau alte acțiuni necesare.
        }
    }


}
