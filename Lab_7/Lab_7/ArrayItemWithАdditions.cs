using System;
using System.Linq;

namespace Lab_7
{
    public class ArrayItemWithАdditions
    {
        public int Key { get; set; }
        public string AdditionalString { get; set; }
        public bool AdditionalBool { get; set; }

        public ArrayItemWithАdditions(int N)
        {
            var r = new Random(DateTime.Now.Millisecond);
            Key = N;
            AdditionalString = RandomString(r.Next(2, 32));
            AdditionalBool = Convert.ToBoolean(r.Next(0, 1));
        }
        
        public static string RandomString(int length)
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}