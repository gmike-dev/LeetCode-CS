namespace LeetCode.__Monotonic._2940._Find_Building_Where_Alice_and_Bob_Can_Meet;

public class Solution
{
  public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
  {
    var indexes = Enumerable.Range(0, queries.Length)
      .OrderByDescending(i => Math.Max(queries[i][0], queries[i][1]))
      .ToArray();
    var answer = new int[queries.Length];
    var monoStack = new List<int>();
    for (int i = 0, j = heights.Length - 1; i < queries.Length; i++)
    {
      var (x, y) = (queries[indexes[i]][0], queries[indexes[i]][1]);
      if (x > y)
        (x, y) = (y, x);
      for (; j > y; j--)
      {
        while (monoStack.Count > 0 && heights[monoStack.Last()] <= heights[j])
          monoStack.RemoveAt(monoStack.Count - 1);
        monoStack.Add(j);
      }
      if (x == y || heights[x] < heights[y])
      {
        answer[indexes[i]] = y;
      }
      else
      {
        var maxHeight = Math.Max(heights[x], heights[y]);
        var l = 0;
        var r = monoStack.Count - 1;
        while (l <= r)
        {
          var m = l + (r - l) / 2;
          if (heights[monoStack[m]] <= maxHeight)
            r = m - 1;
          else
            l = m + 1;
        }
        answer[indexes[i]] = r < 0 ? -1 : monoStack[r];
      }
    }
    return answer;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().LeftmostBuildingQueries(
        [6, 4, 8, 5, 2, 7],
        [[0, 1], [0, 3], [2, 4], [3, 4], [2, 2]]).Should()
      .BeEquivalentTo([2, 5, -1, 5, 2], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().LeftmostBuildingQueries(
        [5, 3, 8, 2, 6, 1, 4, 6],
        [[0, 7], [3, 5], [5, 2], [3, 0], [1, 6]]).Should()
      .BeEquivalentTo([7, 6, -1, 4, 6], o => o.WithStrictOrdering());
  }
}
