namespace LeetCode.SlidingWindow._1652._Defuse_the_Bomb;

public class SlidingWindowSolution2
{
  public int[] Decrypt(int[] code, int k)
  {
    var n = code.Length;
    var ans = new int[n];
    if (k == 0)
      return ans;
    var start = k > 0 ? 1 : n + k;
    k = Math.Abs(k);
    var s = 0;
    for (var i = start; i < start + k; i++)
      s += code[i];
    for (var i = 0; i < n; i++)
    {
      ans[i] = s;
      s += code[(start + k) % n] - code[start % n];
      start++;
    }
    return ans;
  }
}

[TestFixture]
public class SlidingWindowSolution2Tests
{
  [TestCase(new[] { 5, 7, 1, 4 }, 3, new[] { 12, 10, 16, 13 })]
  [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 0, 0, 0, 0 })]
  [TestCase(new[] { 2, 4, 9, 3 }, -2, new[] { 12, 5, 6, 13 })]
  public void Test(int[] code, int k, int[] expected)
  {
    new SlidingWindowSolution2().Decrypt(code, k).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
