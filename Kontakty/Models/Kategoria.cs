using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kontakty.Models
{
    [Table("kategorie")]
    public class Kategoria
    {
        public int Id { get; set; }
        public string nazwa { get; set; }
    }
}


