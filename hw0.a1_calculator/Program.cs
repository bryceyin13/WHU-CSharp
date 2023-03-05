using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Calculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            double num1, num2, res=0;
            Console.WriteLine("Please input the first operand: ");
            num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Then input the operator: ");
            string oper = Console.ReadLine();
            Console.WriteLine("Then input the second operand: ");
            num2 = Convert.ToDouble(Console.ReadLine());

            switch(oper)
            {
                case "+":
                    res = num1 + num2;
                    Console.WriteLine("The result is: " + res);
                    break;
                case "-":
                    res = num1 - num2;
                    Console.WriteLine("The result is: " + res);
                    break;
                case "*":
                    res = num1 * num2;
                    Console.WriteLine("The result is: " + res);
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Your operation is wrong.");
                    }
                    else
                    {
                        res = num1 / num2;
                        Console.WriteLine("The result is: " + res);
                    }
                    break;
                default:
                    Console.WriteLine("Please input a correct operator. ");
                    break;
            }
        }
    }
}