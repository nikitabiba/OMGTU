using System;
using System.Security.AccessControl;
using System.Security.Cryptography;

public class Program
{
    public static void Main()
    {
        int k = Convert.ToInt32(Console.ReadLine()), p = Convert.ToInt32(Console.ReadLine());
        int[] mas = new int[k - 1];
        for (int i = 0; i < k - 1; i++) mas[i] = Convert.ToInt32(Console.ReadLine());
        int[] road = new int[mas.Sum() + 1];
        for (int i = 1; i < road.Length + 1; i++) road[i - 1] = i;
        int j1 = 0;
        k = 0;
        for (int i = 0; i < road.Length; i++)
        {
            i = j1;
            for (int i1 = i + 1; i1 < road.Length; i1++)
            {
                if ((road[i1] - road[i]) == mas[k])
                {
                    k++;
                    j1 = i1;
                    break;
                }
                else road[i1] = 0;
            }
        }
        int[] mas2 = new int[mas.Length + 1];
        int c = 0;
        for (int i = 0; i < road.Length; i++) if (road[i] != 0)
            {
                mas2[c] = road[i];
                c++;
            }
        int[] roadcopy = new int[road.Length];
        road.CopyTo(roadcopy, 0);
        int mini = 0, minr = 10000000;
        for (int i = 0; i < road.Length; i++)
        {
            int summ = 0;
            if (road[i] == 0)
            {
                int a = 0, b = 0;
                road[i] = i + 1;
                for (int t = 0; t < mas2.Length - 1; t++) if (mas2[t] < road[i] && road[i] < mas2[t + 1])
                    {
                        a = mas2[t];
                        b = mas2[t + 1];
                        break;
                    }
                if ((road[i] - a) >= p && (b - road[i]) >= p) for (int j = 0; j < mas2.Length; j++) summ += Math.Abs(road[i] - mas2[j]);
            }
            roadcopy.CopyTo(road, 0);
            if (summ < minr && summ != 0)
            {
                minr = summ;
                mini = i + 1;
            }
        }
        if (mini == 0) Console.WriteLine("Нельзя поставить заправку");
        else Console.WriteLine($"Оптимальное место: {mini}\nМинимальная сумма расстояний: {minr}");
    }
}