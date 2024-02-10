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
            int count = 0;
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
            List<List<char>> masdotes = new List<List<char>>();
            for (int i = 0; i < 3; i++) masdotes.Add(new List<char>());
            List<char> dotes = new List<char>();
            foreach (string x in dorogi.Keys)
            {
                if (!dotes.Contains(x[0]) && !dotes.Contains(x[1]))
                {
                    dotes.Add(x[0]); dotes.Add(x[1]);
                    c += dorogi[x];
                    masdotes[count].Add(x[0]); masdotes[count].Add(x[1]);
                    count += 1;
                }
                else if (dotes.Contains(x[0]) && !dotes.Contains(x[1]))
                {
                    for (int i = 0; i < masdotes.Count; i++)
                    {
                        if (masdotes[i].Contains(x[0]))
                        {
                            masdotes[i].Add(x[1]); dotes.Add(x[1]);
                            c += dorogi[x];
                            break;
                        }
                    }
                }
                else if (dotes.Contains(x[1]) && !dotes.Contains(x[0]))
                {
                    for (int i = 0; i < masdotes.Count; i++)
                    {
                        if (masdotes[i].Contains(x[1]))
                        {
                            masdotes[i].Add(x[0]); dotes.Add(x[0]);
                            c += dorogi[x];
                            break;
                        }
                    }
                }
                else if (dotes.Contains(x[0]) && dotes.Contains(x[1]))
                {
                    for (int i = 0; i < masdotes.Count; i++)
                    {
                        if (masdotes[i].Contains(x[1]) && masdotes[i].Contains(x[0]))
                        {
                            break;
                        }
                        else if (masdotes[i].Contains(x[1]) && !masdotes[i].Contains(x[0]))
                        {
                            for (int j = 0; j < masdotes.Count; j++) if (masdotes[j].Contains(x[0]))
                                {
                                    masdotes[i] = Union(masdotes[i], masdotes[j]);
                                    c += dorogi[x];
                                    count -= 1;
                                    masdotes.RemoveAt(j);
                                    break;
                                }
                        }
                        else if (masdotes[i].Contains(x[0]) && !masdotes[i].Contains(x[1]))
                        {
                            for (int j = 0; j < masdotes.Count; j++) if (masdotes[j].Contains(x[1]))
                                {
                                    masdotes[i] = Union(masdotes[i], masdotes[j]);
                                    c += dorogi[x];
                                    count -= 1;
                                    masdotes.RemoveAt(j);
                                    break;
                                }
                        }
                    }
                }
            }
            Console.WriteLine(c);
        }
        public static List<char> Union(List<char> a, List<char> b)
        {
            List<char> c = new List<char>();    
            for (int i = 0; i < a.Count; i++) if (!c.Contains(a[i])) c.Add(a[i]);
            for (int i = 0; i < b.Count; i++) if (!c.Contains(b[i])) c.Add(b[i]);
            return c;
        }
    }
}
