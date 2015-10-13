namespace ObserverPattern
{
    using System;
    using System.Collections.Generic;

    public class StockGrabber : ISubject
    {
        private readonly List<IObserver> observers;
        private double ibmPrice;
        private double applePrice;
        private double googlePrice;

        public StockGrabber()
        {
            this.observers = new List<IObserver>();
        }

        public void Register(IObserver newObserver)
        {
            this.observers.Add(newObserver);
        }

        public void Unregister(IObserver deleteObserver)
        {
            this.observers.Remove(deleteObserver);

            Console.WriteLine("Observer {0} deleted", deleteObserver);
        }

        public void NotifyObserver()
        {
            this.observers.ForEach(o => o.Update(this.ibmPrice, this.applePrice, this.googlePrice));
        }

        public void SetIbmPrice(double newIbmPrice)
        {
            this.ibmPrice = newIbmPrice;
            this.NotifyObserver();
        }

        public void SetApplePrice(double newApplePrice)
        {
            this.applePrice = newApplePrice;
            this.NotifyObserver();
        }

        public void SetGooglePrice(double newGooglePrice)
        {
            this.googlePrice = newGooglePrice;
            this.NotifyObserver();
        }
    }
}