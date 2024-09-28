namespace LeetCode._3301._Maximize_the_Total_Height_of_Unique_Towers;

public class Solution
{
  public long MaximumTotalSum(int[] maximumHeight)
  {
    Array.Sort(maximumHeight, (x, y) => y - x);
    var h = maximumHeight[0];
    long s = h;
    for (var i = 1; i < maximumHeight.Length; i++)
    {
      h = Math.Min(h - 1, maximumHeight[i]);
      if (h <= 0)
        return -1;
      s += h;
    }
    return s;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 2, 3, 4, 3 }, 10)]
  [TestCase(new[] { 15, 10 }, 25)]
  [TestCase(new[] { 2, 2, 1 }, -1)]
  public void Test(int[] maximumHeight, long expected)
  {
    new Solution().MaximumTotalSum(maximumHeight).Should().Be(expected);
  }
}
