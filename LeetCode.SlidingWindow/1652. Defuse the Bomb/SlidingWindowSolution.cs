namespace LeetCode.SlidingWindow._1652._Defuse_the_Bomb;

public class SlidingWindowSolution
{
  public int[] Decrypt(int[] code, int k)
  {
    var n = code.Length;
    var ans = new int[n];
    if (k == 0)
      return ans;
    if (k < 0)
      code.AsSpan().Reverse();
    var s = 0;
    for (var i = 0; i < Math.Abs(k); i++)
      s += code[i];
    for (var i = 0; i < n; i++)
    {
      s += code[(i + Math.Abs(k)) % n] - code[i];
      ans[i] = s;
    }
    if (k < 0)
      ans.AsSpan().Reverse();
    return ans;
  }
}

[TestFixture]
public class SlidingWindowSolutionTests
{
  [TestCase(new[] { 5, 7, 1, 4 }, 3, new[] { 12, 10, 16, 13 })]
  [TestCase(new[] { 1, 2, 3, 4 }, 0, new[] { 0, 0, 0, 0 })]
  [TestCase(new[] { 2, 4, 9, 3 }, -2, new[] { 12, 5, 6, 13 })]
  public void Test(int[] code, int k, int[] expected)
  {
    new SlidingWindowSolution().Decrypt(code, k).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}

