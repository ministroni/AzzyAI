﻿// Program.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains code for the main entry point of the program, as well
// as methods for outputting messages to the console.

using System;
using System.IO;

namespace AzzyAIConfig
{
    static class Program
    {
        public static void WriteLine(string value)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the value to the console
                    Console.WriteLine(value);
                }
            }
        }

        public static void WriteLine(string format, object arg0)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the formatted text with the argument to the console
                    Console.WriteLine(format, arg0);
                }
            }
        }

        public static void WriteLine(string format, object arg0, object arg1)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the formatted text with the arguments to the console
                    Console.WriteLine(format, arg0, arg1);
                }
            }
        }

        public static void WriteLine(string format, object arg0, object arg1, object arg2)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the formatted text with the arguments to the console
                    Console.WriteLine(format, arg0, arg1, arg2);
                }
            }
        }

        public static void WriteLine(string format, object arg0, object arg1, object arg2, object arg3)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the formatted text with the arguments to the console
                    Console.WriteLine(format, arg0, arg1, arg2, arg3);
                }
            }
        }

        public static void WriteLine(string format, params object[] arg)
        {
            // Check if the console output stream is not null
            if (Console.Out != null)
            {
                // Get the console output stream
                Stream sout = Console.OpenStandardOutput();

                // Check if the stream can write and read
                if (sout.CanWrite && sout.CanRead)
                {
                    // Write the formatted text with the arguments to the console
                    Console.WriteLine(format, arg);
                }
            }
        }
    }
}