using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            StockGrabber grabber = new StockGrabber();
            StockObserver obsever1 =  new StockObserver(grabber);

            grabber.SetIbmPrice(200);
            grabber.SetApplePrice(500);
            grabber.SetGooglePrice(260);

            grabber.SetIbmPrice(260);
            grabber.SetApplePrice(510);
            grabber.SetGooglePrice(280);
        }
    }
}
