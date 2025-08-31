using System;
using System.Security.Cryptography;
using System.Text;

namespace KisaragiTech.Dape.User.Service;

public static class PasswordGenerator
{
    // 構造レスで使う文字集合（視認性も考慮してl,1,O,0は除外）
    private const string Alphabet =
        "ABCDEFGHJKLMNPQRSTUVWXYZ" +  // 大文字 (O除く)
        "abcdefghijkmnopqrstuvwxyz" + // 小文字 (l除く)
        "23456789" +                  // 数字 (0と1除く)
        "!@#$%^&*()-_=+[]{}|;:,.<>?"; // 記号（調整可）

    public static string Generate(int length = 20)
    {
        if (length <= 0)
        {
            throw new ArgumentException("length must be positive", nameof(length));
        }

        var sb = new StringBuilder(length);

        for (var i = 0; i < length; i++)
        {
            var index = RandomNumberGenerator.GetInt32(Alphabet.Length);
            sb.Append(Alphabet[index]);
        }

        return sb.ToString();
    }
}