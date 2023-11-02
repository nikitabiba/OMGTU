using System;
public class Program
{
    public static void Main()
    {
        int kol = Convert.ToInt32(Console.ReadLine()), shag = Convert.ToInt32(Console.ReadLine()), counter = 0, count = 0;
        int[] mas = new int[kol];
        while (counter < kol - 1) for (int i = 0; i < kol; i++)
            {
                if (mas[i] != '-') count++;
                if (count == shag && mas[i] != '-')
                {
                    mas[i] = '-';
                    counter++;
                    count = 0;
                }
            }
        if (mas.Contains(0)) Console.WriteLine(Array.IndexOf(mas, 0) + 1);
    }
}