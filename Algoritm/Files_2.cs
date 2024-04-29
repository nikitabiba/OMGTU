StreamReader sr1 = new StreamReader(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Nums1.txt");
StreamReader sr2 = new StreamReader(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Nums2.txt");

using (StreamWriter sw = new StreamWriter(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Nums.txt"))
{
    string? str1 = sr1.ReadLine();
    string? str2 = sr2.ReadLine();
    int st1;
    int st2;
    while (str1 != null && str2 != null)
    {
        st1 = Convert.ToInt32(str1);
        st2 = Convert.ToInt32(str2);
        if (st1 < st2)
        {
            sw.WriteLine(st1);
            str1 = sr1.ReadLine();
            st1 = Convert.ToInt32(str1);
        }
        else
        {
            sw.WriteLine(st2);
            str2 = sr2.ReadLine();
            st2 = Convert.ToInt32(str2);
        }
    }
    if (str1 != null && str2 == null) while (str1 != null)
        {
            st1 = Convert.ToInt32(str1);
            sw.WriteLine(st1);
            str1 = sr1.ReadLine();
            st1 = Convert.ToInt32(str1);
        }
    if (str2 != null && str1 == null) while (str2 != null)
        {
            st2 = Convert.ToInt32(str2);
            sw.WriteLine(st2);
            str2 = sr2.ReadLine();
            st2 = Convert.ToInt32(str2);
        }
}

using (StreamReader sr = new StreamReader(@"C:\Users\csr10\OneDrive\Рабочий стол\Work\Cishka\Project_1\Text.txt"))
{
    string[] str = sr.ReadToEnd().Split('\n');
    int mn = 100000000;
    int currentLength = 0;
    string correctString = "Нет подстрок из 'a'";
    foreach (string st in str)
    {
        foreach (char c in st)
        {
            if (c == 'a')
            {
                currentLength++;
            }
            else
            {
                if (currentLength != 0)
                {
                    if (currentLength < mn)
                    {
                        mn = currentLength;
                        correctString = st;
                    }
                    currentLength = 0;
                }
            }
        }
    }
    Console.WriteLine(correctString);
}
