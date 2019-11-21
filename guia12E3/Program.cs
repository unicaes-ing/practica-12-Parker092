using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guia12E3
{
    class Program
    {
        static void Main(string[] args)
        {
            //DIEGO PALACIOS NOVIEMBRE - 2019
            int op;
            do
            {
                Console.WriteLine(" 1 - E1");
                Console.WriteLine(" 2 - E2");
                Console.WriteLine(" 3 - E3");
                op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        Console.Clear();
                        Ejercicio1 e1 = new Ejercicio1();
                        e1.ejer1();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Ejercicio2 e2 = new Ejercicio2();
                        e2.ejer2();
                        Console.Clear();
                        break;
                    case 3:
                        Ejercicio3 e3 = new Ejercicio3();
                        e3.ejer3();
                        break;
                }
            } while (op!=4);
        }
    }
}
