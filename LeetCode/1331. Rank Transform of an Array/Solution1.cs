namespace LeetCode._1331._Rank_Transform_of_an_Array;

public class Solution1
{
  public int[] ArrayRankTransform(int[] arr)
  {
    var d = new SortedDictionary<int, List<int>>();
    for (var i = 0; i < arr.Length; i++)
    {
      if (d.TryGetValue(arr[i], out var list))
        list.Add(i);
      else
        d[arr[i]] = [i];
    }
    var ranks = new int[arr.Length];
    var rank = 1;
    foreach (var x in d.Keys)
    {
      foreach (var i in d[x])
        ranks[i] = rank;
      rank++;
    }
    return ranks;
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase(new[] { 40, 10, 20, 30 }, new[] { 4, 1, 2, 3 })]
  [TestCase(new[] { 100, 100, 100 }, new[] { 1, 1, 1 })]
  [TestCase(new[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 }, new[] { 5, 3, 4, 2, 8, 6, 7, 1, 3 })]
  public void Test(int[] arr, int[] expected)
  {
    new Solution1().ArrayRankTransform(arr).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
