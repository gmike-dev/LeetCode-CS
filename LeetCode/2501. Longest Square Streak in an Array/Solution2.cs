namespace LeetCode._2501._Longest_Square_Streak_in_an_Array;

public class Solution2
{
  public int LongestSquareStreak(int[] nums)
  {
    var maxNum = nums.Max();
    var numbers = new HashSet<int>(nums);
    var maxLength = 0;
    for (var i = 2; i * i <= maxNum; i++)
    {
      if (!numbers.Contains(i))
        continue;
      var length = 0;
      for (long value = i; value <= maxNum && numbers.Remove((int)value); value *= value)
        length++;
      maxLength = Math.Max(maxLength, length);
    }
    return maxLength > 1 ? maxLength : -1;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 4, 3, 6, 16, 8, 2 }, 3)]
  [TestCase(new[] { 2, 3, 5, 6, 7 }, -1)]
  [TestCase(new[] { 10, 2, 13, 16, 8, 9, 13 }, -1)]
  [TestCase(new[] { 2, 4 }, 2)]
  public void Test(int[] nums, int expected)
  {
    new Solution2().LongestSquareStreak(nums).Should().Be(expected);
  }
}
