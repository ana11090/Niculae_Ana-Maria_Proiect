namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Comentariu
    {
        public int ComentariuId { get; set; }
        public string Text { get; set; }
        public DateTime DataOra { get; set; }
        public int AutorId { get; set; } // Presupunând că avem o clasă de utilizator
        public int? ProiectId { get; set; } // Nullable, deoarece un comentariu poate să nu fie legat de un proiect
        public int? SarcinaId { get; set; } // Nullable, deoarece un comentariu poate să nu fie legat de o sarcină

        // Relații cu alte clase (dacă folosiți Entity Framework)
        public virtual Proiect? Proiect { get; set; }
        public virtual Sarcina? Sarcina { get; set; }
        //public virtual Utilizator Autor { get; set; }
    }

}
