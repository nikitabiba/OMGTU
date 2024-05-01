int count = 0;
using (StreamReader sr = new StreamReader(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\File.txt"))
{
    string a;
    while ((a = sr.ReadLine()) != null)
    {
        if ((int.Parse(Convert.ToString(a[a.Length - 1])) % 2) == 1)
        {
            count++;
        }
    }
    Console.WriteLine(count * (count - 1) / 2);
}
