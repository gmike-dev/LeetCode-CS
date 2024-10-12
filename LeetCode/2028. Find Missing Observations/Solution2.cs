namespace LeetCode._2028._Find_Missing_Observations;

public class Solution2
{
  public int[] MissingRolls(int[] rolls, int mean, int n)
  {
    var m = rolls.Length;
    var sm = rolls.Sum();
    var sn = mean * (m + n) - sm;
    if (sn < n || sn > 6 * n)
      return [];
    var result = new int[n];
    result.AsSpan().Fill(sn / n);
    for (var i = 0; i < sn % n; i++)
      result[i]++;
    return result;
  }

  private static void FastInc(Span<int> a, Span<int> result)
  {
    var n = a.Length;
    var remaining = n % Vector<int>.Count;
    for (var i = 0; i < n - remaining; i += Vector<int>.Count)
    {
      var v1 = new Vector<int>(a[i..]);
      (v1 + Vector<int>.One).CopyTo(result[i..]);
    }
    for (var i = n - remaining; i < n; i++)
    {
      result[i] = a[i] + 1;
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 3, 2, 4, 3 }, 4, 2, new[] { 6, 6 })]
  [TestCase(new[] { 1, 5, 6 }, 3, 4, new[] { 3, 2, 2, 2 })]
  [TestCase(new[] { 1, 2, 3, 4 }, 6, 4, new int[] { })]
  [TestCase(new[] { 1, 5, 6 }, 4, 4, new[] { 4, 4, 4, 4 })]
  public void Test(int[] rolls, int mean, int n, int[] expected)
  {
    new Solution2().MissingRolls(rolls, mean, n).Should().BeEquivalentTo(expected);
  }
}
