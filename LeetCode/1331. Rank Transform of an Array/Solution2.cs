namespace LeetCode._1331._Rank_Transform_of_an_Array;

public class Solution2
{
  public int[] ArrayRankTransform(int[] arr)
  {
    var n = arr.Length;
    var indexes = new int[n];
    for (var i = 0; i < n; i++)
      indexes[i] = i;
    indexes.AsSpan().Sort((x, y) => arr[x] - arr[y]);
    var rank = 0;
    var ranks = new int[n];
    for (var i = 0; i < n; i++)
    {
      if (i == 0 || arr[indexes[i]] != arr[indexes[i - 1]])
        rank++;
      ranks[indexes[i]] = rank;
    }
    return ranks;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 40, 10, 20, 30 }, new[] { 4, 1, 2, 3 })]
  [TestCase(new[] { 100, 100, 100 }, new[] { 1, 1, 1 })]
  [TestCase(new[] { 37, 12, 28, 9, 100, 56, 80, 5, 12 }, new[] { 5, 3, 4, 2, 8, 6, 7, 1, 3 })]
  [TestCase(new int[0], new int[0])]
  public void Test(int[] arr, int[] expected)
  {
    new Solution2().ArrayRankTransform(arr).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
