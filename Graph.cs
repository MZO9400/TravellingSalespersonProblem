using System;
using System.Collections.Generic;
using System.Linq;

namespace TravellingSalespersonProblem {
	public class Graph {
		public Graph() {
			this.Nodes = new SortedSet<int>();
			this.Edges = new List<Edge>();
		}

		public SortedSet<int> Nodes { get; }
		private List<Edge> Edges { get; }

		public Graph AddEdge(int from, int to, int weight) {
			if (this.GetWeight(from, to) != null || this.GetWeight(to, from) != null)
				throw new ArgumentException("Edge already exists");
			this.Nodes.Add(from);
			this.Nodes.Add(to);
			this.Edges.Add(new Edge(from, to, weight));
			return this;
		}

		public Graph AddEdge(Edge edge) {
			return this.AddEdge(edge.From, edge.To, edge.Weight);
		}

		public Graph RemoveEdge(int from, int to) {
			Edge? edge = this.GetEdgeIfExists(from, to);
			if (edge == null) throw new ArgumentException("Edge does not exist");
			this.Edges.Remove(edge);
			return this;
		}

		public Edge? GetEdgeIfExists(int from, int to) {
			Edge? edge =
				this.Edges.FirstOrDefault(e => e.From == from && e.To == to) ??
				this.Edges.FirstOrDefault(e => e.From == to && e.To == from);
			return edge;
		}

		public int? GetWeight(int from, int to) {
			Edge? edge = this.GetEdgeIfExists(from, to);
			return edge?.Weight;
		}

		public override string ToString() {
			return this.Edges.Aggregate("", (current, edge) => current + $"{edge}\n");
		}
	}
}