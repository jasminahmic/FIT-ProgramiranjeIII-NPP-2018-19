﻿using DLWMS.WinForms.III;
using DLWMS.WinForms.IV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLWMS.WinForms.I
{
    public class InMemoryDB
    {
        public static List<Korisnik> Korisnici { get; set; }
        public static List<Student> Studenti { get; set; }
        public static List<Spol> Spolovi { get; set; }
        public static List<Predmet> NPP { get; set; }

        static InMemoryDB()
        {
            Korisnici = new List<Korisnik>();
            Studenti = new List<Student>();
            Spolovi = new List<Spol>();
            NPP = new List<Predmet>();
            UcitajBuildInKorisnike();
            UcitajBuildInStudente();
            UcitajSpolove();
            UcitajPredmete();
        }

        private static void UcitajPredmete()
        {
            NPP.Add(new Predmet() { Id = 1, Naziv = "Programiranje I" });
            NPP.Add(new Predmet() { Id = 2, Naziv = "Operativni sistemi" });
            NPP.Add(new Predmet() { Id = 3, Naziv = "Matematika" });
            NPP.Add(new Predmet() { Id = 4, Naziv = "Marketing" });
        }

        private static void UcitajSpolove()
        {
            Spolovi.Add(new Spol() { Id = 1, Naziv = "*****" });
            Spolovi.Add(new Spol() { Id = 2, Naziv = "Ženski" });
            Spolovi.Add(new Spol() { Id = 3, Naziv = "Muški" });
        }

        private static void UcitajBuildInStudente()
        {
            Studenti.Add(new Student()
            {
                Id = 1,
                Ime = "Goran",
                Prezime = "Skondric",
                DatumRodjenja = DateTime.Now,
                Email = "goran@edu.fit.ba",
                Indeks = "IB200064",
                GodinaStudija = 1,
                Aktivan = true
            });
        }

        private static void UcitajBuildInKorisnike()
        {
            Korisnici.Add(new Korisnik()
            {
                Id = 1,
                Ime = "Denis",
                Prezime = "Music",
                DatumRodjenja = DateTime.Now,
                KorisnickoIme = "denis",
                Lozinka = "denis",
                Aktivan = true
            });

            Korisnici.Add(new Korisnik()
            {
                Id = 2,
                Ime = "Jasmin",
                Prezime = "Azemovic",
                DatumRodjenja = DateTime.Now,
                KorisnickoIme = "jasmin",
                Lozinka = "jasmin",
                Aktivan = true
            });
        }
    }
}
