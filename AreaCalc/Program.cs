using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AreaCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp;
            do
            {
                inp = Console.ReadLine();
                if (inp != "exit")
                {
                    Console.WriteLine(Class1.Calc(inp));
                }
                else
                {
                    Console.WriteLine("Вы уверены, что хотите выйти? (Y) / (N)");
                    inp = Console.ReadLine();
                    if (inp == "Y" || inp == "y")
                    {
                        Environment.Exit(3);


                    }
                }
            } while (true);
        }
    }
}
