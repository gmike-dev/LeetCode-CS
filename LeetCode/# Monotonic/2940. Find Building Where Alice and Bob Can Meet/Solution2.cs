namespace LeetCode.__Monotonic._2940._Find_Building_Where_Alice_and_Bob_Can_Meet;

public class Solution2
{
  public int[] LeftmostBuildingQueries(int[] heights, int[][] queries)
  {
    Span<int> indexes = stackalloc int[queries.Length];
    for (var i = 0; i < queries.Length; i++)
      indexes[i] = i;
    indexes.Sort((i, j) =>
    {
      var q1 = queries[i];
      var q2 = queries[j];
      return Math.Max(q2[0], q2[1]) - Math.Max(q1[0], q1[1]);
    });
    var answer = new int[queries.Length];
    var stackSize = 0;
    Span<int> monoStack = stackalloc int[heights.Length];
    for (int i = 0, j = heights.Length - 1; i < queries.Length; i++)
    {
      var (x, y) = (queries[indexes[i]][0], queries[indexes[i]][1]);
      if (x > y)
        (x, y) = (y, x);
      for (; j > y; j--)
      {
        while (stackSize > 0 && heights[monoStack[stackSize - 1]] <= heights[j])
          stackSize--;
        monoStack[stackSize++] = j;
      }
      if (x == y || heights[x] < heights[y])
      {
        answer[indexes[i]] = y;
      }
      else
      {
        var maxHeight = Math.Max(heights[x], heights[y]);
        var l = 0;
        var r = stackSize - 1;
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
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().LeftmostBuildingQueries(
        [6, 4, 8, 5, 2, 7],
        [[0, 1], [0, 3], [2, 4], [3, 4], [2, 2]]).Should()
      .BeEquivalentTo([2, 5, -1, 5, 2], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution2().LeftmostBuildingQueries(
        [5, 3, 8, 2, 6, 1, 4, 6],
        [[0, 7], [3, 5], [5, 2], [3, 0], [1, 6]]).Should()
      .BeEquivalentTo([7, 6, -1, 4, 6], o => o.WithStrictOrdering());
  }
}
