namespace LeetCode._41._First_Missing_Positive;

public class InPlaceSolution2
{
  public int FirstMissingPositive(int[] nums)
  {
    var n = nums.Length;
    for (var i = 0; i < n; i++)
    {
      if (nums[i] < 1 || nums[i] > n)
      {
        nums[i] = 0;
      }
    }
    for (var i = 0; i < n; i++)
    {
      while (nums[i] != 0 && nums[i] != i + 1 && nums[i] != nums[nums[i] - 1])
      {
        (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
      }
    }
    for (var i = 0; i < n; i++)
    {
      if (nums[i] != i + 1)
      {
        return i + 1;
      }
    }
    return n + 1;
  }
}

[TestFixture]
public class InPlaceSolution2Tests
{
  [TestCase(new[] { 1, 2, 0 }, 3)]
  [TestCase(new[] { 3, 4, -1, 1 }, 2)]
  [TestCase(new[] { 7, 8, 9, 11, 12 }, 1)]
  [TestCase(new[] { 1, 2, (int)1e6 }, 3)]
  [TestCase(new[] { 1 }, 2)]
  public void Test(int[] a, int expected)
  {
    new InPlaceSolution2().FirstMissingPositive(a).Should().Be(expected);
  }
}
