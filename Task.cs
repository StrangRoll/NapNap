using System;

namespace Task
{
    class Program
    {
        public static void CreateNewObject()
        {
            //Создание объекта на карте
        }

        public static void RandomizeChance()
        {
            _chance = Random.Range(0, 100);
        }

        public static int GetSalary(int hoursWorked)
        {
            return _hourlyRate * hoursWorked;
        }
    }
}