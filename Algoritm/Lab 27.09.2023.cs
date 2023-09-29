using System;
public class Program
{
    public static void Main()
    {
        int n = Convert.ToInt32 (Console.ReadLine()), a, b, summ = 0, raz1 = 100000, raz2 = 100000;
        for (int i = 0; i < n; i++)
        {
            a = Convert.ToInt32 (Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());
            if (a > b) summ += a;
            else summ += b;
            if (Math.Abs(a - b) % 3 == 1) if (Math.Abs(a - b) < raz1) raz1 = Math.Abs(a - b);
            if (Math.Abs(a - b) % 3 == 2) if (Math.Abs(a - b) < raz2) raz2 = Math.Abs(a - b);
        }
        if (summ % 3 == 1) summ -= raz1;
        if (summ % 3 == 2) summ -= raz2;
        Console.WriteLine(summ);
    }
}