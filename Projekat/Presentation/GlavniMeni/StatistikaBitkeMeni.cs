using Domain.Servisi;
using Services.BitkaServisi;

public class StatistikaBitkeMeni
{
    public static void StatistikaBitke(int idProdavnice, string nazivMape)
    {
        bool validInput = false;
        IGeneratorStatistikeBitkeServis gbs = new GeneratorStatistikeBitkeServis();
        IStatistikaBitkeServis sbs = new StatistikaBitkeServis(gbs);

        Console.WriteLine("\nThe battle has ended. Please enter:");
        Console.WriteLine("1 - To view statistics in this window");
        Console.WriteLine("2 - To save statistics to a .txt file");

        while (!validInput)
        {
            string input = Console.ReadLine();
            if (input != "1" && input != "2")
            {
                Console.WriteLine("Invalid input! Please enter either 1 or 2.");
                continue;
            }
            validInput = true;

            if (input == "1")
            {
                string output = sbs.IspisiNaEkran(nazivMape, idProdavnice);
                Console.WriteLine("\n" + output);
            }
            else
            {
                Console.WriteLine("Please enter the filename to save the statistics (with .txt extension):");
                string fileName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(fileName))
                {
                    Console.WriteLine("Invalid filename. Operation aborted.");
                    validInput = false; // Ponovo tražimo unos
                    continue;
                }

                try
                {
                    sbs.IspisiUDatoteku(nazivMape, idProdavnice, fileName);
                    Console.WriteLine($"Statistics successfully saved to '{fileName}'.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving file: {ex.Message}");
                }
            }
        }
    }
}
