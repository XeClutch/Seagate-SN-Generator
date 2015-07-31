using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeClutch
{
    public static class ConsoleUtils
    {
        public static string Title
        {
            get
            {
                return Console.Title;
            }
            set
            {
                Console.Title = value;
            }
        }

        /// <summary>
        /// Play the standard Win32 console beep noise.
        /// </summary>
        public static void Beep()
        {
            Console.Beep();
        }
        /// <summary>
        /// Play the standard Win32 console beep noise.
        /// </summary>
        /// <param name="frequency">The frequency at which the sound will be played at.</param>
        /// <param name="duration">The duration at which the sound will be played for.</param>
        public static void Beep(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
        }
        /// <summary>
        /// Clears the console text.
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }
        /// <summary>
        /// Prints a message onto the console.
        /// </summary>
        /// <param name="text">The text that will be printed onto the console.</param>
        /// <param name="newline">Specifies whether or not you want to end the previously specified text with a new line.</param>
        /// <param name="color">The color the text will be printed in.</param>
        public static void Print(string text, bool newline = false, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.Write(text + (newline ? "\n" : ""));
        }
        /// <summary>
        /// Prints an error onto the console.
        /// </summary>
        /// <param name="text">The error message details.</param>
        /// <param name="newline">Specifies whether or not you want to end the previously specified text with a new line.</param>
        public static void PrintError(string text, bool newline = false)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(text + (newline ? "\n" : ""));
        }
        /// <summary>
        /// Prompts the user with a question.
        /// </summary>
        /// <param name="text">The question text.</param>
        /// <param name="newline">Specifies whether or not you want to end the previously specified text with a new line.</param>
        /// <returns></returns>
        public static string PrintQuestion(string text, bool newline = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text + (newline ? "\n" : ""));
            return Console.ReadLine();
        }
        /// <summary>
        /// Prints a message onto the console.
        /// </summary>
        /// <param name="text">The text that will be printed onto the console.</param>
        /// <param name="newline">Specifies whether or not you want to end the previously specified text with a new line.</param>
        public static void PrintText(string text, bool newline = false)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(text + (newline ? "\n" : ""));
        }
        /// <summary>
        /// Prints a warning onto the console.
        /// </summary>
        /// <param name="text">The warning message details.</param>
        /// <param name="newline">Specifies whether or not you want to end the previously specified text with a new line.</param>
        public static void PrintWarning(string text, bool newline = false)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text + (newline ? "\n" : ""));
        }
        /// <summary>
        /// Reads the text entered into the console by the user and converts it to an integer.
        /// </summary>
        public static int ReadInt()
        {
            return int.Parse(Console.ReadLine());
        }
        /// <summary>
        /// Reads the text entered into the console by the user.
        /// </summary>
        public static string ReadString()
        {
            return Console.ReadLine();
        }
        /// <summary>
        /// Waits until the user presses a key to continue.
        /// </summary>
        public static void Wait()
        {
            Console.ReadKey();
        }
    }
}