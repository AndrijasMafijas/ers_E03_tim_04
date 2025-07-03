using Domain.Modeli;
using Domain.PomocneMetode;
using Domain.Servisi;
using Services.BitkaServisi;
using Services.ProdavnicaServisi;
using System;

namespace Presentation.GlavniMeni
{
    public class MapaMeni
    {
        public MapaMeni() { }

        public static int OdabirMape(int brojEntiteta, ref string mapName)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=======================================");
            Console.WriteLine("        MAP SELECTION MENU             ");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            int marketId = 0;
            bool validInput = false;
            Prodavnica store;
            Mapa map;

            // Map name input
            while (!validInput)
            {
                Console.Write("Enter map name: ");
                string inputMapName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(inputMapName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Map name cannot be empty. Please try again.\n");
                    Console.ResetColor();
                    continue;
                }

                map = PronadjiMapu.PronadjiMapuPoNazivu(inputMapName);

                if (map.NazivMape == string.Empty)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Map '{inputMapName}' doesn't exist. Please enter a valid map name.\n");
                    Console.ResetColor();
                    continue;
                }

                mapName = map.NazivMape;
                validInput = true;
            }

            validInput = false;

            // Market ID input
            while (!validInput)
            {
                Console.Write("Enter market ID: ");
                string inputMarketId = Console.ReadLine();
                int parsedId;

                if (string.IsNullOrWhiteSpace(inputMarketId) || !int.TryParse(inputMarketId, out parsedId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Please enter a valid numeric market ID.\n");
                    Console.ResetColor();
                    continue;
                }

                store = PronadjiProdavnicu.PronadjiProdavnicuPoIdu(parsedId);

                if (store.ID == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Market with ID {inputMarketId} doesn't exist. Please try again.\n");
                    Console.ResetColor();
                    continue;
                }

                marketId = store.ID;
                validInput = true;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nYou have selected map: {mapName} with market ID: {marketId}.\n");
            Console.ResetColor();

            return marketId;
        }
    }
}
