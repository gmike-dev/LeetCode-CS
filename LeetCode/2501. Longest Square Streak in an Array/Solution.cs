namespace LeetCode._2501._Longest_Square_Streak_in_an_Array;

public class Solution
{
  public int LongestSquareStreak(int[] nums)
  {
    const int m = 100001;
    var exist = new bool[m];
    foreach (var num in nums)
      exist[num] = true;
    var maxLength = 0;
    for (var i = 2; i < m; i++)
    {
      if (!exist[i])
        continue;
      long value = i;
      var length = 0;
      while (value < m && exist[value])
      {
        exist[value] = false;
        length++;
        value *= value;
      }
      maxLength = Math.Max(maxLength, length);
    }
    return maxLength > 1 ? maxLength : -1;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 4, 3, 6, 16, 8, 2 }, 3)]
  [TestCase(new[] { 2, 3, 5, 6, 7 }, -1)]
  public void Test(int[] nums, int expected)
  {
    new Solution().LongestSquareStreak(nums).Should().Be(expected);
  }
}
