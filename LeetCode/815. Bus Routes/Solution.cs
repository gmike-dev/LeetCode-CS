using System.Collections.Generic;
using System.Linq;

namespace LeetCode._815._Bus_Routes;

public class Solution
{
  public int NumBusesToDestination(int[][] routes, int source, int target)
  {
    var pointRoutes = new Dictionary<int, List<int>>();
    for (var bus = 0; bus < routes.Length; bus++)
    {
      foreach (var point in routes[bus])
      {
        if (pointRoutes.TryGetValue(point, out var list))
          list.Add(bus);
        else
          pointRoutes[point] = new List<int> { bus };
      }
    }
    if (!pointRoutes.ContainsKey(source) || !pointRoutes.ContainsKey(target))
      return -1;
    if (source == target)
      return 0;
    var busCount = 1;
    var currentRoutes = pointRoutes[source].ToHashSet();
    var processedRoutes = pointRoutes[source].ToHashSet();
    while (currentRoutes.Count > 0)
    {
      foreach (var route in currentRoutes.ToArray())
      {
        currentRoutes.Remove(route);
        foreach (var point in routes[route])
        {
          if (point == target)
            return busCount;
          foreach (var nextRoute in pointRoutes[point])
          {
            if (!processedRoutes.Contains(nextRoute))
            {
              processedRoutes.Add(nextRoute);
              currentRoutes.Add(nextRoute);
            }
          }
        }
      }
      busCount++;
    }
    return -1;
  }
}