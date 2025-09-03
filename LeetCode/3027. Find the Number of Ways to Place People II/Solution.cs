using LeetCode.Common;

namespace LeetCode._3027._Find_the_Number_of_Ways_to_Place_People_II;

public class Solution
{
  public int NumberOfPairs(int[][] points)
  {
    var n = points.Length;
    Array.Sort(points, (a, b) =>
    {
      var cmp = a[0] - b[0];
      return cmp != 0 ? cmp : b[1] - a[1];
    });
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      var a = points[i];
      var minY = int.MinValue;
      for (var j = i + 1; j < n; j++)
      {
        var b = points[j];
        if (minY < b[1] && b[1] <= a[1])
        {
          count++;
          minY = b[1];
        }
      }
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[1,1],[2,2],[3,3]]", 0)]
  [TestCase("[[6,2],[4,4],[2,6]]", 2)]
  [TestCase("[[3,1],[1,3],[1,1]]", 2)]
  [TestCase("[[0,0],[2,5]]", 0)]
  public void Test(string points, int expected)
  {
    new Solution().NumberOfPairs(points.Array2()).Should().Be(expected);
  }
}
