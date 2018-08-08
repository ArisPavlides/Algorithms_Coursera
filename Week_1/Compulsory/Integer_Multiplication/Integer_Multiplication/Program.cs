using System;
using System.Numerics;

namespace Integer_Multiplication
{
    class Program
    {
        static void Main()
        {
            BigInteger num1 = BigInteger.Parse("3141592653589793238462643383279502884197169399375105820974944592");
            BigInteger num2 = BigInteger.Parse("2718281828459045235360287471352662497757247093699959574966967627");

            Console.WriteLine(Karatsuba(num1, num2));
            Console.ReadLine();
        }

        static BigInteger Karatsuba(BigInteger num1, BigInteger num2)
        {
            if ((num1 < 10) || (num2 < 10))
            {
                return BigInteger.Multiply(num1, num2);
            }

            int num_length;
            int num_split;

            num_length = Math.Max(num1.ToString().Length, num2.ToString().Length);
            num_split = num_length / 2;

            BigInteger a = BigInteger.Divide(num1, BigInteger.Pow(10, num_split));
            BigInteger b = num1 % BigInteger.Pow(10, num_split);
            BigInteger c = BigInteger.Divide(num2, BigInteger.Pow(10, num_split));
            BigInteger d = num2 % BigInteger.Pow(10, num_split);

            BigInteger ac = Karatsuba(a, c);
            BigInteger bd = Karatsuba(b, d);
            BigInteger ad_bc = Karatsuba(a + b, c + d);

            return BigInteger.Add(BigInteger.Add(BigInteger.Multiply((ad_bc - ac - bd), BigInteger.Pow(10, num_split)), BigInteger.Multiply(ac, BigInteger.Pow(10, 2 * num_split))), bd);

        }
    }
}
