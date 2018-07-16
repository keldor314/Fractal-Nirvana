using System.Diagnostics;
using System.Threading;

namespace Fractal_Nirvana
{
    class PrecisionTimer
    {
        private long periodInTicks;
        private long triggerTick = 0;
        private Stopwatch timer;
        public PrecisionTimer (double frequency)
        {
            timer = new Stopwatch();
            periodInTicks = (long)(Stopwatch.Frequency / frequency);
        }
        public void Await()
        {
            while (timer.ElapsedTicks < triggerTick)
                Thread.Sleep(1);
            while (timer.ElapsedTicks > triggerTick)
                triggerTick += periodInTicks;
        }
    }
}
