﻿using System;

namespace Task
{
    class Program
    {
        public static int FindElement(int[] array, int element)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] == element)
                    return i;

            return -1;
        }
    }
}