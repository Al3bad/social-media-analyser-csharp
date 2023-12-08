public class Parser
{
    public static int ParseInt(string value, int min)
    {
        if (!int.TryParse(value, out int parsedValue))
        {
            throw new Exception(message: "Invalid integer");
        }

        if (parsedValue < min)
        {
            throw new Exception(message: "Integer is out of range");
        }

        return parsedValue;
    }

    public static string ParseStr(string value, bool allowEmpty = false, bool allowSpaces = true)
    {
        string parsedValue = value.Trim();
        if (parsedValue.Length == 0)
        {
            throw new Exception(message: "String is empty");
        }
        if (!allowSpaces && parsedValue.Split(" ").Length > 1)
        {
            throw new Exception(message: "String contain spaces");
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
            throw new Exception(message: "Invalid date/time");
        }
        return parsedValue;
    }

    public static string[] ParseCSV(string str, int expectedFieldsNum)
    {
        string[] fields = str.Split(",");
        if (fields.Length != expectedFieldsNum)
        {
            throw new Exception(message: "Invalid number of fields");
        }
        for (int i = 0; i < fields.Length; i++)
        {
            fields[i] = fields[i].Trim();
        }
        return fields;
    }
}
