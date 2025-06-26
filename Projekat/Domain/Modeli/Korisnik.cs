using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeli
{
    public class Korisnik
    {
        private string Username { get; set; } = string.Empty;
        private string Password { get; set; } = string.Empty;
        public Korisnik() { }
        public Korisnik(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public string getUsername()
        {
            return this.Username;
        }
        public string getPassword()
        {
            return this.Password;
        }
    }
}
