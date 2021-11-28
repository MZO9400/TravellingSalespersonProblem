using System.Collections.Generic;

namespace TravellingSalespersonProblem {
	public interface ISolver { 
		List<List<int>> FindAllSolutions(Graph graph);
	}
}