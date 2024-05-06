using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OS_HW_7C
{
    class Activity : IDisposable
    {
        Thread _thread;
        bool _isStopping = false;
        Action _activity;

        public Activity(Action activity)
        {
            _activity = activity;

            _thread = new Thread(Run);
            _thread.Start();
        }

        public void Dispose()
        {
            Stop();
        }

        public void Stop()
        {
            if (_isStopping)
                return;

            _isStopping = true;
            _thread.Join();
        }

        private void Run()
        {
            while (!_isStopping)
            {
                _activity();
            }
        }

    }
}
