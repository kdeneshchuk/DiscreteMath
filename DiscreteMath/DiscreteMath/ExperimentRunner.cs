using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace DiscreteMath
{
    public class ExperimentRunner
    {
        public static void Run()
        {
            int[] sizes = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
            double[] densities = { 0.1, 0.3, 0.5, 0.7, 0.9 };
            int trials = 20;

            var results = new List<string>();
            results.Add("Size,Density,ListTime,MatrixTime");

            foreach (var size in sizes)
            {
                foreach (var density in densities)
                {
                    double totalListTime = 0;
                    double totalMatrixTime = 0;

                    for (int t = 0; t < trials; t++)
                    {
                        // Генерація DAG
                        Graph graph = GraphGenerator.GenerateRandomDAG(size, density);

                        // Список суміжності
                        var sorter = new TopologicalSorter();
                        var stopwatch = Stopwatch.StartNew();
                        sorter.Sort(graph);
                        stopwatch.Stop();
                        totalListTime += stopwatch.Elapsed.TotalMilliseconds;

                        // Матриця суміжності → конвертація → сортування
                        GraphMatrix matrixGraph = graph.ToGraphMatrix();
                        Graph listFromMatrix = matrixGraph.ToGraphList();

                        stopwatch.Restart();
                        sorter.Sort(listFromMatrix);
                        stopwatch.Stop();
                        totalMatrixTime += stopwatch.Elapsed.TotalMilliseconds;
                    }

                    double avgList = totalListTime / trials;
                    double avgMatrix = totalMatrixTime / trials;

                    results.Add($"{size},{density.ToString("0.0", CultureInfo.InvariantCulture)},{avgList.ToString("0.0000", CultureInfo.InvariantCulture)},{avgMatrix.ToString("0.0000", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"n={size}, density={density} | List: {avgList:F4} ms | Matrix: {avgMatrix:F4} ms");
                }
            }

            File.WriteAllLines("experiment_results.csv", results);
            Console.WriteLine("\n✅ Результати експериментів збережено у файл: experiment_results.csv");
        }
    }
}
