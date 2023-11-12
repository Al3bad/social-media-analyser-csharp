public class UI
{
    public static void Heading(string title, int width = 70)
    {
        Console.WriteLine();
        Console.WriteLine("".PadRight(width, '-'));
        Console.WriteLine($"> {title}");
        Console.WriteLine("".PadRight(width, '-'));
    }

    /**
     * @brief Print menu with all its controls
     *
     * @tparam TEnum type of options
     * @param options list of options
     * @param callback callback function when the user selects an option (by pressing enter)
     * @return void
     */
    public static void Menu<TEnum>(List<Option<TEnum>> options, Action<TEnum> callback)
        where TEnum : Enum
    {
        // initial value of selected option
        int selectedOption = 0;

        while (true)
        {
            // clear screen
            Console.Clear();
            // print menu
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedOption)
                {
                    Console.WriteLine($"> {options[i].Label}");
                }
                else
                {
                    Console.WriteLine($"  {options[i].Label}");
                }
            }
            // take user intput
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            // take action based on input
            if (keyInfo.Key == ConsoleKey.UpArrow)
            {
                selectedOption = Math.Max(0, selectedOption - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow)
            {
                selectedOption = Math.Min(options.Count - 1, selectedOption + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                callback(options[selectedOption].EOption);
                return;
            }
        }
    }
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
