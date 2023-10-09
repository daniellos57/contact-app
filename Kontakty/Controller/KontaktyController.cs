using Kontakty.DTO;
using Kontakty.Models;
using Kontakty.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Kontakty.Controller
{
    [Route("api/Kontakty")]
    [ApiController]
    public class KontaktyController : ControllerBase
    {
        //private readonly KontaktyDbContext _context;
        private readonly KontaktyService _KontaktyService;
        private readonly KontaktyDbContext _context;

        public KontaktyController(KontaktyService kontaktyService, KontaktyDbContext context)
        {
            _context = context;
            _KontaktyService = kontaktyService;
        }


        [HttpGet]
        public ActionResult<IEnumerable<KontaktyImieNazwiskoDTO>> PobierzSzczegoly()
        {
            return Ok(_KontaktyService.PobierzSzczegoly());
        }

        [HttpGet("szczegoly")]
        public ActionResult<IEnumerable<KontaktyDTO>> PobierzWszystkieKontakty()
        {
            return Ok(_KontaktyService.PobierzWszystkieKontakty());
        }



        [HttpGet("{id}")]
        public ActionResult<KontaktyDTO> PobierzKontakt(int id)
        {
            return Ok(_KontaktyService.PobierzKontakt(id));
        }

        [HttpPost]
        public IActionResult DodajKontakt(KontaktyDTO kontaktyDTO)
        {

            var createdKontakt = _KontaktyService.DodajKontakt(kontaktyDTO);

            return CreatedAtAction(nameof(DodajKontakt), new { id = createdKontakt.Id }, createdKontakt);


        }

        [HttpPut("{id}")]
        public IActionResult AktualizujKontakt(int id, KontaktyDTO kontaktyDTO)
        {
            var isUpdated = _KontaktyService.AktualizujKontakt(id, kontaktyDTO);

            return Ok(); // Jeśli aktualizacja zakończyła się sukcesem, zwracamy 204 No Content.
        }

        [HttpDelete("{id}")]
        public IActionResult UsunKontakt(int id)
        {
            var isDeleted = _KontaktyService.UsunKontakt(id);

            return Ok();
        }
        //ze wzgledu na zbyt malo czasu nie daje juz tego do service
        [HttpGet("kategorie")]
        public IActionResult GetKategorie()
        {
            var kategorie = _context.Kategorias.Select(k => k.nazwa).ToList();
            return Ok(kategorie);
        }

        [HttpGet("podkategorie/{kategoriaId}")]
        public IActionResult GetPodkategorie(int kategoriaId)
        {
            var podkategorie = _context.Podkategorias
                .Where(p => p.id_kategorii == kategoriaId)
                .Select(p => p.nazwa)
                .ToList();

            return Ok(podkategorie);
        }

        [HttpGet("kategorie/{nazwaKategorii}")]
        public IActionResult GetKategoriaId(string nazwaKategorii)
        {
            var kategoria = _context.Kategorias
                .SingleOrDefault(k => k.nazwa == nazwaKategorii);

            if (kategoria == null)
            {
                return NotFound(); // Zwróć błąd 404 jeśli kategoria nie została znaleziona
            }

            return Ok(kategoria.Id);
        }
    }
}
