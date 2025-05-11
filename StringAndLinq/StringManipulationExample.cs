using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAndLinq
{
    internal class StringManipulationExample
    {
        /// <summary>
        /// i have arrray of students name, 
        /// student count is 1000
        /// i want to store all student name saperated by comma,
        /// 
        /// </summary>
        public StringManipulationExample()
        {
            string message = "Hello, Asp.net Core!";
            Console.WriteLine(message);
            //get length
            Console.WriteLine("length "+message.Length);
            Console.WriteLine("Upper "+message.ToUpper());
            Console.WriteLine("Lower " + message.ToLower());
            //default its case sensetive
            //StringComparison.OrdinalIgnoreCase 
            Console.WriteLine("Check " + message.Contains("asp",StringComparison.OrdinalIgnoreCase));

            string newMessage = message.Replace(" ","/");
            Console.WriteLine("New Message :"+newMessage);
            Console.WriteLine("Old Message :"+message);
            //params
            //

            for (int i = 0;i<message.Length; i++)
            {
                Console.WriteLine("index "+i+" =>"+message[i]);
            }

            string subStr=message.Substring(10,4);
            Console.WriteLine("substr :"+subStr);
            subStr = message.Substring(10);
            Console.WriteLine("substr with def length:" + subStr);

            StringBuilder sb=new StringBuilder("Hello");
            sb.Append(", Asp.net Core!");

            
        }
    }
}
