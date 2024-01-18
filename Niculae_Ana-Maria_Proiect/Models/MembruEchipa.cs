using Niculae_Ana_Maria_Proiect.Models.View;

namespace Niculae_Ana_Maria_Proiect.Models
{
    public class MembruEchipa
    {
        public int MembruEchipaId { get; set; }
        public string Nume { get; set; }
        public List<SarcinaMembruEchipa> SarcinaMembriEchipa { get; set; }
        public MembruEchipa()
        {
            SarcinaMembriEchipa = new List<SarcinaMembruEchipa>();
        }

    }
}
