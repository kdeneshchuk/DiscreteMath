namespace DiscreteMath;

public class TopologicalSorter
{
    private HashSet<int> visited;
    private Stack<int> stack;

    public List<int> Sort(Graph graph)
    {
        visited = new HashSet<int>();
        stack = new Stack<int>();

        for (int i = 0; i < graph.NumVertices; i++)
        {
            if (!visited.Contains(i))
                DFS(i, graph);
        }

        return stack.Reverse().ToList();
    }

    private void DFS(int vertex, Graph graph)
    {
        visited.Add(vertex);

        foreach (var neighbor in graph.AdjacencyList[vertex])
        {
            if (!visited.Contains(neighbor))
                DFS(neighbor, graph);
        }

        stack.Push(vertex);
    }

}