namespace TravellingSalespersonProblem {
	public class Edge {
		public Edge(int from, int to, double weight) {
			this.From = from;
			this.To = to;
			this.Weight = weight;
		}

		public int From { get; }
		public int To { get; }
		public double Weight { get; }
	}
}