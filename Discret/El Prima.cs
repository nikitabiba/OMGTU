using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication26
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dorogi = new Dictionary<string, int>();
            const int n = 1000000;
            int c = 0;
            int[,] graf = { { n, 4, n, 3, 6, 1, n }, { 4, n, 2, 3, 7, 6, 1 }, { n, 2, n, n, 4, n, 2 }, { 3, 3, n, n, 1, 5, 3 }, { 6, 7, 4, 1, n, 3, 6 }, { 1, 6, n, 5, 3, n, 7 }, { n, 1, 2, 3, 6, 7, n } };
            for (int i = 1; i < 8; i++)
            {
                for (int j = 1; j < 8; j++)
                {
                    if (graf[i - 1, j - 1] != n && !dorogi.ContainsKey(Convert.ToString(j) + Convert.ToString(i)))
                    {
                        dorogi.Add(Convert.ToString(i) + Convert.ToString(j), graf[i - 1, j - 1]);
                    }
                }
            }
            dorogi = dorogi.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            List<char> dum = new List<char>();
            foreach(string r in dorogi.Keys)
            {
                if (!dum.Contains(r[0])) dum.Add(r[0]);
                if (!dum.Contains(r[1])) dum.Add(r[1]);
            }
            int count = dum.Count;
            List<char> dotes = new List<char>();
            dotes.Add('1');
            while(dotes.Count != count)
            {
                Dictionary<string, int> dostup_ver = new Dictionary<string,int>();
                foreach(char f in dotes)
                {
                    foreach (string reb in dorogi.Keys)
                    {
                        if (reb.Contains(f) && !dotes.Contains(reb[0]))
                        {
                            dostup_ver.Add(reb, dorogi[reb]);
                        }
                        else if (reb.Contains(f) && !dotes.Contains(reb[1]))
                        {
                            dostup_ver.Add(reb, dorogi[reb]);
                        }
                    }
                }
                string iskr = "323";
                foreach(string h in dostup_ver.Keys)
                {
                    if (dostup_ver[h] == dostup_ver.Values.Min())
                    {
                        iskr = h;
                        c += dostup_ver[h];
                        break;
                    }
                }
                if (dotes.Contains(iskr[0])) dotes.Add(iskr[1]);
                else dotes.Add(iskr[0]);
                dostup_ver.Clear();
            }
            Console.WriteLine("!!!" + c + "!!!");
        }

    }
}
