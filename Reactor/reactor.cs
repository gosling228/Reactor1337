using System;
using System.Threading;

namespace Reactor
{
    class reactor
    {
        private object ReactorLock = new object();
        Int32 temp = 30;
        Int32 targetTemp = 80;
        Boolean enabled = true;

        public reactor(Boolean enabled) { this.enabled = enabled; }

        public void tempUp()
        {
            while (enabled)
            {
                lock (ReactorLock)
                {
                    temp++;
                    Console.WriteLine(temp);
                }
                Thread.Sleep(100);
            }
        }

        public void tempDown()
        {
            while (enabled || temp > 0)
            {
                lock (ReactorLock)
                {
                    if (temp > targetTemp)
                    {
                        int diff = Math.Abs(targetTemp - temp);
                        if (diff < 10) temp -= 2;
                        else if (diff > 10 && diff < 20) temp -= 3;
                        else if (diff > 20) temp -= 4;
                    }
                }
                Thread.Sleep(100);
            }
        }

        public void reactorMonitor()
        {
            while (enabled || temp > -1)
            {
                Console.WriteLine("temp:" + temp);
                if (temp >= 100)
                {
                    Console.Clear();
                    Console.WriteLine("explosion");
                }
                else if (temp <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("stop");
                }
                Thread.Sleep(1000);
            }
        }

        public void stopReactor()
        {
            while (enabled)
            {
                var s = Console.ReadLine();
                var line = s;
                if (line.Equals("stop")) Environment.Exit(0);
                else targetTemp = int.Parse(line);
                Thread.Sleep(100);
            } 
        }
    }
}
