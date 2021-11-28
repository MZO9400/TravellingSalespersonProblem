using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TravellingSalespersonProblem {
	internal static class Program {
		private static void Main(string[] args) {
			int numCities = int.Parse(args[0]);
			int maxDistance = int.Parse(args[1]);
			Graph graph = new();
			Random rnd = new();

			for (int i = 0; i < numCities; i++) {
				for (int j = i; j < numCities; j++) {
					if (i != j) {
						graph.AddEdge(i, j, rnd.Next(1, maxDistance));
					}
				}
			}

			TspSolver solver = new(graph);
			// clock the solver
			Stopwatch sw = new();
			sw.Start();
			(int key, var value) = solver.Solve(new SolveSynchronous());
			sw.Stop();
			Console.WriteLine($"Solved in {sw.ElapsedMilliseconds}ms");
			Console.WriteLine("Best tour:");
			Console.WriteLine($"{key}: {string.Join(" -> ", value)}");
		}
	}
}