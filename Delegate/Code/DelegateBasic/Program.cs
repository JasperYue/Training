using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateBasic
{
    /*
     * 1. 委托可以用来描述命名方法和匿名方法的一个引用类型，类似于函数指针。
     * 2. 定义类似于方法签名，需要指出返回值和参数列表，可以在任何定义类的地方定义委托。
     *      delegate void TestDelegate(string message);
     * 3. 实例化委托: 
     *  1) TestDelegate t = new TestDelegate(MethodName);
     *  2) TestDelegate t1 = MethodName;
     *  3) TestDelegate t2 += MethodName; 多路广播
     *  其中MethodName分为命名方法和匿名方法，以上为命名方法写法
     *  1) TestDelegate t = delegate(double input){};
     *  2) TestDelegate t1 = (s) => s * 2
     *
     * 4. 调用委托所指向的方法
     *  t(params);
     */

    public delegate double MathAction(double num);

    class Program
    {
        static double Square(double input)
        {
            Console.WriteLine("Square");
            return input * input;
        }

        static double Cube(double input)
        {
            Console.WriteLine("Cube");
            return input * input * input;
        }

        static void Main(string[] args)
        {
            MathAction square = Square;
            square += Cube;
            Console.WriteLine(square(1.5));

            MathAction cube = delegate(double input)
            {
                return input * input * input;
            };

            Console.WriteLine(cube(1.5));

            MathAction MultByTwo = (s) => s * 2;
            Console.WriteLine(MultByTwo(1.5));

            Console.ReadLine();
        }
    }
}
