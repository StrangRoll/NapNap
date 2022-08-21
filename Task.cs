using System;

namespace Task
{
    class Player { }
    class Gun { }
    class TargetFollower { }
    class UnitStorage
    {
        public IReadOnlyCollection<Unit> UnitsToGet { get; private set; }
    }
}