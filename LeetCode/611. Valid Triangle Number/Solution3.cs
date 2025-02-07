namespace LeetCode._611._Valid_Triangle_Number;

public class Solution3
{
  public int TriangleNumber(int[] nums)
  {
    CountingSort(nums, 1000);
    var count = 0;
    for (var k = 2; k < nums.Length; k++)
    {
      for (int i = 0, j = k - 1; i < j;)
      {
        if (nums[i] + nums[j] > nums[k])
        {
          count += j - i;
          j--;
        }
        else
        {
          i++;
        }
      }
    }
    return count;
  }

  private static void CountingSort(int[] nums, int maxValue)
  {
    Span<int> cnt = stackalloc int[maxValue + 1];
    foreach (var num in nums)
      cnt[num]++;
    var len = 0;
    for (var i = 0; len < nums.Length; i++)
    {
      for (var j = cnt[i]; j > 0; j--)
        nums[len++] = i;
    }
  }
}

[TestFixture]
public class Solution3Tests
{
  [TestCase(new[] { 2, 2, 3, 4 }, 3)]
  [TestCase(new[] { 4, 2, 3, 4 }, 4)]
  [TestCase(new[] { 0, 0, 0 }, 0)]
  public void Test(int[] nums, int expected)
  {
    new Solution3().TriangleNumber(nums).Should().Be(expected);
  }
}
