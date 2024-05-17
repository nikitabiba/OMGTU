using System.Collections;

Console.Write("Количество записей: ");
int n = int.Parse(Console.ReadLine());

Queue<Call> datas = new Queue<Call>();

Console.WriteLine("Введите через ПРОБЕЛ номер телефона, дату, время начала разговора, количество минут");
for (int i = 0; i < n; i++)
{
    string[] dataString = Console.ReadLine().Split(" ");
    Call data = new Call(dataString[0], dataString[1], dataString[2], int.Parse(dataString[3]));
    datas.Enqueue(data);
}

Dictionary<string, int> numbers1 = new Dictionary<string, int>();
Hashtable numbers2 = new Hashtable();

Dictionary<string, int> dates1 = new Dictionary<string, int>();
Hashtable dates2 = new Hashtable();

foreach (Call data in datas)
{
    //Номера телефонов
    if (!numbers1.ContainsKey(data.Number)) numbers1[data.Number] = 0;
    numbers1[data.Number] += data.Minutes;

    if (!numbers2.ContainsKey(data.Number)) numbers2[data.Number] = 0;
    int minutes = data.Minutes + (int)numbers2[data.Number];
    numbers2[data.Number] = minutes;

    //Даты
    if (!dates1.ContainsKey(data.Date)) dates1[data.Date] = 0;
    dates1[data.Date] += data.Minutes;

    if (!dates2.ContainsKey(data.Date)) dates2[data.Date] = 0;
    int minutes2 = data.Minutes + (int)dates2[data.Date];
    dates2[data.Date] = minutes2;
}

Console.WriteLine("\nДанные о суммарном количестве минут каждого номера из Dictionary");
foreach (string num in numbers1.Keys) Console.WriteLine($"{num}: {numbers1[num]}");

Console.WriteLine("\nДанные о суммарном количестве минут каждого номера из Hashtable");
foreach (string num in numbers2.Keys) Console.WriteLine($"{num}: {numbers2[num]}");


Console.WriteLine("\nДанные о суммарном количестве минут в каждую дату из Dictionary");
foreach (string date in dates1.Keys) Console.WriteLine($"{date}: {dates1[date]}");

Console.WriteLine("\nДанные о суммарном количестве минут в каждую дату из Hashtable");
foreach (string date in dates2.Keys) Console.WriteLine($"{date}: {dates2[date]}");


class Call
{
    public string Number { get; set; }
    public string Date { get; set; }
    public string StartTime { get; set; }
    public int Minutes { get; set; }
    public Call(string num, string date, string startTime, int durationTime)
    {
        this.Number = num;
        this.Date = date;
        this.StartTime = startTime;
        this.Minutes = durationTime;
    }
}