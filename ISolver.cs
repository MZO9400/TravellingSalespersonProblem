using System.Collections.Generic;

namespace TravellingSalespersonProblem {
	public interface ISolver { 
		List<KeyValuePair<int, List<int>>> FindAllSolutions(Graph graph);
	}
}