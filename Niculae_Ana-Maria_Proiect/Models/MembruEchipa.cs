namespace Niculae_Ana_Maria_Proiect.Models
{
    public class MembruEchipa
    {
        public int MembruEchipaId { get; set; }
        public string Nume { get; set; }
        public List<Sarcina> Sarcini { get; set; }

        public MembruEchipa()
        {
            Sarcini = new List<Sarcina>();
        }
    }

}
