using System;

namespace Dijkstra
{
    class Program
    {        
        static int V = 10;
        static string[] city = { "서울", "천안", "원주", "강릉", "논산", "대전", "대구", "포항", "광주", "부산" };
        //static string[] city
        //    = new string[] { "서울", "천안", "원주", "강릉", "논산", "대전", "대구", "포항", "광주", "부산" };
        static bool[] sptSet = new bool[V];    // shortest path tree 집합, true if vertex i included in spt
        static int[] D = new int[V];    // vertex i의 shortest distance from source
        static void Main(string[] args)
        {
            int[,] graph = new int[,]
            {
                { 0,   12,  15,  0,   0,   0,   0,   0,   0,   0 },
                { 12,  0,   0,   0,   4,   10,  0,   0,   0,   0 },
                { 15,  0,   0,   21,  0,   0,   7,   0,   0,   0 },
                { 0,   0,   21,  0,   0,   0,   0,   25,  0,   0 },
                { 0,   4,   0,   0,   0,   3,   0,   0,   13,  0 },
                { 0,   10,  0,   0,   3,   0,   10,  0,   0,   0 },
                { 0,   0,   7,   0,   0,   10,  0,   19,  0,   9 },
                { 0,   0,   0,   25,  0,   0,   19,  0,   0,   5 },
                { 0,   0,   0,   0,   13,  0,   0,   0,   0,   15 },
                { 0,   0,   0,  0,   0,   0,   9,   5,   15,  0 } };

            ShortestPath(graph, 0);
        }

        // src에서 출발하는 최단경로
        private static void ShortestPath(int[,] graph, int s)
        {
            // 초기화
            for (int i = 0; i < V; i++)
            {
                D[i] = int.MaxValue;
                sptSet[i] = false;
            }

            D[s] = 0;

            // 아직 계산되지 않은 vertex 중에서 find shortest path for all vertices
            for(int i=0; i<V-1; i++)
            {
                int min = MinDistance();
                sptSet[min] = true;

                // update dist value of adjacent vertices
                for (int v = 0; v < V; v++)
                    if (!sptSet[v] && graph[i, v] != 0 && D[i] != int.MaxValue && D[i] + graph[i, v] < D[v])
                        D[v] = D[i] + graph[i, v];

                Console.WriteLine("iteration: {0}", i);
                PrintDist(s);
            }            
        }

        // 결과를 출력
        private static void PrintDist(int s)
        {
            Console.WriteLine("도시\tDistance From {0}", city[s]);
            for(int i=0; i<V; i++)
                Console.WriteLine("{0}\t{1}", city[i], D[i]);
        }

        // spt에 속하지 않는 버텍스중 최소 거리값을 작는 버텍스를 찾는다
        private static int MinDistance()
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for(int i=0; i<V; i++)
            {
                if(sptSet[i] == false && D[i]<=min)
                {
                    min = D[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}
