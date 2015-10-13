namespace ObserverPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var grabber = new StockGrabber();
            var obsever1 = new StockObserver(grabber);

            grabber.SetIbmPrice(200);
            grabber.SetApplePrice(500);
            grabber.SetGooglePrice(260);

            grabber.SetIbmPrice(260);
            grabber.SetApplePrice(510);
            grabber.SetGooglePrice(280);
        }
    }
}