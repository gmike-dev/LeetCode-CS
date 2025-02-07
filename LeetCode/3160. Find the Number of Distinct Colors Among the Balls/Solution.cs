namespace LeetCode._3160._Find_the_Number_of_Distinct_Colors_Among_the_Balls;

public class Solution
{
  public int[] QueryResults(int limit, int[][] queries)
  {
    var n = queries.Length;
    var color = new Dictionary<int, int>(n);
    var count = new Dictionary<int, int>(n);
    var result = new int[n];
    var distinctCount = 0;
    for (var i = 0; i < n; i++)
    {
      var q = queries[i];
      var pos = q[0];
      var newColor = q[1];
      if (color.TryGetValue(pos, out var oldColor) && --count[oldColor] == 0)
        distinctCount--;
      color[pos] = newColor;
      var oldCount = count.GetValueOrDefault(newColor);
      count[newColor] = oldCount + 1;
      if (oldCount == 0)
        distinctCount++;
      result[i] = distinctCount;
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().QueryResults(4, [[1, 4], [2, 5], [1, 3], [3, 4]]).Should()
      .BeEquivalentTo([1, 2, 2, 3], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().QueryResults(4, [[0, 1], [1, 2], [2, 2], [3, 4], [4, 5]]).Should()
      .BeEquivalentTo([1, 2, 2, 3, 4], o => o.WithStrictOrdering());
  }
}
