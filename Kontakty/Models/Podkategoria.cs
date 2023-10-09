using System.ComponentModel.DataAnnotations.Schema;

namespace Kontakty.Models
{
    [Table("podkategorie")]

    public class Podkategoria
    { 
            public int Id { get; set; }
            public string nazwa { get; set; }
        public int id_kategorii { get; set; }

    }
}
