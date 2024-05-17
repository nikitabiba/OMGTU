List<Thing> things = new List<Thing>() 
{
    new Thing(1, "Молоток", "Инструменты", 5, 300, "Склад_1"),
    new Thing(2, "Чайник", 3, 500, "Склад_2"),
    new Thing(3, "Подушка", 2, 700, "Склад_3"),
    new Thing(4, "Ноутбук", "Электроника", 1, 2000, "Склад_4"),
    new Thing(5, "Фонарик", "Инструменты", 4, 150, "Склад_1"),
    new Thing(6, "Фен", "Бытовая техника", 1, 800, "Склад_2"),
    new Thing(7, "Шампунь", "Красота и уход", 2, 200, "Склад_3"),
    new Thing(8, "Книга", "Литература", 10, 20, "Склад_4"),
    new Thing(7, "Шампунь", "Красота и уход", 10, 20, "Склад_2"),
    new Thing(8, "Книга", "Литература", 15, 15, "Склад_1")
};

var storageCounts = things.GroupBy(t => t.Storage).Select(g => new { Name = g.Key, storageCount = g.Sum(s => s.Count)});
foreach(var storageCount in storageCounts) Console.WriteLine($"{storageCount.Name}: {storageCount.storageCount}");

Console.WriteLine();

var maxPricesPerCategory = things.GroupBy(t => t.Category).Select(g => new { Name = g.Key, maxPricePerCategory = g.Max(s => s.Price)});
foreach (var maxPricePerCategory in maxPricesPerCategory) Console.WriteLine($"{maxPricePerCategory.Name}: {maxPricePerCategory.maxPricePerCategory}");

Console.WriteLine();

double averagePriceWithNoCategory = (from t in things where t.Category == "_" select  t.Price).Average();
Console.WriteLine(averagePriceWithNoCategory);

Console.WriteLine();

// Самый дешёвый товар со всех складов
double minPrice = things.Min(s => s.Price);
var minPriceThing = from t in things where t.Price == minPrice select new { Name = t.Name, Storage = t.Storage };
// Самый дешёвый товар для каждого склада
var minPricesFromStorage = things.GroupBy(t => t.Storage).Select(g => new { Name = g.Key, minPriceFromStorage = g.Min(s => s.Price)});
var minThingsFromStorage = from m in minPricesFromStorage from t in things where t.Price == m.minPriceFromStorage && t.Storage == m.Name select new { Name = t.Name, Storage = t.Storage };
foreach (var minThingFromStorage in minThingsFromStorage) Console.WriteLine($"{minThingFromStorage.Name}: {minThingFromStorage.Storage}");

Console.WriteLine();

// Сумма для всех складов
double storagesSum = (from t in things select t.Price * t.Count).Sum();
// Сумма для каждого
var storageSums = things.GroupBy(t => t.Storage).Select(g => new { Name = g.Key, summ = g.Sum(s => s.Price * s.Count)});
foreach (var storageSum in storageSums) Console.WriteLine($"{storageSum.Name}: {storageSum.summ}");


class Thing
{
    public int Num {  get; set; }
    public string Name { get; set; }
    public string Category { get; set; } = "_";
    public int Count { get; set; }
    public double Price { get; set; }
    public string Storage { get; set; }
    public Thing(int num, string name, string category, int count, double price, string storage)
    {
        Num = num;
        Name = name;
        Category = category;
        Count = count;
        Price = price;
        Storage = storage;
    }
    public Thing(int num, string name, int count, double price, string storage)
    {
        Num = num;
        Name = name;
        Count = count;
        Price = price;
        Storage = storage;
    }
}