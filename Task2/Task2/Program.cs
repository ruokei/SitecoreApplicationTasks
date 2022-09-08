using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputString, trashSymbolString; 
            Console.WriteLine(" Enter string");
            inputString = Console.ReadLine();

            int ori = inputString.Length;
            int counter = 0;

            Console.WriteLine(" Enter trash symbol string");
            trashSymbolString = Console.ReadLine();

            for (int j = 0; j < ori; j++)
            {
                if (!trashSymbolString.Contains(inputString[j]))
                {
                    inputString += inputString[j].ToString();
                    counter++;
                }
            }

            for (int i = ori - 1; i >= 0; i--)
            {
                if (!trashSymbolString.Contains(inputString[i]))
                {
                    inputString += inputString[i].ToString();
                }
            }

            //Console.WriteLine(ori.ToString());
            //Console.WriteLine(inputString.Length.ToString());
            //Console.WriteLine(inputString.Substring(ori, counter));
            //Console.WriteLine(inputString.Substring(ori+counter, counter));

            if (inputString.Substring(ori, counter) == inputString.Substring(ori+counter, counter))
            {
                Console.WriteLine("Result should be: true");
            }
            else
            {
                Console.WriteLine("Result should be: false");
            }

            Console.ReadKey();
        }
    }
}
