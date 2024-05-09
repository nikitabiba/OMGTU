string path = @"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Text.txt";
using (StreamReader sr = new StreamReader(path))
{
    string[] text = sr.ReadToEnd().Split('\n'); // в файле содержатся строки-элементы в формате: фамилия_имя_отчество номер город
    string SelectTown = Console.ReadLine();
    People[] peoples = new People[text.Length];
    for (int i = 0; i < text.Length; i++)
    {
        string[] newText = text[i].Split(' ');
        peoples[i] = new People(newText[0], int.Parse(newText[1]), newText[2]);
    }
    List<string> selectedTowns = new List<string>();
    List<string> surnames = new List<string>();
    List<string> namesAndTowns = new List<string>();
    foreach(People p in peoples)
    {
        if (p.Town.Trim() == SelectTown) selectedTowns.Add(string.Join(' ', p.Name.Split('_')));
        surnames.Add(p.Name.Split('_')[0]);
        namesAndTowns.Add($"{string.Join(' ', p.Name.Split('_'))}: {p.Town}".Trim());
    }
    Directory.CreateDirectory(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki");
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\SelectedTowns.txt"))
    {
        foreach (var e in selectedTowns) sw.WriteLine(e);
    }
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\Surnames.txt"))
    {
        foreach (var e in surnames) sw.WriteLine(e);
    }
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\NamesAndTowns.txt"))
    {
        foreach (var e in namesAndTowns) sw.WriteLine(e);
    }
}
struct People
{
    public string Name { get; set; }
    public int Num { get; set; }
    public string Town { get; set; }
    public People(string name, int num, string town)
    {
        Name = name;
        Num = num;
        Town = town;
    }
}