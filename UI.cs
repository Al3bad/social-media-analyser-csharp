public class UI
{
    public static void Heading(string title, int width = 70)
    {
        Console.WriteLine();
        Console.WriteLine("".PadRight(width, '-'));
        Console.WriteLine($"> {title}");
        Console.WriteLine("".PadRight(width, '-'));
    }

    public static void Menu(List<string> options, int selectedOptionIdx)
    {
        for (int i = 0; i < options.Count; i++)
        {
            if (i == selectedOptionIdx)
            {
                Console.WriteLine($"> {options[i]}");
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
    }

    public static void Prompt(string prompt)
    {
        Console.Write($"{prompt}: ");
    }
}
