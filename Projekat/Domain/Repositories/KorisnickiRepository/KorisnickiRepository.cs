using Domain.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.KorisnickiRepository
{
    public class KorisnickiRepository : IKorisnickiRepository
    {
        private static List<Korisnik> Korisnici { get; set; } = new List<Korisnik>();

        static KorisnickiRepository()
        {
            Korisnici = new List<Korisnik>
            {
                new Korisnik("andrija","andrija"),
                new Korisnik("stefan","stefan")
            };
        }

        public bool PronadjiKorisnika(string username,string password)
        {
            Korisnik? korisnik = Korisnici.FirstOrDefault((h) => ((h.getUsername() == username) && (h.getPassword() == password)) );
            if (korisnik == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool DodajKorisnika(string username, string password) 
        {
            if(username != null && password != null)
            {
                foreach (Korisnik k in Korisnici)
                {
                    if (k.getUsername() == username)
                        return false;
                }
                Korisnici.Add(new Korisnik(username, password));
            }
            return false;
        }
    }
}
