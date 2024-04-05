namespace LeetCode._169._Majority_Element;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 2, 3 }, 3)]
  [TestCase(new[] { 2, 2, 1, 1, 1, 2, 2 }, 2)]
  public void Test(int[] nums, int expected)
  {
    new Solution().MajorityElement(nums).Should().Be(expected);
    new SolutionUsingDictionary().MajorityElement(nums).Should().Be(expected);
  }
}
