namespace LeetCode.Numbers._670._Maximum_Swap;

public class Solution
{
  public int MaximumSwap(int num)
  {
    var s = num.ToString().ToCharArray();
    for (var i = 0; i < s.Length - 1; i++)
    {
      var maxPos = i;
      for (var j = i + 1; j < s.Length; j++)
      {
        if (s[j] >= s[maxPos])
          maxPos = j;
      }
      if (s[i] < s[maxPos])
      {
        (s[i], s[maxPos]) = (s[maxPos], s[i]);
        break;
      }
    }
    return int.Parse(s);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(2736, 7236)]
  [TestCase(9973, 9973)]
  [TestCase(0, 0)]
  [TestCase(1234, 4231)]
  [TestCase(98368, 98863)]
  public void Test(int num, int expected)
  {
    new Solution().MaximumSwap(num).Should().Be(expected);
  }
}
