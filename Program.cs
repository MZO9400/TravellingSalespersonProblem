using System;

namespace TravellingSalespersonProblem {
	internal static class Program {
		private static void Main() {
			Graph graph = new();
			int[] nodes = new int[20];
			Random rnd = new();
			for (int i = 0; i < nodes.Length; i++) {
				nodes[i] = rnd.Next(0, 10);
			}

			Edge[] edges = new Edge[nodes.Length];
			for (int i = 0; i < edges.Length; i++) {
				int node1 = rnd.Next(0, nodes.Length);
				int node2 = rnd.Next(0, nodes.Length);
				double weight = Math.Round(rnd.NextDouble() * 1000, 2);
				edges[i] = new Edge(node1, node2, weight);
				try {
					graph.AddEdge(edges[i]);
				}
				catch (ArgumentException) {
					Console.WriteLine("Edge {0} already exists, ignoring", edges[i]);
					i--;
				}
			}
			
			Console.WriteLine("Graph:");
			Console.WriteLine(graph);
		}
	}
}