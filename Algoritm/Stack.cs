Psp();
PolskaPosl();

    static void Psp()
{
    string str = Console.ReadLine();
    bool flag = true;
    Stack<char> stack = new Stack<char>();
    foreach (char c in str)
    {
        if ((new char[] { '(', '[', '{' }).Contains(c)) stack.Push(c);
        else if ((new char[] { ')', ']', '}' }).Contains(c))
        {
            if (stack.Count != 0 && ((stack.Peek() == '(' && c == ')') || (stack.Peek() == '[' && c == ']') || (stack.Peek() == '{' && c == '}')))
                stack.Pop();
            else
            {
                Console.WriteLine("Неправильная последовательность");
                flag = false;
                break;
            }
        }
    }
    if (stack.Count == 0 && flag) Console.WriteLine("Правильная последовательность");
    else if (stack.Count > 0 && flag) Console.WriteLine("Неправильная последовательность");
}

static void PolskaPosl()
{
    bool flag = true;
    string[] str = Console.ReadLine().Split(' ');
    if (str.Length == 1)
    {
        Console.WriteLine("Недостаточно операторов или операндов");
        return;
    }
    Stack<string> stack = new Stack<string>();

    foreach (string c in str)
    {
        if (!(new string[] { "+", "-", "*", "/" }).Contains(c))
            stack.Push(c);
        else if ((new string[] { "+", "-", "*", "/" }).Contains(c))
        {
            if (stack.Count >= 2)
            {
                double b = Convert.ToDouble(stack.Pop());
                double a = Convert.ToDouble(stack.Pop());
                if (c == "+")
                    stack.Push(Convert.ToString(a + b));
                else if (c == "-")
                    stack.Push(Convert.ToString(a - b));
                if (c == "*")
                    stack.Push(Convert.ToString(a * b));
                if (c == "/")
                    if (b != 0)
                        stack.Push(Convert.ToString(a / b));
                    else
                    {
                        Console.WriteLine("Деление на ноль");
                        return;
                    }
            }
            else
            {
                Console.WriteLine("Много операторов, не хватает чисел");
                return;
            }

        }
    }
    if (stack.Count > 1)
    {
        Console.WriteLine("Много операндов, не хватает операторов");
        return;
    }
    if (flag) Console.WriteLine(stack.Peek());
}