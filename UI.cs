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
            // take user input
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

    public static void Form(List<IField> fields, Action<List<IField>> callback)
    {
        // initial value of selected option
        int selectedField = 0;
        while (true)
        {
            // clear screen
            Console.Clear();
            // print form with typed values so far
            for (int i = 0; i < fields.Count; i++)
            {
                if (i == selectedField)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write("  ");
                }
                Console.WriteLine($"{fields[i].Label, -10}: {fields[i].Value}");
            }
            // take user input
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            // take action based on input
            if (keyInfo.Key == ConsoleKey.UpArrow || (keyInfo.Modifiers.HasFlag(ConsoleModifiers.Shift) && keyInfo.Key == ConsoleKey.Tab))
            {
                selectedField = Math.Max(0, selectedField - 1);
            }
            else if (keyInfo.Key == ConsoleKey.DownArrow || keyInfo.Key == ConsoleKey.Tab)
            {
                selectedField = Math.Min(fields.Count - 1, selectedField + 1);
            }
            else if (keyInfo.Key == ConsoleKey.Enter)
            {
                bool isValid = true;
                foreach (IField field in fields)
                {
                    try
                    {
                        _ = field.ParsedValue;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine($"Invalid value for {field.Label}");
                        isValid = false;
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine("Form is not valid! Hit enter to try again...");
                    _ = Console.ReadLine();
                }
                else
                {
                    callback(fields);
                    return;
                }
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                // Delete one character from the selected field if it's not empty
                if (fields[selectedField].Value.Length > 0)
                {
                    fields[selectedField].Value = fields[selectedField].Value.Substring(
                        0,
                        fields[selectedField].Value.Length - 1
                    );
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                callback(null);
                return;
            }
            else
            {
                // Edit the selected field
                Console.SetCursorPosition(fields[selectedField].Value.Length + 2, selectedField);
                fields[selectedField].Value += keyInfo.KeyChar.ToString();
            }
        }
    }

    public static T? Prompt<T>(string prompt, Func<string, T> parsor) where T : struct, IEquatable<T> // allow int,double and strings
    {
        string value = "";
        while (true)
        {
            Console.Clear();
            Console.Write($"{prompt}: {value}");
            // take user input
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            // take action based on input
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                try
                {
                    Console.Clear();
                    return parsor(value);
                }
                catch (Exception)
                {
                    Console.WriteLine($"Invalid value! Hit enter to try again...");
                    _ = Console.ReadLine();
                }
            }
            else if (keyInfo.Key == ConsoleKey.Escape)
            {
                return null;
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (value.Length > 0)
                {
                    value = value.Substring(0, value.Length - 1);
                }
            }
            else
            {
                Console.SetCursorPosition(value.Length + 2, 0);
                value += keyInfo.KeyChar.ToString();
            }
        }
    }

    public static void Table(List<string> headings, List<Post> records)
    {
        // Example
        // | ID | Date/Time        | Author   | Likes | Shares | Content     |
        // |----|------------------|----------|-------|--------|-------------|
        // | 10 | 12/12/2012 12:12 | username | 123   | 321    | Message 1   |
        // | 20 | 12/12/2012 12:12 | username | 123   | 321    | Hello World |

        // Calculate column widths based on headings and post data
        List<int> columnWidths = CalculateColumnWidths(headings, records);
        // Print the table header
        PrintTableLine(columnWidths);
        PrintTableRow(headings, columnWidths);
        PrintTableLine(columnWidths);
        // Print the table data
        foreach (Post post in records)
        {
            List<string> rowData =
            [
                post.ID.ToString(),
                post.DateTime.ToString(),
                post.Author,
                post.Likes.ToString(),
                post.Shares.ToString(),
                post.Content
            ];

            PrintTableRow(rowData, columnWidths);
        }
        // Print the table footer
        PrintTableLine(columnWidths);
    }

    private static List<int> CalculateColumnWidths(List<string> headings, List<Post> records)
    {
        List<int> columnWidths = headings.Select(h => h.Length).ToList();

        foreach (Post record in records)
        {
            for (int i = 0; i < headings.Count; i++)
            {
                int cellLength = record.GetColumnValue(i).Length;
                if (cellLength > columnWidths[i])
                {
                    columnWidths[i] = cellLength;
                }
            }
        }

        return columnWidths;
    }

    private static void PrintTableLine(List<int> columnWidths)
    {
        Console.WriteLine("+" + string.Join("+", columnWidths.Select(width => new string('-', width + 2))) + "+");
    }

    private static void PrintTableRow(List<string> rowData, List<int> columnWidths)
    {
        Console.Write("|");
        for (int i = 0; i < rowData.Count; i++)
        {
            Console.Write($" {rowData[i].PadRight(columnWidths[i])} |");
        }
        Console.WriteLine();
    }
}
