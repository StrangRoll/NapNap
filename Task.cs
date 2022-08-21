using System;

namespace Task
{
    class Program
    {
        public void Enable()
        {
            _effects.StartEnableAnimation();
        }

        public void Disable()
        {
            _pool.Free(this);
        }
    }
}