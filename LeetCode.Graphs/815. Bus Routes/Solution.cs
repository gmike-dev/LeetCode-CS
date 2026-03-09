using LeetCode.Common;

namespace LeetCode.Graphs._815._Bus_Routes;

/// <summary>
/// Solution for <see href="https://leetcode.com/problems/bus-routes/">Bus Routes</see> problem.
/// </summary>
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
          pointRoutes[point] = [route];
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

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,2,7],[3,6,7]]", 1, 6, 2)]
  [TestCase("[[7,12],[4,5,15],[6],[15,19],[9,12,13]]", 15, 12, -1)]
  [TestCase("[[1,2,3,4,5],[1,6,7],[7,5,8]]", 1, 5, 1)]
  [TestCase("[[1,5,4],[5,3,4],[3,5,1,2]]", 1, 3, 1)]
  [TestCase("[[1,2,3],[2,4,3],[1,2,5,4]]", 1, 4, 1)]
  [TestCase("[[1,2,3]]", 1, 3, 1)]
  [TestCase("[[1,2,3]]", 3, 3, 0)]
  public void Test(string routes, int source, int target, int expected)
  {
    new Solution().NumBusesToDestination(routes.Array2(), source, target).Should().Be(expected);
  }
}
