List<Thing> ivanThings = new List<Thing> { new Thing(3, 10), new Thing(5, 20) };
List<Thing> petrThings = new List<Thing> { new Thing(2, 15), new Thing(4, 25) };
List<Thing> annaThings = new List<Thing> { new Thing(1, 30), new Thing(3, 40) };
List<Thing> olegThings = new List<Thing> { new Thing(4, 10), new Thing(6, 15) };
List<Thing> mariaThings = new List<Thing> { new Thing(2, 20), new Thing(3, 25) };
List<Thing> dmitriyThings = new List<Thing> { new Thing(1, 35), new Thing(4, 40) };
List<Thing> ekaterinaThings = new List<Thing> { new Thing(3, 15), new Thing(5, 20) };
List<Thing> alexanderThings = new List<Thing> { new Thing(2, 25), new Thing(3, 30) };
Worker ivan = new Worker("1", "Иванов Иван Иванович", "Высшее", "IT", 1000, ivanThings);
Worker petr = new Worker("2", "Петров Петр Петрович", "Среднее", "Строительство", 30, petrThings);
Worker anna = new Worker("3", "Сидорова Анна Николаевна", "Высшее", "Медицина", 200, annaThings);
Worker oleg = new Worker("4", "Васильев Олег Петрович", "Среднее", "Продажи", 50, olegThings);
Worker maria = new Worker("5", "Кузнецова Мария Сергеевна", "Высшее", "Финансы", 0, mariaThings);
Worker dmitriy = new Worker("6", "Николаев Дмитрий Александрович", "Высшее", "Образование", 45, dmitriyThings);
Worker ekaterina = new Worker("7", "Смирнова Екатерина Павловна", "Высшее", "Маркетинг", 54, ekaterinaThings);
Worker alexander = new Worker("8", "Иванов Александр Иванович", "Высшее", "Инженерия", 10, alexanderThings);
List<Worker> workers = new List<Worker> { ivan, petr, anna, oleg, maria, dmitriy, ekaterina, alexander };

var smallEarn = from w in workers where (ThingsPriceSum(w) > w.Earn) select w.FullName;
foreach (var worker in smallEarn) Console.WriteLine(worker.ToString());
Console.WriteLine();

var thingsSumPerWorker = from w in workers select new { Name = w.FullName, Count = ThingsCountSum(w) };
foreach (var worker in thingsSumPerWorker) Console.WriteLine($"{worker.Name}: {worker.Count}");
Console.WriteLine();

int thingsSum = (from w in workers select ThingsCountSum(w)).Sum();
Console.WriteLine(thingsSum.ToString());
Console.WriteLine();

int midEarnCount = (from w in workers where (0.5 * (double)ThingsPriceSum(w) <= w.Earn) select w).Count();
Console.WriteLine(midEarnCount.ToString());

static int ThingsPriceSum(Worker w) => (from t in w.Things select (t.Price * t.Count)).Sum();

static int ThingsCountSum(Worker w) => (from t in w.Things select t.Count).Sum();
class Thing
{
    public int Count { get; set; }
    public int Price { get; set; }
    public Thing(int count, int price)
    {
        this.Count = count;
        this.Price = price;
    }
}

class Worker
{
    public string Number { get; set; }
    public string FullName { get; set; }
    public string Education { get; set; }
    public string Specialize { get; set; }
    public int Earn { get; set; }
    public List<Thing> Things { get; set; }

    public Worker(string number, string fullName, string education, string specialize, int earn, List<Thing> things)
    {
        this.Number = number;
        this.FullName = fullName;
        this.Education = education;
        this.Specialize = specialize;
        this.Earn = earn;
        this.Things = things;
    }
}