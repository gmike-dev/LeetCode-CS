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
    {
      return 0;
    }
    Dictionary<int, List<int>> pointRoutes = new();
    bool[] containsTarget = new bool[routes.Length];
    for (int route = 0; route < routes.Length; route++)
    {
      foreach (int point in routes[route])
      {
        if (pointRoutes.TryGetValue(point, out List<int> list))
        {
          list.Add(route);
        }
        else
        {
          pointRoutes[point] = [route];
        }
        if (point == target)
        {
          containsTarget[route] = true;
        }
      }
    }

    if (!pointRoutes.TryGetValue(source, out List<int> sourceRoutes))
    {
      return -1;
    }

    if (sourceRoutes.Any(route => containsTarget[route]))
    {
      return 1;
    }

    // BFS for routes
    Queue<(int, int)> currentRoutes = new();
    bool[] routeUsed = new bool[routes.Length];
    foreach (int route in sourceRoutes)
    {
      currentRoutes.Enqueue((route, 1));
      routeUsed[route] = true;
    }
    while (currentRoutes.Count > 0)
    {
      (int route, int busCount) = currentRoutes.Dequeue();
      if (containsTarget[route])
      {
        return busCount;
      }
      foreach (int point in routes[route])
      {
        foreach (int nextRoute in pointRoutes[point])
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
  [TestCase("[[1,2,7],[3,6,7]]", 8, 6, -1)]
  public void Test(string routes, int source, int target, int expected)
  {
    new Solution().NumBusesToDestination(routes.Array2(), source, target).Should().Be(expected);
  }
}
