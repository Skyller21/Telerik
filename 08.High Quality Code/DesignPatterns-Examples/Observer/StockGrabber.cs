using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObserverPattern
{
    public class StockGrabber : ISubject
    {
        private List<IObserver> observers;
        private double ibmPrice;
        private double applePrice;
        private double googlePrice;

        public StockGrabber()
        {
            observers = new List<IObserver>();
        }

        public void Register(IObserver newObserver)
        {
            observers.Add(newObserver);
        }

        public void Unregister(IObserver deleteObserver)
        {
            observers.Remove(deleteObserver);

            Console.WriteLine("Observer {0} deleted", deleteObserver);
        }

        public void NotifyObserver()
        {
            this.observers.ForEach(o=>o.Update(ibmPrice, applePrice, googlePrice));
        }

        public void SetIbmPrice(double newIbmPrice)
        {
            this.ibmPrice = newIbmPrice;
            NotifyObserver();
        }

        public void SetApplePrice(double newApplePrice)
        {
            this.applePrice = newApplePrice;
            NotifyObserver();
        }

        public void SetGooglePrice(double newGooglePrice)
        {
            this.googlePrice = newGooglePrice;
            NotifyObserver();
        }
    }
}
