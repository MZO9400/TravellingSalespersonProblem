using System.Collections.Generic;

namespace TravellingSalespersonProblem {
	public class TspSolver {
		private readonly Graph graph;

		public TspSolver(Graph graph) {
			this.graph = graph;
		}

		public SortedDictionary<int, List<int>> Solve(ISolver solver) {
			return solver.FindAllSolutions(this.graph);
		}
	}
}