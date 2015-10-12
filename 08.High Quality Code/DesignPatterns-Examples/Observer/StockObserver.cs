using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class StockObserver : IObserver
    {
        private double ibmPrice;
        private double applePrice;
        private double googlePrice;

        private static int observerIdTracker = 0;

        private int observerId;

        private ISubject stockGrabber;

        public StockObserver(ISubject stockGrabber)
        {
            this.stockGrabber = stockGrabber;
            this.observerId = ++observerIdTracker;

            Console.WriteLine("New observer id={0}", this.observerId);

            this.stockGrabber.Register(this);
        }

        public void Update(double ibmPrice, double applePrice, double googlePrice)
        {
            this.ibmPrice = ibmPrice;
            this.applePrice = applePrice;
            this.googlePrice = googlePrice;

            PrintPrices();
        }

        private void PrintPrices()
        {
            Console.WriteLine("{0}\nIBM: {1}",observerId, ibmPrice);
            Console.WriteLine("Apple: {0}", applePrice);
            Console.WriteLine("Google: {0}", googlePrice);
        }
    }
}
