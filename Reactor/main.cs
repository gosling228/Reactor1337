using System;
using System.Threading;

namespace Reactor
{
    class main
    {
        static void Main(string[] args)
        {
            Boolean enabled = true;
            reactor myReactor = new reactor(enabled);
            Thread ThUp = new Thread(new ThreadStart(myReactor.tempUp));
            Thread ThDown = new Thread(new ThreadStart(myReactor.tempDown));
            Thread ThReactorMonitor = new Thread(new ThreadStart(myReactor.reactorMonitor));
            Thread ThStop = new Thread(new ThreadStart(myReactor.stopReactor));
            ThUp.Start();
            ThDown.Start();
            ThReactorMonitor.Start();
            ThStop.Start();
        }
    }
}
