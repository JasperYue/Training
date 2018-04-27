using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            People people = new People();
            people.Hello(people.SayHelloInEnglish, "Ronnie");
            people.Hello(people.sayHelloInChinese, "肉泥");
            Console.ReadLine();
        }
    }


    public class People
    {
        public delegate void SayHello(string otherName);

        public void SayHelloInEnglish(string otherName)
        {
            Console.WriteLine("Hello, {0}", otherName);
        }

        public void sayHelloInChinese(string otherName)
        {
            Console.WriteLine("你好， {0}", otherName);
        }

        public void Hello(SayHello sayHello, string otherName)
        {
            sayHello(otherName);
        }
    }
}
