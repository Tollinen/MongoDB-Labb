namespace TEST_MongoDB
{
    internal class NumberCheck
    {
        public int CheckInt(int MaxNum, bool isMaxNum)
        {
            bool loop = true;
            int Num = 0;
            while (loop)
            {
                try
                {
                    Num = Convert.ToInt32(Console.ReadLine());
                    loop = false;
                    if (isMaxNum)
                    {
                        if (Num > MaxNum)
                        {
                            Console.WriteLine($"Only numbers equal to or lower than {MaxNum} are accepted.");
                            loop = true;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine($"Only numbers are accepted.");
                }
            }
            return Num;
        }
        public double CheckDouble(long MaxNum, bool isMaxNum)
        {
            bool loop = true;
            double Num = 0;
            while (loop)
            {
                try
                {
                    Num = Convert.ToDouble(Console.ReadLine());
                    loop = false;
                    if (isMaxNum)
                    {
                        if (Num > MaxNum)
                        {
                            Console.WriteLine($"Only numbers equal to or lower than {MaxNum} are accepted.");
                            loop = true;
                        }
                        else
                        {
                            loop = false;
                        }
                    }
                }
                catch
                {
                    Console.WriteLine($"Only numbers are accepted.");
                }
            }
            return Num;
        }


    }
}
