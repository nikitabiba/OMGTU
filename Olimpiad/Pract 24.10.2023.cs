using System;
public class Program
{
    public static void Main()
    {
        int N = Convert.ToInt32(Console.ReadLine());
        int[] mas = new int[N + 1];
        mas[1] = 0;
        mas[2] = 0;
        mas[3] = 1;
        for (int i = 4; i < mas.Length; i++) mas[i] = mas[i / 2] + mas[i - (i / 2)];
        Console.WriteLine(mas[N]);
    }
}