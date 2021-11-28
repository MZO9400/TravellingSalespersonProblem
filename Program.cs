using System;
using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem {
	internal static class Program {
		private static void Main() {
			Graph graph = new();
			int[] nodes = new int[5];
			Random rnd = new();
			for (int i = 0; i < nodes.Length; i++) nodes[i] = rnd.Next(0, 10);

			for (int i = 0; i < nodes.Length; i++)
			for (int j = 0; j < nodes.Length; j++) {
				if (i == j) continue;
				try {
					int weight = rnd.Next(0, 1000);
					graph.AddEdge(i, j, weight);
				}
				catch (ArgumentException) {
					// ignored
				}
			}

			Console.WriteLine("Graph:");
			Console.WriteLine(graph);

		}
	}
}