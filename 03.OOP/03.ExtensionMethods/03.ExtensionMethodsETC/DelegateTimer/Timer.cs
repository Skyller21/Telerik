using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateTimer
{
    public class Timer
    {
        private double seconds;
        public Action<int> Action { get; private set; }
        public int Number { get; private set; }
        public double Seconds
        {
            get { return this.seconds; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("####The seconds must be bigger than 0");
                }
                this.seconds = value;
            }
        }

        public Timer(Action<int> action, int number, double seconds)
        {
            this.Action = action;
            this.Number = number;
            this.Seconds = seconds;
        }
        public void SquareNum()
        {
            while (true)
            {
                Action(this.Number);
                this.Number++;
                Thread.Sleep((int)(this.Seconds * 1000));
            }
        }
    }
}
