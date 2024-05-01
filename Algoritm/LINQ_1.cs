List<string> stringList = new List<string>() { "Abra", "Kadabra", "Biba", "Boba", "Pupa", "Lupa", "Aboba" };
var selectedStrings = from str in stringList
                    where str.Length % 2 == 0
                    select str;
foreach (string str in selectedStrings) Console.WriteLine(str);
for (int i = stringList.Count - 1; i >= 0; i--)
{
    if (i % 2 == 1)
    {
        stringList.RemoveAt(i);
    }
}
Console.WriteLine();
foreach (string str in selectedStrings) Console.WriteLine(str);