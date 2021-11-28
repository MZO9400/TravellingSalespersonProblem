using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem {
	public class SolveSynchronous : ISolver {
		
		private SortedDictionary<int, List<int>> GetAllTours(Graph graph, int n) {
			return this.CompleteTour(graph, new List<int> { n }, new HashSet<int> { n });
		}

		private SortedDictionary<int, List<int>> CompleteTour(Graph graph, List<int> tour, HashSet<int> visited, int weight = 0) {
			SortedDictionary<int, List<int>> tours = new();
			if (tour.Count == graph.Nodes.Count) tours.Add(weight, tour);
			foreach (int node in graph.Nodes.Where(n => !visited.Contains(n))) {
				List<int> newTour = new(tour) { node };
				HashSet<int> newVisited = new(visited) { node };
				SortedDictionary<int, List<int>> childTours = this.CompleteTour(graph, newTour, newVisited,
					weight + graph.GetWeight(tour.Last(), node) ?? weight);
				foreach ((int key, var value) in childTours) {
					if (!tours.ContainsKey(key)) {
						tours.Add(key, value);
					}
				}
			}

			return tours;
		}

		public SortedDictionary<int, List<int>> FindAllSolutions(Graph graph) {
			int[] nodes = graph.Nodes.ToArray();
			SortedDictionary<int, List<int>> tours = new();
			foreach (int node in nodes) {
				SortedDictionary<int, List<int>> newTours = this.GetAllTours(graph, node);
				foreach ((int key, var value) in newTours) {
					if (!tours.ContainsKey(key)) {
						tours.Add(key, value);
					}
				}
			}
			return tours;
		}
	}
}