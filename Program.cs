﻿using System;
using System.Text;
using System.Threading;

public class OldPhonePad
{
    private static readonly string[] KeyPadMapping = {
        " ",
        "&,(",
        "ABC",
        "DEF",
        "GHI",
        "JKL",
        "MNO",
        "PQRS",
        "TUV",
        "WXYZ"
    };

    public static void Main()
    {
        StringBuilder output = new StringBuilder();
        char LastChar = '\0';
        int TimesPressed = 0;
        DateTime LastPressed = DateTime.UtcNow;

        Console.WriteLine("Start typing your input (press '#' to display output, 'Escape' to exit):");

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nExiting program...");
                    break;
                }
                char currentChar = keyInfo.KeyChar;
                if (currentChar == '#')
                {
                    if (LastChar != '\0')
                    {
                        char finalChar = GetCharacter(LastChar, TimesPressed);
                        output.Append(finalChar);
                    }
                    Console.WriteLine($"\n\nFinal Output: {output}");
                    LastChar = '\0';
                    TimesPressed = 0;
                    output.Clear();
                    Console.WriteLine("\nStart typing your next input (press '#' to display output, 'Escape' to exit):");
                    continue;
                }
                if (currentChar < '0' || currentChar > '9')
                {
                    continue;
                }
                Console.Write(currentChar);
                DateTime currentPressTime = DateTime.UtcNow;
                TimeSpan timeSinceLastPress = currentPressTime - LastPressed;

                if (timeSinceLastPress.TotalMilliseconds >= 1000)
                {
                    LastChar = currentChar;
                    TimesPressed = 1;
                }
                else if (LastChar == currentChar)
                {
                    TimesPressed++;
                }
                else
                {
                    if (LastChar != '\0')
                    {
                        char finalChar = GetCharacter(LastChar, TimesPressed);
                        output.Append(finalChar);
                    }
                    LastChar = currentChar;
                    TimesPressed = 1;
                }
                LastPressed = currentPressTime;
            }
            if (LastChar != '\0' && (DateTime.UtcNow - LastPressed).TotalMilliseconds >= 1000)
            {
                char finalChar = GetCharacter(LastChar, TimesPressed);
                output.Append(finalChar);
                LastChar = '\0';
                TimesPressed = 0;
            }
        }
    }
    private static char GetCharacter(char number, int TimesPressed)
    {
        int index = number - '0';
        if (index < 0 || index >= KeyPadMapping.Length)
        {
            return '\0';
        }

        string letters = KeyPadMapping[index];
        if (letters.Length == 0)
        {
            return '\0';
        }
        return letters[(TimesPressed - 1) % letters.Length];
    }
}