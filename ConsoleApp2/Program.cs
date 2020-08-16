using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int num;
            Random rnd = new Random();
            do
            {
                num = rnd.Next(0, 128);
                Console.WriteLine("0x" + num.ToString("X"));
                str = Console.ReadLine();
                Console.WriteLine("Число = " + num.ToString());
                Console.WriteLine("0 чтобы закончить");
                str = Console.ReadLine();
            } while (str != "0");
        }
    }
}
