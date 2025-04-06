namespace DiscreteMath;

public class GraphMatrix
{
    public int NumVertices { get; private set; }
    public int[,] Matrix { get; private set; }

    public GraphMatrix(int numVertices)
    {
        NumVertices = numVertices;
        Matrix = new int[numVertices, numVertices];
    }
    
    public void AddEdge(int u, int v)
    {
        Matrix[u, v] = 1;
    }
    
    public void RemoveEdge(int u, int v)
    {
        Matrix[u, v] = 0;
    }
    
    public void DisplayMatrix()
    {
        Console.WriteLine("Матриця суміжності:");
        for (int i = 0; i < NumVertices; i++)
        {
            for (int j = 0; j < NumVertices; j++)
            {
                Console.Write(Matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
    
    public Graph ToGraphList()
    {
        Graph graph = new Graph(NumVertices);
        for (int i = 0; i < NumVertices; i++)
        {
            for (int j = 0; j < NumVertices; j++)
            {
                if (Matrix[i, j] != 0)
                {
                    graph.AdjacencyList[i].Add(j);
                }
            }
        }
        return graph;
    }
}