using Domain.Servisi;
using Services.AuthServisi;
using System;

namespace Presentation.GlavniMeni
{
    public class AuthMeni
    {
        public AuthMeni() { }

        public static void Autentifikacija()
        {
            IAuthServis auth = new AuthServis();
            bool loggedIn = false;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("===========================================");
            Console.WriteLine("          WELCOME TO THE APPLICATION        ");
            Console.WriteLine("===========================================\n");
            Console.ResetColor();

            while (!loggedIn)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Username: ");
                Console.ResetColor();
                string username = Console.ReadLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Password: ");
                Console.ResetColor();
                string password = Console.ReadLine();

                Console.WriteLine();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a valid username and password.\n");
                    Console.ResetColor();
                    continue;
                }

                if (auth.Autentifikacija(username, password))
                {
                    loggedIn = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Login successful! Welcome, {0}.\n", username);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Authentication failed! Please check your username and password.\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
