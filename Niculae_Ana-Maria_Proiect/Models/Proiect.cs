using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace Niculae_Ana_Maria_Proiect.Models
{
    public class Proiect
    {
        public int ProiectId { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Introduceti numele proiectului")]
        public string Nume { get; set; }
        public string? Descriere { get; set; }
        public DateTime? DataIncepere { get; set; }
        public DateTime? DataFinalizare { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Alegeti statusul proiectului")]
        public StatusProiect Status { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Alegeti managerul proiectului")]
        public int ManagerId { get; set; }
        public Manager? ManagerProiect { get; set; }
        public List<Sarcina> Sarcini { get; set; }
        public List<Comentariu> Comentarii { get; set; } // Colecția de comentarii asociate proiectului

        public Proiect()
        {
            Sarcini = new List<Sarcina>();
            Comentarii = new List<Comentariu>();
            Status = StatusProiect.InAsteptare; // Un status inițial, de exemplu "În Așteptare"
        }
    }

    public enum StatusProiect
    {
        InAsteptare,
        InDesfasurare,
        Completat,
        Suspendat
    }


}
