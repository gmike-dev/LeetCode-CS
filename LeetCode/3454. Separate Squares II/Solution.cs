using LeetCode.Common;

namespace LeetCode._3454._Separate_Squares_II;

public class Solution
{
  public double SeparateSquares(int[][] squares)
  {
    var n = squares.Length;
    var start = new Dictionary<int, List<int>>(n);
    var end = new Dictionary<int, List<int>>(n);
    var pointsSet = new HashSet<int>(2 * n);
    for (var i = 0; i < n; i++)
    {
      var s = squares[i];
      var (y, l) = (s[1], s[2]);
      pointsSet.Add(y);
      pointsSet.Add(y + l);
      if (start.TryGetValue(y, out var startList))
      {
        startList.Add(i);
      }
      else
      {
        start[y] = [i];
      }
      if (end.TryGetValue(y + l, out var endList))
      {
        endList.Add(i);
      }
      else
      {
        end[y + l] = [i];
      }
    }
    var active = new SortedSet<(int x, int i)>();
    var areas = new Dictionary<int, long>(2 * n);
    var points = pointsSet.ToArray();
    Array.Sort(points);
    var leftY = points[0];
    var totalArea = 0L;
    foreach (var y in points)
    {
      var area = 0L;
      var rightX = int.MinValue;
      foreach (var (x, i) in active)
      {
        var l = squares[i][2];
        var a = rightX == int.MinValue ? l : Math.Min(l, Math.Max(0, x + l - rightX));
        area += (long)a * (y - leftY);
        rightX = Math.Max(rightX, x + l);
      }
      areas[y] = area;
      totalArea += area;
      leftY = y;
      if (start.TryGetValue(y, out var startList))
      {
        foreach (var i in startList)
        {
          active.Add((squares[i][0], i));
        }
      }
      if (end.TryGetValue(y, out var endList))
      {
        foreach (var i in endList)
        {
          active.Remove((squares[i][0], i));
        }
      }
    }
    var currentArea = 0L;
    var prevArea = 0L;
    var prevY = 0;
    foreach (var y in points)
    {
      currentArea += areas[y];
      if (2 * currentArea > totalArea)
      {
        var halfArea = totalArea / 2.0;
        var k = (halfArea - prevArea) / (currentArea - prevArea);
        return prevY + k * (y - prevY);
      }
      if (2 * currentArea == totalArea)
      {
        return y;
      }
      prevY = y;
      prevArea = currentArea;
    }
    return 0;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[[0,0,1],[2,2,1]]", 1.0)]
  [TestCase("[[0,0,2],[1,1,1]]", 1.0)]
  [TestCase("[[15,21,2],[19,21,3]]", 22.3)]
  [TestCase("[[26,29,3],[10,24,1]]", 30.33333)]
  [TestCase("[[18,23,5],[18,20,4],[27,29,3]]", 25.20000)]
  public void Test(string squares, double expected)
  {
    new Solution().SeparateSquares(squares.Array2()).Should().BeApproximately(expected, 1e-5);
  }
}
