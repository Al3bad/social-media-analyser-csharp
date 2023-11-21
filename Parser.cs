public class Parser
{
    public static int ParseInt(string value, int min)
    {
        if (!int.TryParse(value, out int parsedValue))
        {
            throw new Exception();
        }

        if (parsedValue < min)
        {
            throw new Exception();
        }

        return parsedValue;
    }

    public static string ParseStr(string value, bool allowEmpty = false, bool allowSpaces = true)
    {
        string parsedValue = value.Trim();
        Console.WriteLine(parsedValue.Split(" ").Length);
        if (parsedValue.Length == 0)
        {
            throw new Exception();
        }
        if (!allowSpaces && parsedValue.Split(" ").Length > 1)
        {
            throw new Exception();
        }
        return parsedValue;
    }

    public static DateTime ParseDateTime(string value, string format)
    {
        if (
            !DateTime.TryParseExact(
                value,
                format,
                null,
                System.Globalization.DateTimeStyles.None,
                out DateTime parsedValue
            )
        )
        {
            throw new Exception();
        }
        return parsedValue;
    }
}
