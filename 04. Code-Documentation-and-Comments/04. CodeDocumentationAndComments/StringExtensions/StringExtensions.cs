﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// The string extensions class provides different methods for manipulation strings. 
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// This method encrypts a string using MD5.
    /// </summary>
    /// <param name="input">The string to encrypt.</param>
    /// <returns>Returns the encrypted string</returns>
    public static string ToMd5Hash(this string input)
    {
        var md5Hash = MD5.Create();
        var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();

        for (int i = 0; i < data.Length; i++)
        {
            builder.Append(data[i].ToString("x2"));
        }

        return builder.ToString();
    }

    /// <summary>
    /// Converts the string to a boolean value, returns True if input string value is equal to  one of the following strings: "true", "ok", "yes", "1".
    /// </summary>
    /// <param name="input">The string to be converted</param>
    /// <returns>A boolean value</returns>
    public static bool ToBoolean(this string input)
    {
        var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
        return stringTrueValues.Contains(input.ToLower());
    }

    /// <summary>
    /// Tries to parse the input string to a value of type short. If unsuccessful, returns the default value for short.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed.
    /// </param>
    /// <returns>
    /// A value of type short.
    /// </returns>
    public static short ToShort(this string input)
    {
        short shortValue;
        short.TryParse(input, out shortValue);
        return shortValue;
    }

    /// <summary>
    /// Tries to parse the input string to a value of type int. If unsuccessful, returns the default value for int.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed.
    /// </param>
    /// <returns>
    /// A value of type int.
    /// </returns>
    public static int ToInteger(this string input)
    {
        int integerValue;
        int.TryParse(input, out integerValue);
        return integerValue;
    }

    /// <summary>
    /// Tries to parse the input string to a value of type long. If unsuccessful, returns the default value for long.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed.
    /// </param>
    /// <returns>
    /// A value of type long.
    /// </returns>
    public static long ToLong(this string input)
    {
        long longValue;
        long.TryParse(input, out longValue);
        return longValue;
    }

    /// <summary>
    /// Tries to parse the input string to a value of type DateTime. If unsuccessful, returns the default value for DateTime.
    /// </summary>
    /// <param name="input">
    /// The string to be parsed.
    /// </param>
    /// <returns>
    /// A value of type long.
    /// </returns>
    public static DateTime ToDateTime(this string input)
    {
        DateTime dateTimeValue;
        DateTime.TryParse(input, out dateTimeValue);
        return dateTimeValue;
    }

    /// <summary>
    /// Capitalizes the first letter of a non-empty string.
    /// </summary>
    /// <param name="input">The string to capitalize</param>
    /// <returns>Returns the string with its first letter capitalized</returns>
    public static string CapitalizeFirstLetter(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return 
            input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + 
            input.Substring(1, input.Length - 1);
    }

    /// <summary>
    /// Gets the substring of a string, which is found between a specified start string and end string.
    /// </summary>
    /// <param name="input">The string from which the substring must be found</param>
    /// <param name="startString">The start of the substring that must be found</param>
    /// <param name="endString">The end of the substring that must be found</param>
    /// <param name="startFrom">The starting letter from which to look</param>
    /// <returns>The wanted substring or an empty string if no substring is found</returns>
    public static string GetStringBetween(
        this string input,
        string startString,
        string endString,
        int startFrom = 0)
    {
        input = input.Substring(startFrom);
        startFrom = 0;
        if (!input.Contains(startString) || !input.Contains(endString))
        {
            return string.Empty;
        }

        var startPosition = 
            input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
        if (startPosition == -1)
        {
            return string.Empty;
        }

        var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
        if (endPosition == -1)
        {
            return string.Empty;
        }

        return input.Substring(startPosition, endPosition - startPosition);
    }

    /// <summary>
    /// Converts a cyrillic word to latin.
    /// </summary>
    /// <param name="input">A latin word</param>
    /// <returns>A latin word</returns>
    public static string ConvertCyrillicToLatinLetters(this string input)
    {
        var bulgarianLetters = new[]
        {
            "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о",
            "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
        };
        var latinRepresentationsOfBulgarianLetters = new[]
        {
            "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
            "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
            "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
        };
        for (var i = 0; i < bulgarianLetters.Length; i++)
        {
            input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
            input = input.Replace(
                bulgarianLetters[i].ToUpper(),
                latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
        }

        return input;
    }

    /// <summary>
    /// Converts lating a latin word to cyrillic.
    /// </summary>
    /// <param name="input">A latin word</param>
    /// <returns>A cyrillic word</returns>
    public static string ConvertLatinToCyrillicKeyboard(this string input)
    {
        var latinLetters = new[]
        {
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
            "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
        };

        var bulgarianRepresentationOfLatinKeyboard = new[]
        {
            "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
            "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
            "в", "ь", "ъ", "з"
        };

        for (int i = 0; i < latinLetters.Length; i++)
        {
            input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
            input = input.Replace(
                latinLetters[i].ToUpper(),
                bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
        }

        return input;
    }

    /// <summary>
    /// Removes all special characters from a string. The resulting string will contain only letters, digits, underscores and dot and will be considered a valid username.
    /// </summary>
    /// <param name="input">The input string</param>
    /// <returns>The validated username</returns>
    public static string ToValidUsername(this string input)
    {
        input = input.ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
    }

    /// <summary>
    /// Validate latin file name, where the spce is replaced by "-".
    /// </summary>
    /// <param name="input">The input string</param>
    /// <returns>The validated latin file name</returns>
    public static string ToValidLatinFileName(this string input)
    {
        input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
        return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
    }

    /// <summary>
    /// Gets the first charsCount characters in a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="charsCount">The number of characters to be returned</param>
    /// <returns>The first count of characters of the given string.</returns>
    public static string GetFirstCharacters(this string input, int charsCount)
    {
        return input.Substring(0, Math.Min(input.Length, charsCount));
    }

    /// <summary>
    /// The get file extension of file name.
    /// </summary>
    /// <param name="fileName">The file name as a string.</param>
    /// <returns>The extension of the file as a string.</returns>
    public static string GetFileExtension(this string fileName)
    {
        if (string.IsNullOrWhiteSpace(fileName))
        {
            return string.Empty;
        }

        string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
        if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
        {
            return string.Empty;
        }

        return fileParts.Last().Trim().ToLower();
    }

    /// <summary>
    /// Returns the content type of a given file extension.
    /// </summary>
    /// <param name="fileExtension">The file extension</param>
    /// <returns>The content type of a given file extension.</returns>
    public static string ToContentType(this string fileExtension)
    {
        var fileExtensionToContentType = new Dictionary<string, string>
        {
            { "jpg", "image/jpeg" },
            { "jpeg", "image/jpeg" },
            { "png", "image/x-png" },
            { "docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
            { "doc", "application/msword" },
            { "pdf", "application/pdf" },
            { "txt", "text/plain" },
            { "rtf", "application/rtf" }
        };
        if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
        {
            return fileExtensionToContentType[fileExtension.Trim()];
        }

        return "application/octet-stream";
    }

    /// <summary>
    /// Converts each symbol of the input string to a value of type byte.
    /// </summary>
    /// <param name="input">A input string.</param>
    /// <returns>A byte array.</returns>
    public static byte[] ToByteArray(this string input)
    {
        var bytesArray = new byte[input.Length * sizeof(char)];
        Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
        return bytesArray;
    }
}
