using (StreamReader sr = new StreamReader(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\MainC#\Input.txt"))
{
    List<int> ints = (from i in sr.ReadToEnd().Trim().Split(' ') select int.Parse(i)).ToList();
    // Или создать пустой лист и в цикле проходиться по элементам sr.ReadToEnd().Trim().Split(' '), превращать в int и добавлять в лист(на случай если мы не знаем LINQ)
    // Следующие части кода даже легче сделать именно с помощью циклов, нежели линком, но так оптимизированее
    int count = (from i in ints from j in ints.Skip(ints.IndexOf(i) + 1) where Math.Abs(i * j) % 2 == 0 select (i * j)).Count();
    Console.WriteLine(count);
}