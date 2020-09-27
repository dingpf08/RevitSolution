using System;

namespace DelegateTest
{
    class x
    { 
        public int NiNaiNaiDE(int fuck)
        {
            
            Console.WriteLine(fuck);
            return fuck;
        }
    }

    class DelegateTest
    {

        static int cube(int x)
        {
            var result = x * x * x;
            Console.WriteLine(result);
            return result;
        }
        static int square(int x)
        {
            var result = x * x;
            Console.WriteLine(result);
            return result;
        }
        static string ParameterTrans(object str)
        {
            Console.WriteLine(str);
            return null;
        }
        static string ReturnTrans(string str)
        {
            Console.WriteLine(str);
            return null;
        }
        static string  ReturnTransOK(object str)
        {
            return null;
        }
        delegate int TransFormer(int x);
        delegate object DelegateParameterTrans(string str);//委托参数要具体，返回值要抽象

        static void Main(string[] args)
        {
            DelegateParameterTrans dp = ParameterTrans;
            dp("I am your father");
            dp = ReturnTrans;


            DelegateParameterTrans dr = ReturnTransOK;


            x xtest = new x();

            TransFormer t = null;
            t += square;
            t += cube;

            var result = t(3);
            Console.WriteLine(result);

            t -= square;
            result = t(2);
            Console.WriteLine(result);

           
            result = t(4);
            Console.WriteLine(result);
            t -= cube;

            t += xtest.NiNaiNaiDE;
            t(8);
            Console.WriteLine(t.Target == xtest);
            Console.WriteLine(t.Method );
        }
    }
}
