namespace _02.RefactorIfStatements
{
    using System;

    public class TestProgram
    {
        public static bool ShouldVisitCell { get; set; }

        public static void Main(string[] args)
        {
            // First one
            Potato potato = new Potato();

            if (potato != null)
            {
                bool isRotten = potato.IsRotten;
                bool isPeeled = potato.IsPeeled;
                if (isPeeled && isRotten)
                {
                    Cook(potato);
                }
            }

            // Second one
            const int MinX = 10;
            const int MaxX = 30;
            const int MinY = 0;
            const int MaxY = 10;
            int x = 0;
            int y = 0;

            if (IsInRange(x, y, MinX, MaxX, MinY, MaxY) & ShouldVisitCell)
            {
                VisitCell();
            }
        }
        
        private static bool IsInRange(int x, int y, int minX, int maxX, int minY, int maxY)
        {
            if ((x >= minX && x <= maxX) && (y > minY && y <= maxY))
            {
                return true;
            }

            return false;
        }

        private static void VisitCell()
        {
            throw new NotImplementedException();
        }

        private static void Cook(Potato potato)
        {
            throw new NotImplementedException();
        }
    }
}
