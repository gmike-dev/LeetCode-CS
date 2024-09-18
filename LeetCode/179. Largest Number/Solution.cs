namespace LeetCode._179._Largest_Number;

public class Solution
{
  public string LargestNumber(int[] nums)
  {
    var a = new string[nums.Length];
    for (var i = 0; i < nums.Length; i++)
      a[i] = nums[i].ToString();
    Array.Sort(a, (x, y) => string.CompareOrdinal(y + x, x + y));
    return a[0] == "0" ? "0" : string.Join("", a);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 10, 2 }, "210")]
  [TestCase(new[] { 3, 30, 34, 5, 9 }, "9534330")]
  [TestCase(new[] { 432, 43243 }, "43243432")]
  [TestCase(new[] { 0, 0 }, "0")]
  [TestCase(new[] { 1000000000, 1000000000 }, "10000000001000000000")]
  public void Test(int[] nums, string expected)
  {
    new Solution().LargestNumber(nums).Should().Be(expected);
  }
}
