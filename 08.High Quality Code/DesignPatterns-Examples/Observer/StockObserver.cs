namespace ObserverPattern
{
    using System;

    public class StockObserver : IObserver
    {
        private static int observerIdTracker = 0;

        private readonly int observerId;
        private readonly ISubject stockGrabber;

        private double ibmPrice;
        private double applePrice;
        private double googlePrice;


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

            this.PrintPrices();
        }

        private void PrintPrices()
        {
            Console.WriteLine("{0}\nIBM: {1}", this.observerId, this.ibmPrice);
            Console.WriteLine("Apple: {0}", this.applePrice);
            Console.WriteLine("Google: {0}", this.googlePrice);
        }
    }
}