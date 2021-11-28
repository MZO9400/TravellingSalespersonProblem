using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TravellingSalespersonProblem {
	public class SolveThreaded : ISolver {
		private SortedDictionary<int, List<int>> CompleteTour(Graph graph, List<int> tour, HashSet<int> visited, int weight = 0) {
			SortedDictionary<int, List<int>> tours = new();
			if (tour.Count == graph.Nodes.Count) {
				int completeWeight = weight + (graph.GetWeight(tour[0], tour[^1]) ?? 0);
				tours.Add(completeWeight, new List<int>(tour) { tour[0] });
				return tours;
			}
			foreach (int node in graph.Nodes.Where(n => !visited.Contains(n))) {
				List<int> newTour = new(tour) { node };
				HashSet<int> newVisited = new(visited) { node };
				SortedDictionary<int, List<int>> childTours = this.CompleteTour(graph, newTour, newVisited,
					weight + graph.GetWeight(tour.Last(), node) ?? weight);
				foreach (KeyValuePair<int, List<int>> childTour in childTours) {
					(int key, var value) = childTour;
					if (tours.ContainsKey(key)) continue;
					tours.Add(key, value);
				}
			}
			return tours;
		}

		public SortedDictionary<int, List<int>> FindAllSolutions(Graph graph) {
			int[] nodes = graph.Nodes.ToArray();
			SortedDictionary<int, List<int>> tours = new();
			List<Thread> threads = new();
			foreach (int node in nodes) {
				Thread t = new(() => {
					SortedDictionary<int, List<int>> newTours = 
						this.CompleteTour(graph, new List<int> { node }, new HashSet<int> { node });
					foreach (KeyValuePair<int, List<int>> kvp in newTours) {
						(int key, var value) = kvp;
						if (!tours.ContainsKey(key)) {
							tours.Add(key, value);
						}
					}

				});
				t.Start();
				threads.Add(t);
			}

			foreach (Thread thread in threads) {
				thread.Join();
			}
			return tours;
		}

		public KeyValuePair<int, List<int>> FindBestSolution(Graph graph) {
			return this.FindAllSolutions(graph).First();
		}
	}
}