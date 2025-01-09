namespace Dominoes;

public static class EulerianCircuit
{
    public static List<Domino>? FindCircularDominoesChain(List<Domino> dominoes)
    {
        if (dominoes.Count == 0)
        {
            return null;
        }
        
        var graph = BuildGraph(dominoes);
        if (!HasEulerianCircuit(graph))
        {
            return null;
        }

        var circuit = FindEulerianCircuit(graph, dominoes);
        return circuit;
    }

    private static Dictionary<int, List<Domino>> BuildGraph(List<Domino> dominoes)
    {
        var graph = new Dictionary<int, List<Domino>>();
        foreach (var domino in dominoes)
        {
            if (!graph.ContainsKey(domino.Left))
            {
                graph[domino.Left] = [];
            }
            graph[domino.Left].Add(domino);
            
            if (!graph.ContainsKey(domino.Right))
            {
                graph[domino.Right] = [];
            }
            graph[domino.Right].Add(domino);
        }
        return graph;
    }

    private static bool HasEulerianCircuit(Dictionary<int, List<Domino>> graph)
    {
        return graph.All(kvp => kvp.Value.Count % 2 == 0);
    }

    private static List<Domino>? FindEulerianCircuit(Dictionary<int, List<Domino>> graph, List<Domino> dominoes)
    {
        var circuit = new List<Domino>();
        var current = dominoes[0].Left;

        while (graph[current].Count > 0)
        {
            var nextDomino = graph[current].First(d => IsValidNextEdge(graph, current, d));
            circuit.Add(nextDomino);

            graph[nextDomino.Left].Remove(nextDomino);
            graph[nextDomino.Right].Remove(nextDomino);

            current = nextDomino.Left == current ? nextDomino.Right : nextDomino.Left;
        }

        if (circuit.Count == dominoes.Count)
        {
            var previous = circuit[0];
            for (var i = 1; i < circuit.Count; i++)
            {
                var currentDomino = circuit[i];
                if (previous.Right != currentDomino.Left)
                {
                    currentDomino.Reverse();
                }
                previous = currentDomino;
            }
        }
        return circuit.Count == dominoes.Count ? circuit : null;
    }

    private static bool IsValidNextEdge(Dictionary<int, List<Domino>> graph, int u, Domino domino)
    {
        if (graph[u].Count == 1)
        {
            return true;
        }

        var visited = new HashSet<int>();
        var count1 = DfsCount(graph, u, visited);

        graph[domino.Left].Remove(domino);
        graph[domino.Right].Remove(domino);

        visited.Clear();
        var count2 = DfsCount(graph, u, visited);

        graph[domino.Left].Add(domino);
        graph[domino.Right].Add(domino);

        return count1 <= count2;
    }

    private static int DfsCount(Dictionary<int, List<Domino>> graph, int v, HashSet<int> visited)
    {
        visited.Add(v);
        var count = 1;

        foreach (var domino in graph[v])
        {
            var next = domino.Left == v ? domino.Right : domino.Left;
            if (!visited.Contains(next))
            {
                count += DfsCount(graph, next, visited);
            }
        }

        return count;
    }
}