using System;
public class Program
{
    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine()), a, b, summ = 0, raz11 = 100000, raz21 = 100000, raz12 = 100000, raz22 = 100000;
        for (int i = 0; i < n; i++)
        {
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            if (a > b) summ += a;
            else summ += b;
            if (Math.Abs(a - b) % 3 == 1) if (Math.Abs(a - b) <= raz11)
                {
                    raz12 = raz11;
                    raz11 = Math.Abs(a - b);
                }
            if (Math.Abs(a - b) % 3 == 2) if (Math.Abs(a - b) <= raz21)
                {
                    raz22 = raz21;
                    raz21 = Math.Abs(a - b);
                }
        }
        if (summ % 3 == 1)
        {
            if ((raz21 + raz22) < raz11) summ -= (raz21 + raz22);
            else summ -= raz11;
        }
        if (summ % 3 == 2)
        {
            if ((raz11 + raz12) < raz21) summ -= (raz11 + raz12);
            else summ -= raz21;
        }
        Console.WriteLine(summ);
    }
}
