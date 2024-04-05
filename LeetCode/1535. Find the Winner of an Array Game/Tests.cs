namespace LeetCode._1535._Find_the_Winner_of_an_Array_Game;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 2, 1, 3, 5, 4, 6, 7 }, 2, 5)]
  [TestCase(new[] { 3, 2, 1 }, 10, 3)]
  public void Test(int[] nums, int k, int expected)
  {
    new Solution().GetWinner(nums, k).Should().Be(expected);
  }
}
