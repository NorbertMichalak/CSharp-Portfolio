using System.Globalization;
using VHS_Movie_Manager2;


    // === Input validation ===
class InputHelper
{
    public static string ReadNonEmpty(string prompt)
    {
        while(true)
        {
            Console.Write(prompt);
            string? s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s))
                return s.Trim();
            Console.WriteLine("Can't be empty.");
        }
    }

    public static int ReadInt(string prompt, int min, int max)
    {
        while(true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
            return value;
            Console.WriteLine($"Enter a number within a range {min}-{max}");
        }
    }

    public static decimal ReadDecimal (string prompt, decimal min, decimal max)
    {
        while(true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Replace(',','.') ?? "";

            if(decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal value)
            && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Enter a number within a range {min}-{max}");
        }
    }

    public static Genre ReadGenre()
    {
        Console.WriteLine("Choice genre:");
        foreach ( int i in Enum.GetValues(typeof(Genre)))
        {
            Console.WriteLine($"{i}) {Enum.GetName(typeof(Genre), i)}");
        }

        int choice = ReadInt(" Your choice: ", 1, Enum.GetValues(typeof(Genre)).Length);
        return (Genre)choice;

    }
}    