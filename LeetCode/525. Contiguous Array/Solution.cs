namespace LeetCode._525._Contiguous_Array;

public class Solution
{
  public int FindMaxLength(int[] a)
  {
    var d = new Dictionary<int, int> { { 0, -1 } };
    var n = a.Length;
    var result = 0;
    var s = 0;
    for (var i = 0; i < n; i++)
    {
      if (a[i] == 0)
        s++;
      else
        s--;
      if (!d.TryAdd(s, i))
        result = Math.Max(result, i - d[s]);
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 0, 1 }, 2)]
  [TestCase(new[] { 0, 1, 0 }, 2)]
  [TestCase(new[] { 0 }, 0)]
  [TestCase(new[] { 1, 1 }, 0)]
  [TestCase(new[] { 0, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 1, 1 }, 12)]
  [TestCase(new[] { 0, 0, 1, 0, 0, 0, 1, 1 }, 6)]
  public void Test(int[] a, int expected)
  {
    new Solution().FindMaxLength(a).Should().Be(expected);
  }
}
