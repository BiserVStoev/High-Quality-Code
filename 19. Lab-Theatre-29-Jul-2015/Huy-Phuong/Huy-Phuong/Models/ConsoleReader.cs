﻿namespace Huy_Phuong.Models
{
    using System;
    using Interfaces;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string input = Console.ReadLine();

            return input;
        }
    }
}
