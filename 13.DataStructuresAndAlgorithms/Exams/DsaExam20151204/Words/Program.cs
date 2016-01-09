namespace Words
{
    using System;


    // From Cuki's algorith KMP :)
    class StartUp
    {
        static void Main()
        {
            var counter = 0;
            var counter1 = 0;
            var counter2 = 0;

            string pattern = Console.ReadLine();
            string text = Console.ReadLine();


            int n = text.Length;
            int m = pattern.Length;

            if (m > n)
            {
                return;
            }


            // precompute

            int[] fl = new int[pattern.Length + 1];
            fl[0] = -1;

            for (int i = 1; i < pattern.Length; i++)
            {
                int j = fl[i];
                while (j >= 0 && pattern[j] != pattern[i])
                {
                    j = fl[j];
                }
                fl[i + 1] = j + 1;
            }

            // search

            int matched = 0;
            for (int i = 0; i < n; i++)
            {
                while (matched >= 0 && text[i] != pattern[matched])
                {
                    matched = fl[matched];
                }

                matched++;

                if (matched == pattern.Length)
                {
                    counter++;
                    matched = fl[matched];
                }
            }



            for (int k = 1; k < pattern.Length; k++)
            {
                var prefix = pattern.Substring(0, k);
                var suffix = pattern.Substring(k);

                counter1 = 0;
                counter2 = 0;

                // precompute

                fl = new int[prefix.Length + 1];
                fl[0] = -1;

                for (int i = 1; i < prefix.Length; i++)
                {
                    int j = fl[i];
                    while (j >= 0 && prefix[j] != prefix[i])
                    {
                        j = fl[j];
                    }
                    fl[i + 1] = j + 1;
                }

                // search

                matched = 0;
                for (int i = 0; i < n; i++)
                {
                    while (matched >= 0 && text[i] != prefix[matched])
                    {
                        matched = fl[matched];
                    }

                    matched++;

                    if (matched == prefix.Length)
                    {
                        counter1++;
                        matched = fl[matched];
                    }
                }

                // Precompute


                fl = new int[suffix.Length + 1];
                fl[0] = -1;

                for (int i = 1; i < suffix.Length; i++)
                {
                    int j = fl[i];
                    while (j >= 0 && suffix[j] != suffix[i])
                    {
                        j = fl[j];
                    }
                    fl[i + 1] = j + 1;
                }

                // search

                matched = 0;
                for (int i = 0; i < n; i++)
                {
                    while (matched >= 0 && text[i] != suffix[matched])
                    {
                        matched = fl[matched];
                    }

                    matched++;

                    if (matched == suffix.Length)
                    {
                        counter2++;
                        matched = fl[matched];
                    }
                }

                counter += counter1 * counter2;
            }


            Console.WriteLine(counter);



        }
    }
}
