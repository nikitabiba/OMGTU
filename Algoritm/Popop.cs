using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] mas = new int[m, n];
            Zapolnenie(mas, m, n);
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write(mas[i, j] + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < m; i++)
                Console.WriteLine(PoiskMin(mas, i, n));
            Console.WriteLine();
            for (int i = 0; i < n; i++)
                Console.WriteLine(CountMax(mas, i, m, n));
            int[,] mas1 = Perestanovka(mas, m, n);
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write(mas1[i, j] + " ");
            }
            

        }
        static int[,] Zapolnenie(int[,]mas, int m, int n)
        {
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    mas[i, j] = Convert.ToInt32(Console.ReadLine());
            return mas;
        }
        static int PoiskMin(int[,] mas, int k, int n)
        {
            int min = 100000000;
            for (int j = 0; j < n; j++)
                if (mas[k, j] < min)
                    min = mas[k, j];
            return min;
        }

        static int CountMax(int[,] mas, int k, int m, int n)
        {
            int max = -10000000;
            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                    if (mas[i, j] > max)
                        max = mas[i, j];
            int count = 0;
            for (int i = 0; i < m; i++)
                if (mas[i, k] == max)
                    count++;
            return count;
        }

        static int[,] Perestanovka(int[,] mas, int m, int n)
        {
            if (m % 2 == 1) for (int i = 0; i < m - 1; i += 2) for (int j = 0; j < n; j++)
                    {
                        int t = 0;
                        t = mas[i, j];
                        mas[i, j] = mas[i + 1, j];
                        mas[i + 1, j] = t;
                    }
            else for (int i = 0; i < m; i += 2) for (int j = 0; j < n; j++)
                    {
                        int t = 0;
                        t = mas[i, j];
                        mas[i, j] = mas[i + 1, j];
                        mas[i + 1, j] = t;
                    }
            return mas;
        }
    }
}
