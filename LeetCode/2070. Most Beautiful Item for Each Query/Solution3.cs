namespace LeetCode._2070._Most_Beautiful_Item_for_Each_Query;

public class Solution3
{
  public int[] MaximumBeauty(int[][] items, int[] queries)
  {
    var sortedItems = items.OrderBy(x => x[0]).ToArray();
    var prices = sortedItems.Select(i => i[0]).ToArray();
    var beauties = sortedItems.Select(i => i[1]).ToArray();
    for (var i = 1; i < beauties.Length; i++)
      beauties[i] = Math.Max(beauties[i], beauties[i - 1]);
    var queryIndexes = Enumerable.Range(0, queries.Length).ToArray();
    Array.Sort(queryIndexes, (i, j) => queries[i] - queries[j]);
    var result = new int[queryIndexes.Length];
    var j = 0;
    foreach (var i in queryIndexes)
    {
      while (j < prices.Length && prices[j] <= queries[i])
        j++;
      result[i] = j == 0 ? 0 : beauties[j - 1];
    }
    return result;
  }
}

[TestFixture]
public class Solution3Tests
{
  [Test]
  public void Test1()
  {
    new Solution3().MaximumBeauty([[1, 2], [3, 2], [2, 4], [5, 6], [3, 5]], [1, 2, 3, 4, 5, 6]).Should()
      .BeEquivalentTo([2, 4, 5, 5, 6, 6], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution3().MaximumBeauty([[1, 2], [1, 2], [1, 3], [1, 4]], [1]).Should()
      .BeEquivalentTo([4], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution3().MaximumBeauty([[10, 1000]], [5]).Should()
      .BeEquivalentTo([0], o => o.WithStrictOrdering());
  }
}

