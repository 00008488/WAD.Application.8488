using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Entities
{
    public class Util
    {
        public static string RandomGenerator() {
            Random random = new Random();
            int size = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
