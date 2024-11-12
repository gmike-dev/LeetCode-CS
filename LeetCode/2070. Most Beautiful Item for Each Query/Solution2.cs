namespace LeetCode._2070._Most_Beautiful_Item_for_Each_Query;

public class Solution2
{
  public int[] MaximumBeauty(int[][] items, int[] queries)
  {
    Array.Sort(items, (x, y) => x[0] - y[0]);
    for (var i = 1; i < items.Length; i++)
      items[i][1] = Math.Max(items[i][1], items[i - 1][1]);
    var result = new int[queries.Length];
    for (var i = 0; i < queries.Length; i++)
    {
      var l = 0;
      var r = items.Length;
      while (l < r)
      {
        var m = l + (r - l) / 2;
        if (items[m][0] > queries[i])
          r = m;
        else
          l = m + 1;
      }
      result[i] = r == 0 ? 0 : items[r - 1][1];
    }
    return result;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().MaximumBeauty([[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]], [1, 2, 3, 4, 5, 6]).Should()
      .BeEquivalentTo([2, 4, 5, 5, 6, 6], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution2().MaximumBeauty([[1, 2], [1, 2], [1, 3], [1, 4]], [1]).Should()
      .BeEquivalentTo([4], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution2().MaximumBeauty([[10, 1000]], [5]).Should()
      .BeEquivalentTo([0], o => o.WithStrictOrdering());
  }
}
