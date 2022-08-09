using System;
using System.Collections.Generic;
using System.IO;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var LogInFile = new Pathfinder(new AlwaysWritingPolicy(), new FileLogWritter());
            var LogInConsole = new Pathfinder(new AlwaysWritingPolicy(), new ConsoleLogWritter());
            var LogInFileOnFriday = new Pathfinder(new FridayWritingTimePolicy(), new FileLogWritter());
            var LogInConsoleOnFriday = new Pathfinder(new FridayWritingTimePolicy(), new ConsoleLogWritter());
            var LogInConsoleAndLogInFileOnFriday = new ChainOfPathfinders(new Pathfinder(new AlwaysWritingPolicy(), new ConsoleLogWritter()), new Pathfinder(new FridayWritingTimePolicy(), new FileLogWritter()));
        }
    }

    interface ILogger
    {
        void Find(string message);
    }

    interface IWritingTimePolicy
    {
        bool IsReadToWrite();
    }

    interface IWritingPlacePolicy
    {
        void WriteError(string message);
    }

    class AlwaysWritingPolicy : IWritingTimePolicy
    {
        public bool IsReadToWrite() => true;
    }

    class FridayWritingTimePolicy : IWritingTimePolicy
    {
        public bool IsReadToWrite() => DateTime.Now.DayOfWeek == DayOfWeek.Friday;
    }

    class ConsoleLogWritter : IWritingPlacePolicy
    {
        public virtual void WriteError(string message)
        {
            Console.WriteLine(message);
        }
    }

    class FileLogWritter : IWritingPlacePolicy
    {
        public virtual void WriteError(string message)
        {
            File.WriteAllText("log.txt", message);
        }
    }

    class Pathfinder : ILogger
    {
        public IWritingPlacePolicy Where { get; private set; }
        public IWritingTimePolicy When { get; private set; }

        public Pathfinder(IWritingTimePolicy when, IWritingPlacePolicy where)
        {
            When = when;
            Where = where;
        }

        public void Find(string message)
        {
            if (When.IsReadToWrite())
                Where.WriteError(message);
        }
    }

    class ChainOfPathfinders : ILogger
    {
        private IEnumerable<Pathfinder> _pathfinders;

        public ChainOfPathfinders(params Pathfinder[] pathfinders)
        {
            _pathfinders = pathfinders;
        }

        public void Find(string message)
        {
            foreach (var pathfinder in _pathfinders)
            {
                if (pathfinder.When.IsReadToWrite())
                    pathfinder.Where.WriteError(message);
            }
        }
    }
}