public class UI
{
    public static void Heading(string title, int width = 70)
    {
        Console.WriteLine("".PadRight(width, '-'));
        Console.WriteLine($"> {title}");
        Console.WriteLine("".PadRight(width, '-'));
    }
}
