set();


calls();


static void set()
{
    HashSet<int> set1 = new HashSet<int>();
    HashSet<int> set2 = new HashSet<int>();
    HashSet<int> set3 = new HashSet<int>();

    Console.WriteLine("Элементов в первом множестве: ");
    int n1 = int.Parse(Console.ReadLine());
    Console.WriteLine("Перечислите элементы: ");
    for (int i = 0; i < n1; i++) set1.Add(int.Parse(Console.ReadLine()));

    Console.WriteLine("\nЭлементов во втором множестве: ");
    int n2 = int.Parse(Console.ReadLine());
    Console.WriteLine("Перечислите элементы: ");
    for (int i = 0; i < n2; i++) set2.Add(int.Parse(Console.ReadLine()));

    Console.WriteLine("\nЭлементов в третьем множестве: ");
    int n3 = int.Parse(Console.ReadLine());
    Console.WriteLine("Перечислите элементы: ");
    for (int i = 0; i < n3; i++) set3.Add(int.Parse(Console.ReadLine()));
    Console.WriteLine();

    HashSet<int> union = set1.Union(set2).ToHashSet<int>();
    union = union.Union(set3).ToHashSet<int>();

    Console.WriteLine("Объединение множеств");
    if (union.Count > 0)
    {
        foreach (int i in union) Console.Write(i + " ");
        Console.WriteLine("\n");
    }
    else Console.WriteLine("Пустое множество\n");
    HashSet<int> intersect = set1.Intersect(set2).ToHashSet<int>();
    intersect = intersect.Intersect(set3).ToHashSet<int>();

    Console.WriteLine("Пересечение множеств");
    if (intersect.Count > 0)
    {
        foreach (int i in intersect) Console.Write(i + " ");
        Console.WriteLine("\n");
    }
    else Console.WriteLine("Пустое множество\n");

    HashSet<int> except1 = union.Except(set1).ToHashSet<int>();
    HashSet<int> except2 = union.Except(set2).ToHashSet<int>();
    HashSet<int> except3 = union.Except(set3).ToHashSet<int>();

    int j = 1;
    foreach (HashSet<int> ex in new HashSet<int>[] { except1, except2, except3 })
    {
        Console.WriteLine($"Дополнение множества {j}");
        if (ex.Count > 0)
        {
            foreach (int el in ex) Console.Write(el + " ");
            Console.WriteLine("\n");
        }
        else Console.WriteLine("Пустое множество\n");
        j++;
    }
}


static void calls()
{
    Console.WriteLine("Введите количество номеров");
    int k = Convert.ToInt32(Console.ReadLine());
    HashSet<string> hs = new HashSet<string>();
    for (int i = 0; i < k; i++)
    {
        Console.WriteLine("Введите номер и количество минут через пробел");
        string s = Convert.ToString(Console.ReadLine());
        string[] m = s.Split(' ');
        hs.Add(m[0]);
    }
    Console.WriteLine($"Уникальных номеров - {hs.Count}:");
    foreach (string c in hs)
        Console.WriteLine(c);
}