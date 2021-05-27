using System;
using System.Linq;
using System.Text;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            //  Encode();
            
            byte[] b = Encode("dude");
            string message = Decode(b);
            Console.WriteLine(message);
           

        }
        public static byte[] ByteArray(string message)
        {
            return Encoding.UTF8.GetBytes(message);
        }

        
        public static byte[] Encode(string message)
        {
            byte[] messageByte = ByteArray(message);

            string messageString = ToBinary(messageByte);

            return Encoding.UTF8.GetBytes(messageString);
        }

        public static string Decode(byte[] peylod)
        {
             return string.Join("\n", peylod.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }




        public static string ToBinary(byte[] peylod)
        {
            StringBuilder s = new StringBuilder();
           
            string str1 = Convert.ToString(peylod[1], 2).ToString();

            s.Append(Convert.ToString(peylod[0], 2).PadLeft(8, str1[6]).ToString()+ "\n");
            string str2= "a";
           
            for (int i = 1; i< peylod.Length; i++)
            {
                str2 = Convert.ToString(peylod[i], 2).Substring(7 - i, i);
                str1 = Convert.ToString(peylod[i], 2).Shift(i).PadLeft(8, '0').ToString();
                
             
                 
              
                s.Append(str1 + "\n");
             
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
