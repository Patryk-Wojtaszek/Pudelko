
using System;
using PudelkoLibrary;

namespace Pudelkoo
{
    class Program
    {
        static void Main(string[] args)
        {
            


            Console.WriteLine("Hello World!");
            Pudelko p = new Pudelko(0.1448, 0.4, 0.6,UnitOfMeasure.meter);
            Console.WriteLine(p.ToString());
            Console.WriteLine(p.ToString("m"));
            Console.WriteLine(p.ToString("cm"));
            Console.WriteLine(p.ToString("mm"));
            Console.WriteLine(p.Objetosc);
            Console.WriteLine(p.Pole);
            Console.WriteLine();

            Pudelko p2 = new Pudelko(8, 9, 9,UnitOfMeasure.centimeter);
            Console.WriteLine(p2.ToString());
            Console.WriteLine(p2.ToString("m"));
            Console.WriteLine(p2.ToString("cm"));
            Console.WriteLine(p2.ToString("mm"));
            Console.WriteLine(p2.Objetosc);
            Console.WriteLine(p2.Pole);
            Console.WriteLine();

            Pudelko p3 = new Pudelko(2.5, 9.321, 0.1);
            Console.WriteLine(p3.ToString());
            Console.WriteLine(p3.ToString("m"));
            Console.WriteLine(p3.ToString("cm"));
            Console.WriteLine(p3.ToString("mm"));
            Console.WriteLine(p3.Objetosc);
            Console.WriteLine(p3.Pole);
            Console.WriteLine();
        }           
    }
}
