using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication8
{
    class Program
    {
        static void Main(string[] args)
        {
            int ks = int.Parse(Console.ReadLine()), kb = int.Parse(Console.ReadLine()), shag = int.Parse(Console.ReadLine()), kso = int.Parse(Console.ReadLine()), kbo = int.Parse(Console.ReadLine());
            char[] mas = new char[ks + kb];
            for (int i = 0; i < mas.Length; i++) mas[i] = '?';
            int counterS = 0, counterB = 0, count = 0;
            bool flag = false;
            while (counterS < (ks - kso) || counterB < (kb - kbo)) for (int i = 0; i < mas.Length; i++)
                {
                    if (i == 0 && flag == false)
                    {
                        continue;
                        flag = true;
                    }
                    if (mas[i] != 's' && mas[i] != 'b') count++;
                    if (counterS < (ks - kso) && count == shag)
                    {
                            mas[i] = 's';
                            counterS++;
                            count = 0;
                    }
                    else if (counterB < (kb - kbo) && count == shag)
                    {
                            mas[i] = 'b';
                            counterB++;
                            count = 0;
                    }
                }
            while (mas.Contains('?')) for (int i = 0; i < mas.Length; i++)
                {
                    if (mas[i] != '?') count++;
                    if (mas[i] == '?' && count == shag)
                    {
                        mas[i] = 's';

                    }
                }
            foreach (char i in mas) Console.Write(i + " ");
        }
    }
}
