using System;
using System.Linq;
using System.Text;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {


            byte[] payload = Encode("du");
            string s = Decode(payload);
            Console.WriteLine(s);
            foreach (var item in payload)
            {
                Console.WriteLine(item);
            }
           
       //  Console.WriteLine(ToBinary(ByteArray("dude")));
        }
        public static byte[] ByteArray(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        
        public static byte[] Encode(string message)
        {
            //byte[] messageByte = ByteArray(message);

            string messageString = ToBinary((ByteArray(message)));

            return Encoding.UTF8.GetBytes(messageString);
        }

        public static string Decode(byte[] peylod)
        {
             return string.Join("\n", peylod.Select(byt => Convert.ToString(byt, 2)));
        }




        public static string ToBinary(byte[] peylod)
        {
            StringBuilder s = new StringBuilder();
            string str1 = null;
            string str2 = null;
         
            for (int i = 0; i< peylod.Length; i++)
            {


                str1 = Convert.ToString(peylod[i], 2);  // tostring 
                if (i + 1 < peylod.Length)
                    str2 = Convert.ToString(peylod[i + 1], 2);  // tostring 
                else
                    str2 = "0000000";                                                             
                str1 = str2.Substring(6 - i)   + str1.Substring(0, 7-i);
                s.Append(str1 );
                str1 = str2; 
            }
         
            return s.ToString();


        }

        
    }
    public static class MyExtensions
    {
        public static string Shift(this string s, int count)
        {
           return s.Remove(7-count, count);
        }

    }

}
