using Domain.Repositories.KorisnickiRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServisi
{
    public class AuthDodavanjeKorisnika
    {
        public bool dodajKorisnika(string username, string password)
        {
            IKorisnickiRepository korisnickiRepository = new KorisnickiRepository();
            return korisnickiRepository.DodajKorisnika(username, password);
        }
    }
}
