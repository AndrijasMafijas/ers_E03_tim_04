using Domain.Modeli;
using Domain.Servisi;
using Services.BitkaServisi;
using System;

namespace Presentation.GlavniMeni
{
    public class TimoviMeni
    {
        public TimoviMeni() { }

        public static void DodavanjeIgraca()
        {
            bool validInput = false;
            int playerCount = 0;

            // Ask for number of players per team
            while (!validInput)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("=======================================");
                Console.WriteLine("   ENTER NUMBER OF PLAYERS PER TEAM   ");
                Console.WriteLine("=======================================\n");
                Console.ResetColor();

                Console.Write("Please enter how many players each team will contain (between 1 and 5): ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out playerCount) && playerCount >= 1 && playerCount <= 5)
                {
                    validInput = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid number! Please enter a number between 1 and 5.\n");
                    Console.ResetColor();
                }
            }

            ITimoviServis teamService = new TimoviServis();
            IHerojiServis heroService = new HerojiServis();

            Console.WriteLine("\nAvailable heroes:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(heroService.IspisiListuHeroja());
            Console.ResetColor();

            // Add players to Blue Team
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nNow entering players and heroes for the BLUE team:\n");
            Console.ResetColor();

            for (int i = 0; i < playerCount;)
            {
                Console.Write($"Player #{i + 1} name: ");
                string playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName) || playerName.Length > 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid name! Name must be non-empty and up to 15 characters.\n");
                    Console.ResetColor();
                    continue;
                }

                Console.Write($"Player #{i + 1} hero: ");
                string heroName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(heroName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero name cannot be empty.\n");
                    Console.ResetColor();
                    continue;
                }

                Guid heroId = heroService.PronadjiHeroja(heroName);

                if (heroId == Guid.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero not found! Please enter an existing hero name.\n");
                    Console.ResetColor();
                    continue;
                }

                if (heroService.PronadjiHeroja(heroId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero already picked by another player. Choose a different hero.\n");
                    Console.ResetColor();
                    continue;
                }

                teamService.DodavanjeIgracaUPlaviTim(new Igrac(playerName, heroId));
                i++;
            }

            // Add players to Red Team
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nNow entering players and heroes for the RED team:\n");
            Console.ResetColor();

            Console.WriteLine("Available heroes:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(heroService.IspisiListuHeroja());
            Console.ResetColor();

            for (int i = 0; i < playerCount;)
            {
                Console.Write($"Player #{i + 1} name: ");
                string playerName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(playerName) || playerName.Length > 15)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid name! Name must be non-empty and up to 15 characters.\n");
                    Console.ResetColor();
                    continue;
                }

                Console.Write($"Player #{i + 1} hero: ");
                string heroName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(heroName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero name cannot be empty.\n");
                    Console.ResetColor();
                    continue;
                }

                Guid heroId = heroService.PronadjiHeroja(heroName);

                if (heroId == Guid.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero not found! Please enter an existing hero name.\n");
                    Console.ResetColor();
                    continue;
                }

                if (heroService.PronadjiHeroja(heroId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hero already picked by another player. Choose a different hero.\n");
                    Console.ResetColor();
                    continue;
                }

                teamService.DodavanjeIgracaUCrveniTim(new Igrac(playerName, heroId));
                i++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nTeams have been successfully created!\n");
            Console.ResetColor();
        }
    }
}
