using System;

namespace Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsValid("()")); // true
            Console.WriteLine(IsValid(")()")); // false
            Console.WriteLine(IsValid("()()")); //true
            Console.WriteLine(IsValid("())(")); //false
            Console.WriteLine(IsValid("(()())")); //true
            Console.WriteLine(IsValid("(())())")); //false
            Console.WriteLine(IsValid("((()()))")); //true
            Console.WriteLine(IsValid("((()(()))")); //false
        }

        private static bool IsValid(string input)
        {
            var openings = 0;
            
            foreach (var c in input)
            {
                if (c == '(')
                {
                    openings++;
                    continue;
                }

                if (c == ')')
                {
                    openings--;
                }

                if (openings < 0)
                    return false;
            }

            return openings == 0;
        }
    }
}