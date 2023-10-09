using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Kontakty.Models
{

    [Table("użytkownik")]
    public partial class Użytkownik
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Nazwisko { get; set; } = null!;

        [StringLength(100)]
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
    }
}

