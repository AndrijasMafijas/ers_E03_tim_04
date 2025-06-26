using Services.AuthServisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.GlavniMeni
{
    public class AuthMeni
    {
        public AuthMeni() { }
        public static void Autentifikacija()
        {
            AuthServis auth = new AuthServis();
            bool ulogovan = false;
            Console.WriteLine("Welcome!");
            //testiranje (radi)
            Console.WriteLine("For testing purposes please add 1 user first since we don't have DB...");
            bool dobarUnos = false;
            while (!dobarUnos)
            {
                Console.WriteLine("Create Username: ");
                string createdUsername = Console.ReadLine();
                Console.WriteLine("Create Password: ");
                string createdPassword = Console.ReadLine();
                if (createdUsername != string.Empty && createdPassword != string.Empty)
                {
                    dobarUnos = true;
                    AuthDodavanjeKorisnika authDodavanje = new AuthDodavanjeKorisnika();
                    authDodavanje.dodajKorisnika(createdUsername, createdPassword);
                } else
                {
                    Console.WriteLine("Please enter valid username and password");
                }
            }

            while (!ulogovan)
            {
                Console.WriteLine("Please enter your username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter your password: ");
                string password = Console.ReadLine();

                if (auth.Autentifikacija(username, password))
                {
                    ulogovan = true;
                    Console.WriteLine("Login successful!");
                }
                else
                {
                    Console.WriteLine("\nPlease enter valid username and password.\n");
                }
            }
        }
    }
}
