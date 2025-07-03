using Domain.PomocneMetode;
using System;

namespace Presentation.GlavniMeni
{
    public class EntitetMeni
    {
        EntitetMeni() { }

        public static int OdabirEntiteta()
        {
            bool validChoice = false;

            while (!validChoice)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========================================");
                Console.WriteLine("        ENTITY SELECTION MENU           ");
                Console.WriteLine("========================================\n");
                Console.ResetColor();

                Console.WriteLine("Enter 1 to manually enter entities, or 2 to generate them automatically.");

                Console.ForegroundColor = ConsoleColor.Yellow;
                string input = Console.ReadLine();
                Console.ResetColor();

                int choice;

                if (!string.IsNullOrWhiteSpace(input) && int.TryParse(input, out choice))
                {
                    if (choice == 1 || choice == 2)
                    {
                        validChoice = true;

                        if (choice == 2)
                        {
                            int generatedCount = GeneratorEntiteta.GenerisiBrojEntiteta();

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nRandomly generated {generatedCount} entities.\n");
                            Console.ResetColor();

                            return generatedCount;
                        }
                        else
                        {
                            while (true)
                            {
                                Console.WriteLine("Please enter the number of entities (between 1 and 10):");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                string manualInput = Console.ReadLine();
                                Console.ResetColor();

                                int manualCount;

                                if (!string.IsNullOrWhiteSpace(manualInput)
                                    && int.TryParse(manualInput, out manualCount)
                                    && manualCount >= 1
                                    && manualCount <= 10)
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"\nYou entered {manualCount} entities.\n");
                                    Console.ResetColor();

                                    return manualCount;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Invalid input! Please enter a number between 1 and 10.\n");
                                    Console.ResetColor();
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter only 1 or 2.\n");
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Please enter a valid number.\n");
                    Console.ResetColor();
                }
            }

            return 0;
        }
    }
}
