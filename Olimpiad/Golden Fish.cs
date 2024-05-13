int k = int.Parse(Console.ReadLine());
List<char[]> words = new List<char[]>();
for (int i = 0; i < k; i++)
{
    char[] d = Console.ReadLine().ToCharArray();
    words.Add(d);
}

int l = int.Parse(Console.ReadLine());
Dictionary<string, int> FirstChar = new Dictionary<string, int>();
for (int i = 0; i < l; i++)
{
    string[] ll = Console.ReadLine().Split();
    FirstChar.Add(ll[0], int.Parse(ll[1]));
}

Dictionary<string, int> LastChar = new Dictionary<string, int>();
int b = int.Parse(Console.ReadLine());
for (int i = 0; i < b; i++)
{
    string[] bb = Console.ReadLine().Split();
    LastChar.Add(bb[0], int.Parse(bb[1]));
}

Dictionary<string, int> c = new Dictionary<string, int>();
foreach (char[] word in words)
{
    if (FirstChar.ContainsKey((Convert.ToString(word[0]))) && LastChar.ContainsKey((Convert.ToString(word[word.Length - 1]))))
    {
        string key = Convert.ToString(word[0]) + Convert.ToString(word[word.Length - 1]);
        if (c.ContainsKey(key)) c[key]++;
        else c.Add(key, 1);
    }
}

int count = 0;
bool check = true;
while (c.Count > 0 && check)
{
    check = false;
    foreach (var co in c)
    {
        string key = co.Key;
        int minn = Math.Min(FirstChar[Convert.ToString(key[0])], LastChar[Convert.ToString(key[1])]);
        if (co.Value < minn)
        {
            count++;
            FirstChar[Convert.ToString(key[0])]--;
            LastChar[Convert.ToString(key[1])]--;
            c[key]--;
        }
        if (c[key] == 0 || FirstChar[Convert.ToString(key[0])] == 0 || LastChar[Convert.ToString(key[1])] == 0) c.Remove(key);
        if (c.ContainsKey(key) && c[key] != co.Value) check = true;
    }
}
while (c.Count > 0)
{
    string key = "";
    int key_value = 0;
    foreach (var first in FirstChar)
    {
        string key_first = first.Key;
        foreach (var last in LastChar)
        {
            string key_last = last.Key;
            string all_key = key_first + key_last;
            int minn = Math.Min(first.Value, last.Value);
            if (minn != 0 && minn > key_value && c.ContainsKey(all_key))
            {
                key = all_key;
                key_value = minn;
            }
        }
    }
    if (key == "") key = c.FirstOrDefault(x => x.Value == c.Values.Max()).Key;
    if (c[key] > 0 && FirstChar[Convert.ToString(key[0])] > 0 && LastChar[Convert.ToString(key[1])] > 0)
    {
        count++;
        FirstChar[Convert.ToString(key[0])]--;
        LastChar[Convert.ToString(key[1])]--;
        c[key]--;
    }
    if (c[key] == 0 || FirstChar[Convert.ToString(key[0])] == 0 || LastChar[Convert.ToString(key[1])] == 0) c.Remove(key);
}
while (c.Count > 0)
{
    foreach (var combination in c)
    {
        string key = combination.Key;
        if (c[key] > 0 && FirstChar[Convert.ToString(key[0])] > 0 && LastChar[Convert.ToString(key[1])] > 0)
        {
            count++;
            FirstChar[Convert.ToString(key[0])]--;
            LastChar[Convert.ToString(key[1])]--;
            c[key]--;
        }
        if (c[key] == 0 || FirstChar[Convert.ToString(key[0])] == 0 || LastChar[Convert.ToString(key[1])] == 0) c.Remove(key);
    }
}
Console.WriteLine($"Запас волшебных слов у старика: {count}");