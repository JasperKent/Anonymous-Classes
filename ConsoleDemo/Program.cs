using System;
using System.Linq;

namespace ConsoleDemo
{
    static class Extensions
    {
        public static T FromPrototype<T>(this object o, T prototype) => (T)o;
    }

    class Program
    {
        static object GetAnonymous()
        {
            return new { FirstName = "Mary", LastName = "Shelley" };
        }

        static void Main()
        {
            var anon = GetAnonymous().FromPrototype(new { FirstName = "", LastName = "" });
          
            Console.WriteLine(anon.FirstName);

            var list = new object[0].Select(o => new { FirstName = "", LastName = "" }).ToList();

            list.Add(anon);

            foreach(var o in list)
                Console.WriteLine(o);
        }
    }
}
