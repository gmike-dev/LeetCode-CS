namespace LeetCode.__Numbers._670._Maximum_Swap;

public class Solution2
{
  public int MaximumSwap(int num)
  {
    var s = num.ToString().ToCharArray();
    var x = -1;
    var y = -1;
    var maxPos = s.Length - 1;
    for (var i = s.Length - 2; i >= 0; i--)
    {
      if (s[i] > s[maxPos])
      {
        maxPos = i;
      }
      else if (s[i] < s[maxPos])
      {
        x = i;
        y = maxPos;
      }
    }
    if (x != -1)
      (s[x], s[y]) = (s[y], s[x]);

    return int.Parse(s);
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(2736, 7236)]
  [TestCase(9973, 9973)]
  [TestCase(0, 0)]
  [TestCase(1234, 4231)]
  [TestCase(98368, 98863)]
  public void Test(int num, int expected)
  {
    new Solution2().MaximumSwap(num).Should().Be(expected);
  }
}
