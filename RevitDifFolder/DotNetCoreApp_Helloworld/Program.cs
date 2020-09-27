using System;

namespace DotNetCoreApp_Helloworld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n你叫啥名字!");
            var name = Console.ReadLine();
            var date = DateTime.Now;
            Console.WriteLine($"Hello,{name},on {date:f} at {date:t}!");
            Console.Write("\n Press any key to exit..."); 
            Console.ReadKey(true);
        }
    }
}
