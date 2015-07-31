using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeClutch
{
    public static class GeneralUtils
    {
        /// <summary>
        /// Generates a random character.
        /// </summary>
        /// <param name="seed">The seed used to generate the character.</param>
        public static char GenerateRandomChar(int seed)
        {
            return (char)(0x61 + GenerateRandomInt(seed, 0, 26));
        }
        /// <summary>
        /// Generates a random 32-bit integer.
        /// </summary>
        /// <param name="seed">The seed used to generate the integer.</param>
        /// <param name="min">The minimum value of the generated number.</param>
        /// <param name="max">The maximum value of the generated number.</param>
        public static int GenerateRandomInt(int seed, int min, int max)
        {
            return new Random((int)DateTime.Now.Ticks + Environment.TickCount * seed).Next(min, max);
        }
        /// <summary>
        /// Generates a random string of characters.
        /// </summary>
        /// <param name="seed">The seed used to generate the string.</param>
        /// <param name="len">The length of the string.</param>
        public static string GenerateRandomString(int seed, int len)
        {
            string str = "";
            for (int i = 0; i < len; i++)
                str += GenerateRandomChar(seed + i);
            return str;
        }
    }
}