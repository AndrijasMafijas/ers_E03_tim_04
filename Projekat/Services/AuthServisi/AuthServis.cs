using Domain.Repositories.KorisnickiRepository;
using Domain.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AuthServisi
{
    public class AuthServis : IAuthServis
    {
        IKorisnickiRepository korisnickiRepository = new KorisnickiRepository();
        public AuthServis() { }
        public bool Autentifikacija(string username,string password) {
            bool ulogovan = false;
            if (korisnickiRepository.PronadjiKorisnika(username, password)) ulogovan = true;
            return ulogovan;
        }
    }
}
