calls();
static void calls()
{
    Console.Write("Количество номеров: ");
    int n = int.Parse(Console.ReadLine());

    List<Call> calls = new List<Call>();

    Console.WriteLine("Введите через ПРОБЕЛ номер телефона, с которого звонили;\nномер телефона, на который звонили; дату звонка; количество минут");
    for (int i = 0; i < n; i++)
    {
        string[] data = Console.ReadLine().Split();

        string calledNum = data[0];
        string answeredNum = data[1];
        string date = data[2];
        int minutes = int.Parse(data[3]);
        calls.Add(new Call(calledNum, answeredNum, date, minutes));
    }

    Console.Write("Введите номер, для которого вы хотите определить частоту звонков: ");
    string SubNum = Console.ReadLine();

    Dictionary<string, Dictionary<string, int>> callFrequency = new Dictionary<string, Dictionary<string, int>>();
    HashSet<string> numbers = new HashSet<string>();
    foreach (Call call in calls) numbers.Add(call.calledNum);

    foreach (Call call in calls)
    {
        if (call.calledNum == SubNum)
        {
            if (!callFrequency.ContainsKey(call.date))
            {
                callFrequency[call.date] = new Dictionary<string, int>();
            }

            if (!callFrequency[call.date].ContainsKey(call.answeredNum))
            {
                callFrequency[call.date][call.answeredNum] = 0;
            }
            callFrequency[call.date][call.answeredNum] += 1;
        }
    }
    Console.WriteLine($"Абонент {SubNum}");
    foreach (string date in callFrequency.Keys)
    {
        Console.WriteLine($"Дата: {date}. Номер, на который звонил чаще всего: {(string)SearchMaxFrequency(callFrequency[date])[0]}; {(int)SearchMaxFrequency(callFrequency[date])[1]} раз");
    }
    Console.WriteLine("-------------------------");
    foreach (string num in numbers)
    {
        Dictionary<string, Dictionary<string, int>> callDuration = new Dictionary<string, Dictionary<string, int>>();
        foreach (Call call in calls)
        {
            if (call.calledNum == num)
            {
                if (!callDuration.ContainsKey(call.date))
                {
                    callDuration[call.date] = new Dictionary<string, int>();
                }

                if (!callDuration[call.date].ContainsKey(call.answeredNum))
                {
                    callDuration[call.date][call.answeredNum] = 0;
                }
                callDuration[call.date][call.answeredNum] += call.minutes;
            }
        }
        Console.WriteLine($"Абонент {num}");
        foreach (string date in callDuration.Keys)
        {
            Console.WriteLine($"Дата: {date}. Номер, с которым дольше всего говорил: {(string)SearchMaxFrequency(callDuration[date])[0]}; {(int)SearchMaxFrequency(callDuration[date])[1]} минут");
        }
        Console.WriteLine();
    }

}
static List<object> SearchMaxFrequency(Dictionary<string, int> callFrequency)
{
    string number = "";
    int MaxFrequency = -100;
    List<object> results = new List<object>();
    foreach (string num in callFrequency.Keys)
    {
        if (callFrequency[num] > MaxFrequency)
        {
            MaxFrequency = callFrequency[num];
            number = num;
        }
    }
    results.Add(number);
    results.Add(MaxFrequency);
    return results;
}

class Call
{
    public string calledNum { get; set; }
    public string answeredNum { get; set; }
    public string date { get; set; }
    public int minutes { get; set; }
    public Call(string calledNum, string answeredNum, string date, int minutes)
    {
        this.calledNum = calledNum;
        this.answeredNum = answeredNum;
        this.date = date;
        this.minutes = minutes;
    }
}