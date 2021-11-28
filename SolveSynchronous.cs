using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem {
	public class SolveSynchronous : ISolver {
		
		private List<KeyValuePair<int, List<int>>> GetAllTours(Graph graph, int n) {
			return this.GetAllTours(graph, new List<int> { n }, new HashSet<int> { n });
		}

		private List<KeyValuePair<int, List<int>>> GetAllTours(Graph graph, List<int> tour, HashSet<int> visited, int weight = 0) {
			List<KeyValuePair<int, List<int>>> tours = new();
			if (tour.Count == graph.Nodes.Count) tours.Add(new KeyValuePair<int, List<int>>(weight, tour));
			foreach (int node in graph.Nodes.Where(n => !visited.Contains(n))) {
				List<int> newTour = new(tour) { node };
				HashSet<int> newVisited = new(visited) { node };
				tours.AddRange(this.GetAllTours(graph, newTour, newVisited, weight + graph.GetWeight(tour.Last(), node) ?? weight));
			}

			return tours;
		}

		public List<KeyValuePair<int, List<int>>> FindAllSolutions(Graph graph) {
			int[] nodes = graph.Nodes.ToArray();
			List<KeyValuePair<int, List<int>>> tours = new();
			foreach (int node in nodes) {
				List<KeyValuePair<int, List<int>>> newTours = this.FindAllSolutions(graph, node);
				tours.AddRange(newTours);
			}
			return tours;
		}

		private List<KeyValuePair<int, List<int>>> FindAllSolutions(Graph graph, int startingNode) {
			return this.GetAllTours(graph, startingNode);
		}
	}
}