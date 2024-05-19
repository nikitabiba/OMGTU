Console.WriteLine("Введите количество вершин: ");
int V = Convert.ToInt32(Console.ReadLine());
List<List<int>> graph = new List<List<int>>();
for (int i = 0; i < V; i++)
{
    graph.Add(new List<int>());
}

Console.WriteLine("Введите количество ребер");
int E = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= E; i++)
{
    Console.WriteLine($"Введите ребро {i} в формате: \"Вершина1 Вершина2\"");
    string[] edge = Console.ReadLine().Split();
    int u = Convert.ToInt32(edge[0]);
    int v = Convert.ToInt32(edge[1]);
    AddEdge(graph, u, v);
}

bool[] visited = new bool[V];
for (int i = 0; i < V; i++)
{
    if (!visited[i])
    {
        Console.WriteLine("Компонента связности:");
        Reshenie(graph, i, visited);
    }
}

static void AddEdge(List<List<int>> graph, int u, int v)
{
    graph[u].Add(v);
    graph[v].Add(u);
}

static void Reshenie(List<List<int>> graph, int start, bool[] visited)
{
    List<int> all = new List<int>();
    all.Add(start);
    visited[start] = true;

    while (all.Count > 0)
    {
        int current = all[0];
        all.RemoveAt(0);
        Console.WriteLine(current);
        foreach (var neighbor in graph[current])
        {
            if (!visited[neighbor])
            {
                all.Add(neighbor);
                visited[neighbor] = true;
            }
        }
    }
}