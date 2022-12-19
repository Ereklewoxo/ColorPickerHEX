﻿using CustomColor;

namespace Color_Picker_HEX
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;
            Console.CursorVisible = false;
            string bar = "╞══════════════════════════════╡";
            string barD = "╞═══════════════════════════════╡";
            string bGD = "\x1b[48;2;0;0;0m";
            string fGG = "\x1b[38;2;160;160;160m";
            string fGW = "\x1b[38;2;255;255;255m";
            string fGRed = "\x1b[38;2;200;0;0m";
            string fGGreen = "\x1b[38;2;0;200;0m";
            string fGBlue = "\x1b[38;2;0;0;200m";
            string fGD;
            Console.Write(bGD);
            Console.Clear();
            Random rnd = new();
            int red = rnd.Next(255);
            int green = rnd.Next(255);
            int blue = rnd.Next(255);
            int selValue = 0;
            do
            {
                string fGSelRed = fGG;
                string fGSelGreen = fGG;
                string fGSelBlue = fGG;
                switch (selValue)
                {
                    case 0:
                        fGSelRed = fGW;
                        break;
                    case 1:
                        fGSelGreen = fGW;
                        break;
                    case 2:
                        fGSelBlue = fGW;
                        break;
                }
                if (red < 100 && green < 100 && blue < 100)
                    fGD = "\x1b[38;2;255;255;255m";
                else
                    fGD = "\x1b[38;2;0;0;0m";
                string barRed;
                string barGreen;
                string barBlue;
                if (red < 8 || red == 255)
                    barRed = barD;
                else
                {
                    barRed = bar.Remove(red / 8, 1);
                    barRed = bar.Insert(red / 8, "╪");
                }
                if (green < 8 || green == 255)
                    barGreen = barD;
                else
                {
                    barGreen = bar.Remove(green / 8, 1);
                    barGreen = bar.Insert(green / 8, "╪");
                }
                if (blue < 8 || blue == 255)
                    barBlue = barD;
                else
                {
                    barBlue = bar.Remove(blue / 8, 1);
                    barBlue = bar.Insert(blue / 8, "╪");
                }
                string bGC = $"\x1b[48;2;{red};{green};{blue}m";
                string fGC = $"\x1b[38;2;{red};{green};{blue}m";
                Console.WriteLine($"{fGC}" +
                      @"  __   __        __   __      __     __        ___  __           ___     " + '\n' +
                      @" /  ` /  \ |    /  \ |__)    |__) | /  ` |__/ |__  |__)    |__| |__  \_/ " + '\n' +
                      @" \__, \__/ |___ \__/ |  \    |    | \__, |  \ |___ |  \    |  | |___ / \ " + '\n');
                string hex = $"{red:X2}{green:X2}{blue:X2}";
                Console.WriteLine(
                   $"      ██████████████       {fGRed}R{fGSelRed}ed  {barRed} {red}  \n{fGC}" +
                    "      ██████████████\n" +
                   $"      ██████████████       {fGGreen}G{fGSelGreen}reen{barGreen} {green}  \n{fGC}" +
                    "      ██████████████\n" +
                   $"      ██████████████       {fGBlue}B{fGSelBlue}lue {barBlue} {blue}  \n{fGC}" +
                   $"      ███████{bGC}{fGD}#{hex}{bGD}{fGC}\n");
                Console.WriteLine("                           [W S A D]  [SHIFT +] - +/-10  [ESC] - Exit");
                key = Console.ReadKey(true);
                if ((key.Modifiers & ConsoleModifiers.Shift) != 0)
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D:
                            switch (selValue)
                            {
                                case 0:
                                    red = Math.Min(red + 10, 255);
                                    break;
                                case 1:
                                    green = Math.Min(green + 10, 255);
                                    break;
                                case 2:
                                    blue = Math.Min(blue + 10, 255);
                                    break;
                            }
                            break;
                        case ConsoleKey.A:
                            switch (selValue)
                            {
                                case 0:
                                    red = Math.Max(red - 10, 0);
                                    break;
                                case 1:
                                    green = Math.Max(green - 10, 0);
                                    break;
                                case 2:
                                    blue = Math.Max(blue - 10, 0);
                                    break;
                            }
                            break;
                        case ConsoleKey.W:
                            selValue = Math.Max(selValue - 1, 0);
                            break;
                        case ConsoleKey.S:
                            selValue = Math.Min(selValue + 1, 2);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    switch (key.Key)
                    {
                        case ConsoleKey.D:
                            switch (selValue)
                            {
                                case 0:
                                    red = Math.Min(red + 1, 255);
                                    break;
                                case 1:
                                    green = Math.Min(green + 1, 255);
                                    break;
                                case 2:
                                    blue = Math.Min(blue + 1, 255);
                                    break;
                            }
                            break;
                        case ConsoleKey.A:
                            switch (selValue)
                            {
                                case 0:
                                    red = Math.Max(red - 1, 0);
                                    break;
                                case 1:
                                    green = Math.Max(green - 1, 0);
                                    break;
                                case 2:
                                    blue = Math.Max(blue - 1, 0);
                                    break;
                            }
                            break;
                        case ConsoleKey.W:
                            selValue = Math.Max(selValue - 1, 0);
                            break;
                        case ConsoleKey.S:
                            selValue = Math.Min(selValue + 1, 2);
                            break;
                    }
                }
                Console.SetCursorPosition(0, Console.CursorTop - 12);
            } while (key.Key != ConsoleKey.Escape);
        }
    }
}