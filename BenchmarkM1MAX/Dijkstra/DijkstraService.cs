namespace BenchmarkM1MAX.Dijkstra;

public class DijkstraService
{
    private int V = 9;
    private int MinDistance(int[] dist,
        bool[] sptSet)
    {
        int min = int.MaxValue, min_index = -1;
  
        for (int v = 0; v < V; v++)
            if (sptSet[v] == false && dist[v] <= min) {
                min = dist[v];
                min_index = v;
            }
  
        return min_index;
    }
    
    public int[] GetDijkstraShortestPaths(int[, ] graph, int src)
    {
        int[] dist = new int[V];

        bool[] sptSet = new bool[V];
  
        for (int i = 0; i < V; i++) {
            dist[i] = int.MaxValue;
            sptSet[i] = false;
        }
        dist[src] = 0;
  
        for (int count = 0; count < V - 1; count++) {

            int u = MinDistance(dist, sptSet);
            sptSet[u] = true;
  
            for (int v = 0; v < V; v++)
                if (!sptSet[v] && graph[u, v] != 0 && 
                    dist[u] != int.MaxValue && dist[u] + graph[u, v] < dist[v])
                    dist[v] = dist[u] + graph[u, v];
        }
  
        return dist;
    }
}