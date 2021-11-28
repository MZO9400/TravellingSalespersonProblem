using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem {
	public class SolveSynchronous : ISolver {
		
		private List<List<int>> GetAllTours(Graph graph, int n) {
			return this.GetAllTours(graph, new List<int> { n }, new HashSet<int> { n });
		}

		private List<List<int>> GetAllTours(Graph graph, List<int> tour, HashSet<int> visited) {
			List<List<int>> tours = new();
			if (tour.Count == graph.Nodes.Count) tours.Add(tour);
			foreach (int node in graph.Nodes.Where(n => !visited.Contains(n))) {
				List<int> newTour = new(tour) { node };
				HashSet<int> newVisited = new(visited) { node };

				tours.AddRange(this.GetAllTours(graph, newTour, newVisited).ToList());
			}

			return tours;
		}

		public List<List<int>> FindAllSolutions(Graph graph) {
			int[] nodes = graph.Nodes.ToArray();
			List<List<int>> tours = new();
			foreach (int node in nodes) {
				IEnumerable<List<int>> newTours = this.FindAllSolutions(graph, node);
				tours.AddRange(newTours);
			}
			return tours;
		}

		private IEnumerable<List<int>> FindAllSolutions(Graph graph, int startingNode) {
			return this.GetAllTours(graph, startingNode);
		}
	}
}