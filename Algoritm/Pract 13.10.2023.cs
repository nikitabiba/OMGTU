int n = Convert.ToInt32(Console.ReadLine());
int[] mas = new int[n];
// 1 задание
for (int i = 0; i < n; i++) mas[i] = Convert.ToInt32(Console.ReadLine());
bool flag = true;
for (int i = 0; i < n; i++) if (mas[i] % 2 != (i + 1) % 2) flag = false;
Console.WriteLine("1 задание");
if (flag) Console.WriteLine("Все элементы красавчики");
else Console.WriteLine("Не все элементы красавчики");
// 2 задание
bool flag2 = false;
Console.WriteLine("2 задание");
for (int i = 0; i < n; i++) if (mas[i] % 2 == 0)
    {
        Console.WriteLine(i);
        flag2 = true;
        break;
    }
if (flag2 == false) Console.WriteLine("Нет чётных чисел");
// 3 задание
int pos = 0;
bool flag1 = false;
for (int i = 0; i < n; i++) if (mas[i] == 0)
    {
        pos = i;
        flag1 = true;
    }
Console.WriteLine("3 задание");
if (flag1 != true) Console.WriteLine("Нет нолей");
else Console.WriteLine(pos);
// 4 задание
int minel = 123456789, kol = 0;
foreach (int i in mas) if (i < minel && i != 0) minel = i;
foreach (int i in mas) if (i % 2 == minel % 2) kol += 1;
Console.WriteLine("4 задание");
if (minel == 123456789) Console.WriteLine("Все числа - нули");
else Console.WriteLine(kol);
// 5 задание
int imin = 0, imax = 0, count = 0;
bool flag3 = true;
for (int i = 0; i < n; i++)
{
    if (mas[i] == mas.Min()) imin = i;
    if (mas[i] == mas.Max()) imax = i;
}
for (int i = imin + 1; i < imax; i++) count += 1;
Console.WriteLine("5 задание");
if (count == 0) Console.WriteLine("Нет элементов");
else if (count == 1) Console.WriteLine("Последовательность убывающая");
else
{
    for (int i = imin + 1; i < (imax - 1); i++) if (mas[i] <= mas[i + 1]) flag3 = false;
    if (flag3) Console.WriteLine("Последовательность убывающая");
    else Console.WriteLine("Последовательность не убывающая");
}
