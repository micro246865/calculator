using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Console Calculator ===");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option: ");

                string input = Console.ReadLine();

                if (input == "5")
                    break;

                int choice;
                if (!int.TryParse(input, out choice) || choice < 1 || choice > 5)
                {
                    Console.WriteLine("Invalid choice. Press any key to try again...");
                    Console.ReadKey();
                    continue;
                }

                double num1 = GetNumber("Enter the first number: ");
                double num2 = GetNumber("Enter the second number: ");
                double result = 0;

                try
                {
                    switch (choice)
                    {
                        case 1:
                            result = Add(num1, num2);
                            break;
                        case 2:
                            result = Subtract(num1, num2);
                            break;
                        case 3:
                            result = Multiply(num1, num2);
                            break;
                        case 4:
                            result = Divide(num1, num2);
                            break;
                    }

                    Console.WriteLine($"Result: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        static double GetNumber(string message)
        {
            double number;
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;

                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero.");
            return a / b;
        }
    }
    }

