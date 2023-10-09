using System.ComponentModel.DataAnnotations;

namespace Kontakty.DTO
{
    public class KontaktyDTO
    {
        public int Id { get; set; }
        public string imie { get; set; }
        public string email { get; set; }
        public string haslo { get; set; }
        public string kategoria { get; set; }
        public string podkategoria { get; set; }
        public int telefon { get; set; }
        public DateTime dataUrodzenia { get; set; }
    }
}
