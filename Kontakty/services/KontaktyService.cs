using Kontakty.Models;
using Kontakty.DTO;
using System;

namespace Kontakty.services
{
    public class KontaktyService
    {
        private readonly KontaktyDbContext _context;
        public KontaktyService(KontaktyDbContext context)
        {
            _context = context;
        }
        public List<KontaktyImieNazwiskoDTO> PobierzSzczegoly() 
        {
            var kontakty = _context.Kontakts
                    .Select(u => new KontaktyImieNazwiskoDTO
                    {
                        Id = u.Id,
                        imie = u.imie,
                        email = u.email,  
                    })
                    .ToList();
            return kontakty;
        }

        public List<KontaktyDTO> PobierzWszystkieKontakty()
        {
            var kontakty = _context.Kontakts
                .Select(u => new KontaktyDTO
                {
                    Id = u.Id,
                    imie = u.imie,
                    email = u.email,
                    haslo = u.haslo,
                    kategoria = u.kategoria,
                    podkategoria = u.podkategoria,
                    telefon = u.telefon,
                    dataUrodzenia = u.dataUrodzenia
                })
                .ToList();
            return kontakty;
        }

        public KontaktyDTO PobierzKontakt(int id)
        {
            var Kontakt = _context.Kontakts
                .Where(u => u.Id == id)
                .Select(u => new KontaktyDTO
                {
                    Id = u.Id,
                    imie = u.imie,
                    email = u.email,
                    haslo = u.haslo,
                    kategoria = u.kategoria,
                    podkategoria = u.podkategoria,
                    telefon = u.telefon,
                    dataUrodzenia = u.dataUrodzenia
                })
                .FirstOrDefault();
            if (Kontakt == null)
            {
                throw new Exception("Złe id"); // Kontakt o podanym ID nie istnieje.
            }

            return Kontakt;
        }

        public bool AktualizujKontakt(int id, KontaktyDTO kontaktyDTO)
        {
            var kontakt = _context.Kontakts.FirstOrDefault(u => u.Id == id);

            if (kontakt == null)
            {
                throw new Exception("Złe id"); //
                                               //Kontakt o podanym ID nie istnieje.
            }

            // Aktualizujemy dane  na podstawie przekazanego DTO.
            kontakt.imie = kontaktyDTO.imie;
            kontakt.email = kontaktyDTO.email;
            kontakt.haslo = kontaktyDTO.haslo;
            kontakt.kategoria = kontaktyDTO.kategoria;
            kontakt.podkategoria = kontaktyDTO.podkategoria;
            kontakt.telefon = kontaktyDTO.telefon;
            kontakt.dataUrodzenia = kontaktyDTO.dataUrodzenia;

            try
            {
                _context.SaveChanges(); // Zapisujemy zmiany w bazie danych.
                return true; // Aktualizacja zakończyła się sukcesem.
            }
            catch (Exception e)
            {
                // Obsłuż wyjątek, jeśli coś poszło nie tak podczas zapisu do bazy danych.
                throw new Exception("Błąd aktualizacji", e); // Błąd podczas aktualizacji.
            }
        }

        public KontaktyDTO DodajKontakt(KontaktyDTO kontaktyDTO)
        {
            var nowyKontakt = new Kontakt
            {
                imie = kontaktyDTO.imie,
                email = kontaktyDTO.email,
                haslo = kontaktyDTO.haslo,
                kategoria = kontaktyDTO.kategoria,
                podkategoria = kontaktyDTO.podkategoria,
                telefon = kontaktyDTO.telefon,
                dataUrodzenia = kontaktyDTO.dataUrodzenia
            };

            try
            {
                _context.Kontakts.Add(nowyKontakt); // Dodaj nowego  do kontekstu bazy danych.
                _context.SaveChanges(); // Zapisz zmiany w bazie danych.
                kontaktyDTO.Id = nowyKontakt.Id; // Ustaw ID nowego  w DTO.
                return kontaktyDTO;
            }
            catch (Exception e)
            {
                // Obsłuż wyjątek, jeśli coś poszło nie tak podczas dodawania .
                throw new Exception("Wystąpił błąd podczas dodawania.", e);
            }
        }

        public bool UsunKontakt(int id)
        {
            var kontakt = _context.Kontakts.FirstOrDefault(u => u.Id == id);

            if (kontakt == null)
            {
                throw new Exception("Złe id "); // Kontakt o podanym ID nie istnieje.
            }

            try
            {
                _context.Kontakts.Remove(kontakt); // Usuwamy kontakt z kontekstu bazy danych.
                _context.SaveChanges(); // Zapisujemy zmiany w bazie danych.
                return true; // Usunięcie zakończyło się sukcesem.
            }
            catch (Exception e)
            {
                // Obsłuż wyjątek, jeśli coś poszło nie tak podczas usuwania.
                throw new Exception("Błąd podczas usuwania", e); // Błąd podczas usuwania.
            }

        }
    }
}
