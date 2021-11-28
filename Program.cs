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
			KeyValuePair<int, List<int>> Sync() => solver.Solve(new SolveSynchronous());
			KeyValuePair<int, List<int>> Threaded() => solver.Solve(new SolveThreaded());
			KeyValuePair<int, List<int>> ThreadPooled() => solver.Solve(new SolveThreadPooled());

			(long ms, KeyValuePair<int, List<int>> response) = Timer(Sync);
			Console.WriteLine($"Synchronous: {ms}ms");
			Console.WriteLine("Best tour:");
			Console.WriteLine($"{response.Key}: {string.Join(" -> ", response.Value)}");
			
			(ms, response) = Timer(Threaded);
			Console.WriteLine($"Threaded: {ms}ms");
			Console.WriteLine("Best tour:");
			Console.WriteLine($"{response.Key}: {string.Join(" -> ", response.Value)}");
			
			
			(ms, response) = Timer(ThreadPooled);
			Console.WriteLine($"ThreadPooled: {ms}ms");
			Console.WriteLine("Best tour:");
			Console.WriteLine($"{response.Key}: {string.Join(" -> ", response.Value)}");
		}
		
		private static KeyValuePair<long, T> Timer<T>(Func<T> callback) {
			Stopwatch sw = new();
			sw.Start();
			T result = callback();
			sw.Stop();
			return new KeyValuePair<long, T>(sw.ElapsedMilliseconds, result);
		}
	}
}