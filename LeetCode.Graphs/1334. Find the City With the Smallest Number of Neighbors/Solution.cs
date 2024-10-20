namespace LeetCode.Graphs._1334._Find_the_City_With_the_Smallest_Number_of_Neighbors;

public class Solution
{
  public int FindTheCity(int n, int[][] edges, int distanceThreshold)
  {
    var distanceMatrix = new int[n][];
    for (var i = 0; i < n; i++)
    {
      distanceMatrix[i] = new int[n];
      distanceMatrix[i].AsSpan().Fill((int)1e9);
    }
    foreach (var e in edges)
      distanceMatrix[e[0]][e[1]] = distanceMatrix[e[1]][e[0]] = e[2];
    FloydWarshall(n, distanceMatrix);
    return GetCityWithMinNeighbours(n, distanceMatrix, distanceThreshold);
  }

  private static void FloydWarshall(int n, int[][] d)
  {
    for (var k = 0; k < n; ++k)
    {
      for (var i = 0; i < n; ++i)
      {
        for (var j = 0; j < n; ++j)
        {
          d[i][j] = int.Min(d[i][j], d[i][k] + d[k][j]);
        }
      }
    }
  }

  private static int GetCityWithMinNeighbours(int n, int[][] distanceMatrix, int distanceThreshold)
  {
    var resultCity = 0;
    var minNeighbours = int.MaxValue;
    for (var i = 0; i < n; ++i)
    {
      var neighbours = 0;
      for (var j = 0; j < n; ++j)
      {
        if (i != j && distanceMatrix[i][j] <= distanceThreshold)
          ++neighbours;
      }
      if (neighbours <= minNeighbours)
      {
        resultCity = i;
        minNeighbours = neighbours;
      }
    }
    return resultCity;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().FindTheCity(4, [[0, 1, 3], [1, 2, 1], [1, 3, 4], [2, 3, 1]], 4).Should().Be(3);
  }

  [Test]
  public void Test2()
  {
    new Solution().FindTheCity(5, [[0, 1, 2], [0, 4, 8], [1, 2, 3], [1, 4, 2], [2, 3, 1], [3, 4, 1]], 2).Should().Be(0);
  }
}
