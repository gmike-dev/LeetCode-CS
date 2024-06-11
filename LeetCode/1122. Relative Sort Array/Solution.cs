namespace LeetCode._1122._Relative_Sort_Array;

public class Solution
{
  public int[] RelativeSortArray(int[] arr1, int[] arr2)
  {
    var cnt = new int[1001];
    foreach (var x in arr1)
      cnt[x]++;
    var result = new int[arr1.Length];
    var i = 0;
    foreach (var x in arr2)
    {
      while (cnt[x] > 0)
      {
        result[i++] = x;
        cnt[x]--;
      }
    }
    for (var x = 0; x < cnt.Length; x++)
    {
      while (cnt[x] > 0)
      {
        result[i++] = x;
        cnt[x]--;
      }
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19 }, new[] { 2, 1, 4, 3, 9, 6 },
    new[] { 2, 2, 2, 1, 4, 3, 3, 9, 6, 7, 19 })]
  [TestCase(new[] { 28, 6, 22, 8, 44, 17 }, new[] { 22, 28, 8, 6 }, new[] { 22, 28, 8, 6, 17, 44 })]
  public void Test(int[] arr1, int[] arr2, int[] expected)
  {
    new Solution().RelativeSortArray(arr1, arr2).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
