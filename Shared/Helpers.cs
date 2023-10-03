namespace DutyAppDB.Shared;

public static class Helpers
{
    public static void SuccessTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(text);
        Console.ResetColor();
    }

    public static void FailureTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: {0}", text);
        Console.ResetColor();
    }

    public static void InfoTextOutput(string text)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(text);
        Console.ResetColor();
    }


    public static string GenerateCode(int id)
    {


        return $"MGQS-{id.ToString("0000")}";
    }

    public static int SelectEnum(string screenMessage, int validStart, int validEnd)
    {
        int outValue;
        do
        {
            Console.Write(screenMessage);
        } while (!(int.TryParse(Console.ReadLine(), out outValue) && isValid(outValue, validStart, validEnd)));
        return outValue;
    }

    public static bool isValid(int outValue, int start, int end)
    {
        return outValue >= start && outValue <= end;
    }

    public static DateOnly TryParseDateOnly(string dateOnlyString)
    {
        if (!DateOnly.TryParse(dateOnlyString, out DateOnly result))
        {
            throw new FormatException("Bad dateOnly format provided!");
        }

        return result;
    }

    public static DateTime TryParseDateTimeOnly(string dateTimeOnlyString)
    {
        if (!DateTime.TryParse(dateTimeOnlyString, out DateTime result))
        {
            throw new FormatException("Bad dateTime format provided!");
        }

        return result;
    }
}
