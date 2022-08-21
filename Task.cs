using System;

namespace Task
{
    class Program
    {
        public static int NumberClamp(int a, int b, int c)
        {
            if (a < b)
                return b;
            else if (a > c)
                return c;
            else
                return a;
        }
    }
}