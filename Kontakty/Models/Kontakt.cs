using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kontakty.Models
{
    [Table("Kontakt")]
    [Microsoft.EntityFrameworkCore.Index("email", Name = "UniqEmailInKontakt", IsUnique = true)]
    public class Kontakt
    {
        public int Id { get; set; }
        public string imie {get ; set;}
        public string email { get ; set;}  
        public string haslo { get; set;} 
        public string kategoria { get; set;}
        public string podkategoria { get; set;}
        [MaxLength(9)]
        public int telefon { get; set;}
        public DateTime dataUrodzenia { get; set;}
    }
}

