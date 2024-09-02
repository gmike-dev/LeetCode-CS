namespace LeetCode._1894._Find_the_Student_that_Will_Replace_the_Chalk;

public class Solution
{
  public int ChalkReplacer(int[] chalk, int k)
  {
    k = (int)(k % chalk.Select(c => (long)c).Sum());
    for (var i = 0; i < chalk.Length; i++)
    {
      if (k < chalk[i])
        return i;
      k -= chalk[i];
    }
    return -1;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 5, 1, 5 }, 22, 0)]
  [TestCase(new[] { 3, 4, 1, 2 }, 25, 1)]
  [TestCase(new[] { 22, 25, 39, 3, 45, 45, 12, 17, 32, 9 }, 835, 3)]
  public void Test1(int[] chalk, int k, int expected)
  {
    new Solution().ChalkReplacer(chalk, k).Should().Be(expected);
  }
}
