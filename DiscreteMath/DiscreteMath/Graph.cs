namespace DiscreteMath;

public class Graph
{
    public int NumVertices { get; private set; }
    public List<int>[] AdjacencyList { get; private set; }

    public Graph(int numVertices)
    {
        NumVertices = numVertices;
        AdjacencyList = new List<int>[numVertices];
        for (int i = 0; i < numVertices; i++)
        {
            AdjacencyList[i] = new List<int>();
        }
    }
    
    public void AddEdge(int u, int v)
    {
        AdjacencyList[u].Add(v);
    }
    
    public void RemoveEdge(int u, int v)
    {
        AdjacencyList[u].Remove(v);
    }
    
    public void DisplayList()
    {
        Console.WriteLine("Списки суміжності:");
        for (int i = 0; i < NumVertices; i++)
        {
            Console.Write($"{i}: ");
            foreach (var vertex in AdjacencyList[i])
            {
                Console.Write($"{vertex} ");
            }
            Console.WriteLine();
        }
    }
    
    public GraphMatrix ToGraphMatrix()
    {
        GraphMatrix matrixGraph = new GraphMatrix(NumVertices);
        for (int u = 0; u < NumVertices; u++)
        {
            foreach (int v in AdjacencyList[u])
            {
                matrixGraph.AddEdge(u, v);
            }
        }
        return matrixGraph;
    }
}