using System.Collections.Generic;

namespace TravellingSalespersonProblem {
	public interface ISolver { 
		SortedDictionary<int, List<int>> FindAllSolutions(Graph graph);
		public KeyValuePair<int, List<int>> FindBestSolution(Graph graph);
	}
}