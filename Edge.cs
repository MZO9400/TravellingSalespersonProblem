namespace TravellingSalespersonProblem {
	public class Edge {
		public Edge(int from, int to, int weight) {
			this.From = from;
			this.To = to;
			this.Weight = weight;
		}

		public int From { get; }
		public int To { get; }
		public int Weight { get; }

		public override string ToString() {
			return $"{this.From} -> {this.To}: ({this.Weight})";
		}
	}
}