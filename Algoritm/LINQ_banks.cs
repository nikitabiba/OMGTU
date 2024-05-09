string path = @"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Text.txt";
using (StreamReader sr = new StreamReader(path))
{
    string[] text = sr.ReadToEnd().Split('\n'); // Пример строки в файле: 1 Иванов_Петр_Алексеевич 123 50,0 30,0
    var clients = from client in text
                  let c = client.Trim().Split(' ')
                  select new
                  {
                      Num = int.Parse(c[0]),
                      Name = c[1].Split("_"),
                      TelNum = int.Parse(c[2]),
                      Stonks = double.Parse(c[3]),
                      AntiStonks = double.Parse(c[4].Trim()),
                      Tax = double.Parse(c[3]) * 0.05,
                      Balance = double.Parse(c[3]) * 0.95 - double.Parse(c[4].Trim())
                  };
    var negativeBalances = from client in clients where client.Balance < 0 select client;
    int colNegativeBalances = negativeBalances.Count();
    var Balances = from client in clients select client.Balance;
    var maxBalances = from client in clients where client.Balance == Balances.Max() select client;
    int colMaxBalances = maxBalances.Count();
    var stonkses = from client in clients select client.Stonks;
    double averageStonks = stonkses.Average();
    var taxes = from client in clients select client.Tax;
    double sumTaxes = taxes.Sum();
    Console.WriteLine(colNegativeBalances);
    Console.WriteLine(colMaxBalances);
    Console.WriteLine(averageStonks);
    Console.WriteLine(sumTaxes);
}