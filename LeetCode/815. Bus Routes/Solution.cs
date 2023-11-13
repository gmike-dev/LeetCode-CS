using System.Collections.Generic;
using System.Linq;

namespace LeetCode._815._Bus_Routes;

public class Solution
{
  public int NumBusesToDestination(int[][] routes, int source, int target)
  {
    if (source == target)
      return 0;
    var pointRoutes = new Dictionary<int, List<int>>();
    var containsTarget = new bool[routes.Length];
    for (var route = 0; route < routes.Length; route++)
    {
      foreach (var point in routes[route])
      {
        if (pointRoutes.TryGetValue(point, out var list))
          list.Add(route);
        else
          pointRoutes[point] = new List<int> { route };
        if (point == target)
          containsTarget[route] = true;
      }
    }
    // Quick check in case when we can use 1 route to target point.
    if (pointRoutes[source].Any(route => containsTarget[route]))
      return 1;
    
    // BFS for routes
    var currentRoutes = new Queue<(int, int)>();
    var routeUsed = new bool[routes.Length];
    foreach (var route in pointRoutes[source])
    {
      currentRoutes.Enqueue((route, 1));
      routeUsed[route] = true;
    }
    while (currentRoutes.Count > 0)
    {
      var (route, busCount) = currentRoutes.Dequeue();
      if (containsTarget[route])
        return busCount;
      foreach (var point in routes[route])
      {
        foreach (var nextRoute in pointRoutes[point])
        {
          if (!routeUsed[nextRoute])
          {
            currentRoutes.Enqueue((nextRoute, busCount + 1));
            routeUsed[nextRoute] = true;
          }
        }
      }
    }
    return -1;
  }
}