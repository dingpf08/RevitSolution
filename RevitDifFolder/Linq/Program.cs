using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    //查询语言
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 2,15,15,15,4,7};
            IEnumerable<int> lowNums = from n in numbers
                                       where n < 7
                                       select n;
            foreach(var x in lowNums)
            {
                Console.WriteLine(x);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
