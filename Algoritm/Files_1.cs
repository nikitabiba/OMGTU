using System.Linq.Expressions;

string path = @"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Text.txt";
using (StreamReader sr = new StreamReader(path))
{
    string[] text = sr.ReadToEnd().Split('\n'); // в файле содержатся строки-элементы в формате: фамилия_имя_отчество номер город
    string SelectTown = Console.ReadLine();
    var elems = from t in text
                let str = t.Split(' ')
                select new
                {
                    Name = str[0],
                    Num = int.Parse(str[1]),
                    Town = str[2],
                };
    var SelectedTown = from elem in elems
                       where elem.Town.Trim() == SelectTown
                       select string.Join(' ', elem.Name.Split('_'));
    var Surnames = from elem in elems
                   select elem.Name.Split('_')[0];
    var NamesAndTowns = from elem in elems
                        select $"{string.Join(' ', elem.Name.Split('_'))}: {elem.Town}".Trim();
    Directory.CreateDirectory(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki");
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\SelectedTowns.txt"))
    {
        foreach (var e in SelectedTown) sw.WriteLine(e);
    }
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\Surnames.txt"))
    {
        foreach (var e in Surnames) sw.WriteLine(e);
    }
    using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\viborki\NamesAndTowns.txt"))
    {
        foreach (var e in NamesAndTowns) sw.WriteLine(e);
    }
}
