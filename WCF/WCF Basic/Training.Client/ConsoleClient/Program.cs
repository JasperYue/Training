using ConsoleClient.CalculatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region Calculator

            CalculatorService.CalculatorServiceClient calculator = new CalculatorService.CalculatorServiceClient();

            Operand operand = null;

            //operand = new Operand()
            //{
            //    X = 1,
            //    Y = 2,
            //};

            operand = new Operand()
            {
                X = 1,
                Y = 0,
            };

            try
            {
                //Test addition
                var additionResult = calculator.Addition(operand);
                Console.WriteLine(operand.X + " + " + operand.Y + " = " + additionResult);

                //Test subtraction
                var subtractionResult = calculator.Subtraction(operand);
                Console.WriteLine(operand.X + " - " + operand.Y + " = " + subtractionResult);

                //Test multiplcation
                var multiplcationResult = calculator.Multiplication(operand);
                Console.WriteLine(operand.X + " * " + operand.Y + " = " + multiplcationResult);

                //Test division
                var divisionResult = calculator.Division(operand);
                Console.WriteLine(operand.X + " / " + operand.Y + " = " + divisionResult);

            }
            catch (System.ServiceModel.FaultException<ErrorMessage> exception)
            {
                Console.WriteLine("Error: " + "Code: " + exception.Detail.Code + ", ErrorMessage: " + exception.Detail.Message);
            }
            //catch(Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            #endregion

            Console.ReadLine();
        }
    }
}
