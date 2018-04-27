using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CalculatorService : ICalculatorService
    {

        public double Addition(Operand operand)
        {
            VerifyOperandEntity(operand);
            return operand.X + operand.Y;
        }

        public double Subtraction(Operand operand)
        {
            VerifyOperandEntity(operand);
            return operand.X - operand.Y;
        }

        public double Multiplication(Operand operand)
        {
            return operand.X * operand.Y;
        }

        public double Division(Operand operand)
        {
            VerifyOperandEntity(operand);

            if (0 == operand.Y)
            {
                throw new System.ServiceModel.FaultException<ErrorMessage>(new ErrorMessage()
                {
                    Code = "0002",
                    Message = "Division by zero.",
                });
            }

            return operand.X / operand.Y;
        }

        private void VerifyOperandEntity(Operand operand)
        {
            if (null == operand)
            {
                throw new System.ServiceModel.FaultException<ErrorMessage>(new ErrorMessage()
                {
                    Code = "0001",
                    Message = "Operand is null.",
                });
            }
        }

    }
}
