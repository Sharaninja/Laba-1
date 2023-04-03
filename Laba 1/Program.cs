using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        delegate int IntMember();
        delegate int AverageMembers(IntMember[] valueMembers);
        delegate int Average(int a, int b, int c);

        static void Main()
        {

            Func<int, int, int> add = (int a, int b) => a + b;
            Func<int, int, int> sub = (int a, int b) => a - b;
            Func<int, int, int> mul = (int a, int b) => a * b;
            Func<int, int, int> div = (int a, int b) => b != 0 ? a / b : throw new ArgumentException("Дiльник не може бути нулем.");


            Console.WriteLine("1)\n");
            Console.WriteLine(add(7, 2));
            Console.WriteLine(sub(8, 6));
            Console.WriteLine(mul(4, 2));
            Console.WriteLine(div(9, 3));


            IntMember randomMember = () => new Random().Next(50);


            AverageMembers averageMembers = (members) =>
            {
                int sum = 0;

                foreach (var member in members)
                {
                    sum += member();
                }

                return members.Length > 0 ? sum / members.Length : throw new ArgumentException("Масив учасникiв не може бути порожнiм.");
            };


            Average average = (a, b, c) => (a + b + c) / 3;


            IntMember[] randomMembers = { randomMember, randomMember, randomMember };
            Console.WriteLine("\n2) " + averageMembers(randomMembers));


            Console.WriteLine("\n3) " + average(10, 20, 30));
            Console.ReadLine();
        }
    }
}
