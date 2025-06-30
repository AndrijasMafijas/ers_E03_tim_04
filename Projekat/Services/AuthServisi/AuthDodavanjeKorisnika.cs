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
        IKorisnickiRepository korisnickiRepository = new KorisnickiRepository();
        public bool dodajKorisnika(string username, string password)
        {
            return korisnickiRepository.DodajKorisnika(username, password);
        }
    }
}
