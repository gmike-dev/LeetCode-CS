namespace LeetCode._2028._Find_Missing_Observations;

public class Solution1
{
  public int[] MissingRolls(int[] rolls, int mean, int n)
  {
    var m = rolls.Length;
    var sm = rolls.Sum();
    var sn = mean * (m + n) - sm;
    if (sn < n || sn > 6 * n)
      return [];
    var result = new int[n];
    result.AsSpan().Fill(1);
    for (var i = 0; i < n; i++)
    {
      if (6 * (i + 1) + n - i - 1 > sn)
      {
        result[i] = sn - 6 * i - (n - i - 1);
        break;
      }
      result[i] = 6;
    }
    return result;
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase(new[] { 3, 2, 4, 3 }, 4, 2, new[] { 6, 6 })]
  [TestCase(new[] { 1, 5, 6 }, 3, 4, new[] { 6, 1, 1, 1 })]
  [TestCase(new[] { 1, 2, 3, 4 }, 6, 4, new int[] { })]
  [TestCase(new[] { 1, 5, 6 }, 4, 4, new[] { 6, 6, 3, 1 })]
  public void Test(int[] rolls, int mean, int n, int[] expected)
  {
    new Solution1().MissingRolls(rolls, mean, n).Should().BeEquivalentTo(expected);
  }
}
