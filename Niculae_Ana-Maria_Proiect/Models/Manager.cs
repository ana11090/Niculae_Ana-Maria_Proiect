namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Manager
    {
        public int ManagerId { get; set; }
        public string Nume { get; set; }
        public List<Proiect> Proiecte { get; set; }

        public Manager()
        {
            Proiecte = new List<Proiect>();
        }
    }

}
