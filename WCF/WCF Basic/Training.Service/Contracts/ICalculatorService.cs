using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Contracts
{
    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract]
        [FaultContract(typeof(ErrorMessage))]
        double Addition(Operand operand);

        [OperationContract]
        [FaultContract(typeof(ErrorMessage))]
        double Subtraction(Operand operand);

        [OperationContract]
        [FaultContract(typeof(ErrorMessage))]
        double Multiplication(Operand operand);

        [OperationContract]
        [FaultContract(typeof(ErrorMessage))]
        double Division(Operand operand);
    }

    [DataContract]
    public class Operand
    {
        [DataMember]
        public double X { get; set; }
        [DataMember]
        public double Y { get; set; }
    }

    [DataContract]
    public class ErrorMessage
    {
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
