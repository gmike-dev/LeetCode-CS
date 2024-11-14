namespace LeetCode._1526._Minimum_Number_of_Increments_on_Subarrays_to_Form_a_Target_Array;

public class Solution
{
  public int MinNumberOperations(int[] target)
  {
    int result = 0, prev = 0;
    foreach (var t in target)
    {
      result += Math.Max(0, t - prev);
      prev = t;
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 1, 2, 3, 2, 1 }, 3)]
  [TestCase(new[] { 3, 1, 1, 2 }, 4)]
  [TestCase(new[] { 3, 1, 5, 4, 2 }, 7)]
  public void Test(int[] target, int expected)
  {
    new Solution().MinNumberOperations(target).Should().Be(expected);
  }
}
