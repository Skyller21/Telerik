namespace Stools
{
    using System;
    using System.Linq;

    public class Stool
    {
        public Stool(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
    public class Program
    {
        public static Stool[] stools;
        public static int n;
        public static int[,,] memo;

        public static void Main()
        {
            n = int.Parse(Console.ReadLine());
            stools = new Stool[n];
            memo = new int[1 << n, 16, 4];

            for (int i = 0; i < n; i++)
            {
                int[] line = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
                stools[i] = new Stool(line[0], line[1], line[2]);
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {
                result = Math.Max(result, MaxHight((1 << n) - 1, i, 0));
                result = Math.Max(result, MaxHight((1 << n) - 1, i, 1));
                result = Math.Max(result, MaxHight((1 << n) - 1, i, 2));
            }

            Console.WriteLine(result);
        }


        public static int MaxHight(int used, int top, int side)
        {
            if (memo[used, top, side] != 0)
            {
                return memo[used, top, side];
            }

            if (used == (1 << top))
            {
                if (side == 0)
                {
                    memo[used, top, side] = stools[top].X;
                    return stools[top].X;
                }

                if (side == 1)
                {
                    memo[used, top, side] = stools[top].Y;
                    return stools[top].Y;
                }

                return stools[top].Z;
            }

            int fromStools = used ^ (1 << top);

            int sideX = side == 0 ? stools[top].Y : stools[top].X;

            int sideY = side == 2 ? stools[top].Y : stools[top].Z;

            int sideH = stools[top].Y + stools[top].X + stools[top].Z - sideX - sideY;

            int result = sideH;

            for (int i = 0; i < n; i++)
            {
                if (((fromStools >> i) & 1) == 1)
                {
                    if ((stools[i].Y >= sideX && stools[i].Z >= sideY) ||
                        (stools[i].Y >= sideY && stools[i].Z >= sideX))
                    {

                        result = Math.Max(result, MaxHight(fromStools, i, 0) + sideH);
                    }

                    if (stools[i].X == stools[i].Y && stools[i].X == stools[i].Z)
                    {
                        continue;
                    }

                    if ((stools[i].X >= sideX && stools[i].Z >= sideY) ||
                        (stools[i].X >= sideY && stools[i].Z >= sideX))
                    {
                        result = Math.Max(result, MaxHight(fromStools, i, 1) + sideH);
                    }

                    if ((stools[i].X >= sideX && stools[i].Y >= sideY) ||
                        (stools[i].X >= sideY && stools[i].Y >= sideX))
                    {
                        result = Math.Max(result, MaxHight(fromStools, i, 2) + sideH);
                    }
                }
            }

            memo[used, top, side] = result;
            return result;
        }
    }
}