using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            int rast = int.Parse(Console.ReadLine()), kol = int.Parse(Console.ReadLine()), speed = int.Parse(Console.ReadLine()), count = 0;
            
            float[] masr = new float[kol + 1];

            masr[masr.Length - 1] = rast;
            
            int[] masn = new int[kol + 1];

            string[] voshod = Console.ReadLine().Split();
            float vosh = float.Parse(voshod[0]) + float.Parse(voshod[1]) / 60;
            
            string[] zakat = Console.ReadLine().Split();
            float zak = float.Parse(zakat[0]) + float.Parse(zakat[1]) / 60;
            
            for (int i = 0; i < masr.Length - 1; i++) masr[i] = int.Parse(Console.ReadLine());
            float maxproh = (zak - vosh) * speed;
            float tekras = 0;

            if (maxproh > rast) Console.WriteLine("Туристы дошли до точки за один день и нигде не останавливались.");
            else
            {
                for (int i = 0; i < masr.Length - 1; i++)
                {
                    if ((masr[i] - tekras) <= maxproh && (masr[i + 1] - tekras) > maxproh)
                    {
                        count++;
                        masn[i] = i + 1;
                        tekras = masr[i];
                    }
                }
                if (masn[masn.Length - 2] != 0 && (rast - tekras) <= maxproh)
                {
                    Console.Write("Туристы побывали в пунктах ");
                    foreach (int x in masn) if (x != 0) Console.Write(x + " ");
                    Console.WriteLine($"и дошли до точки за {count + 1} дней");
                }
                else if (masn[masn.Length - 1] == 0) Console.WriteLine("Туристы не дошли до точки.");
            }
        }
    }
}
