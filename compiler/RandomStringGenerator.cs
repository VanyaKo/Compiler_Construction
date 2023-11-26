using System;
using System.Text;

public class RandomStringGenerator
{
    private static readonly Random random = new Random();
    private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public static string GenerateRandomString(int length)
    {
        var stringBuilder = new StringBuilder(length);

        for (int i = 0; i < length; i++)
        {
            stringBuilder.Append(chars[random.Next(chars.Length)]);
        }

        return stringBuilder.ToString();
    }
}