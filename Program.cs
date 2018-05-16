using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exec = true;
            do
            {
                Console.OutputEncoding = Encoding.Default;
                try
                {
                    int multiplicand = int.Parse(Console.ReadLine());
                    int multiplier = int.Parse(Console.ReadLine());
                    Console.WriteLine("Result is: " + Multiplication.ShiftingRight(multiplicand, multiplier));
                    Console.ReadKey();
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Too big value!!!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wrong format!!!");
                }
            }
            while (exec);
        }
    }
    public class Multiplication
    {
        public static long ShiftingRight(int multiplicand, int multiplier)
        {
            bool isMultiplierNegative = multiplier < 0;
            if (isMultiplierNegative)
                multiplier = ~multiplier + 1;
            long shiftedMultiplicand = multiplicand;
            long product = 0;
            shiftedMultiplicand <<= 32;
            string noAction = " no op";
            string action = " product = product + multiplicand ";
            bool isBit1;

            Console.WriteLine("{0,-16} {4,-44} {1,32} {2,32} {3,64} \n", "Iteration", "Multiplier", "Multiplicand", "Product", "Action");
            Console.WriteLine("{0,-16}                                              {1,32} {2,32} {3,64} \n", "Initial values:", Convert.ToString(multiplier, 2),
                Convert.ToString(multiplicand, 2), Convert.ToString(product, 2));

            for (int i = 0; i < 32; i++)//перебираємо всі біти множника
            {
                isBit1 = (multiplier & 1) == 1;
                if (isBit1)
                    product += shiftedMultiplicand;
                Console.WriteLine("{0,-16} {4,-44} {1,32} {2,32} {3,64} ", i, Convert.ToString(multiplier, 2), Convert.ToString(multiplicand, 2),
                    Convert.ToString(product, 2), Convert.ToByte(isBit1) + " -> " + (isBit1 ? action : noAction));
                product >>= 1;
                multiplier >>= 1;
                Console.WriteLine("                 {3,-44} {0,32} {1,32} {2,64} \n", Convert.ToString(multiplier, 2), Convert.ToString(multiplicand, 2),
                    Convert.ToString(product, 2), "Multiplier / Product shift right");
            }
            if (isMultiplierNegative)
                product = ~product + 1;
            return product;
        }
    }
   
}
