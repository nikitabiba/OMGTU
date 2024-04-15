Console.Write("Длина массива: ");
int length = int.Parse(Console.ReadLine());
Array array = Array.CreateInstance(typeof(Int32), length);
Console.WriteLine("Перечислите элементы массива:");
for (int i = 0; i < length; i++)
    array.SetValue(int.Parse(Console.ReadLine()), i);
Console.WriteLine("\n1)Count\n2)BinSearch\n3)Copy\n4)Find\n5)FindLast\n6)IndexOf\n7)Reverse\n8)Resize\n9)Sort");
string choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.WriteLine("Элементов в массиве, больших ста: " + ((int[])array).Count(x => x > 100));
        break;
    case "2":
        BinSearch(array);
        break;
    case "3":
        Copy(array);
        break;
    case "4":
        Find(array);
        break;
    case "5":
        FindLast(array);
        break;
    case "6":
        IndexOf(array);
        break;
    case "7":
        Array.Reverse(array);
        PrintArray(array);
        break;
    case "8":
        Resize(array);
        break;
    case "9":
        Array.Sort(array);
        PrintArray(array);
        break;
}
static void PrintArray(Array array)
{
    foreach (int i in array) Console.Write(i + " ");
}
static void BinSearch(Array array)
{
    Array.Sort(array);
    Console.Write("Введите элемент: ");
    int value = int.Parse(Console.ReadLine());
    int index = Array.BinarySearch(array, value);
    Console.WriteLine(index >= 0 ? "Индекс элемента в отсортированном массиве: " + index : "Число не найдено");
}

static void Copy(Array array)
{
    Console.WriteLine("Заполните массив, который копируем");
    Console.Write("Длина массива: ");
    int length = int.Parse(Console.ReadLine());
    if (length > array.Length)
    {
        Console.WriteLine("Длина массива, в который копируем должна быть не меньше длины второго массива");
        return;
    }

    Array array2 = Array.CreateInstance(typeof(Int32), length);
    Console.WriteLine("Перечислите элементы массива:");
    for (int i = 0; i < length; i++)
        array2.SetValue(int.Parse(Console.ReadLine()), i);
    Array.Copy(array2, array, array2.Length);
    PrintArray(array);
}

static void Find(Array array)
{
    int result = Array.Find((int[])array, value => value > 5);
    Console.WriteLine(result != 0 ? ("Число больше чем 5: " + result) : "Такого числа нет");
}

static void FindLast(Array array)
{
    int result = Array.FindLast((int[])array, value => value > 5);
    Console.WriteLine(result != 0 ? ("Число больше чем 5: " + result) : "Такого числа нет");
}

static void IndexOf(Array array)
{
    Console.Write("Какое число найти: ");
    int value = int.Parse(Console.ReadLine());
    int result = Array.IndexOf(array, value);
    Console.WriteLine(result >= 0 ? ("Индекс элемента: " + result) : "Элемент не найден");
}

static void Resize(Array array)
{
    Console.WriteLine("Новый размер массива: ");
    int length = int.Parse(Console.ReadLine());
    int[] arr = (int[])array;
    Array.Resize(ref arr, length);
    PrintArray(arr);
}