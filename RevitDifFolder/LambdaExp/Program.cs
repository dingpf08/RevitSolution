using System;
using System.Collections.Generic;
using System.Linq;

namespace LambdaExp
{
    class Program
    {
        public static List<Person> PersonsList()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 7; i++)
            {
                Person p = new Person() { Name = i + "儿子", Age = 8 - i, };
                persons.Add(p);
            }
            return persons;
        }
        static void Main(string[] args)
        {
            List<Person> persons = PersonsList();
            persons = persons.Where(p => p.Age > 6).ToList();       //所有Age>6的Person的集合
            Person per = persons.SingleOrDefault(p => p.Age == 1);  //Age=1的单个people类
            persons = persons.Where(p => p.Name.Contains("儿子")).ToList();   //所有Name包含儿子的Person的集合

        }
    }
}
