namespace DiscreteMath
{
    internal class Program
    {
        static void Main()
        {
            //Ручне тестування

            //int n = 6;
            //double density = 0.5;

            //Graph graph = GraphGenerator.GenerateRandomDAG(n, density);
            //graph.DisplayList(); 


            //TopologicalSorter sorter = new TopologicalSorter();
            //List<int> sorted = sorter.Sort(graph);

            //Console.WriteLine("\nТопологічне сортування :");
            //Console.WriteLine(string.Join(" → ", sorted));
            //Graph testGraph = new Graph(4);
            //testGraph.AddEdge(0, 1);
            //testGraph.AddEdge(1, 2);
            //testGraph.AddEdge(2, 3);

            ExperimentRunner.Run();
            Console.ReadKey();

        }

    }
}
