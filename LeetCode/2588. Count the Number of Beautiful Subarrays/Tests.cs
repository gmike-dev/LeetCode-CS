namespace LeetCode._2588._Count_the_Number_of_Beautiful_Subarrays;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 3, 1, 2, 4 }, 2)]
  [TestCase(new[] { 1, 10, 4 }, 0)]
  public void Test(int[] nums, int expected)
  {
    new Solution().BeautifulSubarrays(nums).Should().Be(expected);
    new DictionarySolution().BeautifulSubarrays(nums).Should().Be(expected);
  }
}
