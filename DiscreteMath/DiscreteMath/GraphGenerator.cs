namespace DiscreteMath;

public class GraphGenerator
{
    public static Graph GenerateRandomDAG(int vertexCount, double density)
    {
        var graph = new Graph(vertexCount);
        var rand = new Random();
        int maxEdges = vertexCount * (vertexCount - 1) / 2;
        int targetEdges = (int)(density * maxEdges);

        var possibleEdges = new List<(int, int)>();
        for (int i = 0; i < vertexCount; i++)
        for (int j = i + 1; j < vertexCount; j++)
            possibleEdges.Add((i, j)); 

        var selectedEdges = possibleEdges.OrderBy(_ => rand.Next()).Take(targetEdges);

        foreach (var (u, v) in selectedEdges)
        {
            graph.AddEdge(u, v);
        }

        return graph;
    }

}