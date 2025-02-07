namespace LeetCode._611._Valid_Triangle_Number;

public class Solution2
{
  public int TriangleNumber(int[] nums)
  {
    CountingSort(nums);
    var n = nums.Length;
    var count = 0;
    for (var i = 0; i < n - 2; i++)
    {
      for (int j = i + 1, k = i + 1; j < n - 1; j++)
      {
        while (k < n && nums[i] + nums[j] > nums[k])
          k++;
        if (j < k)
          count += k - j - 1;
      }
    }
    return count;
  }

  private static void CountingSort(int[] nums)
  {
    Span<int> cnt = stackalloc int[1001];
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
public class Solution2Tests
{
  [TestCase(new[] { 2, 2, 3, 4 }, 3)]
  [TestCase(new[] { 4, 2, 3, 4 }, 4)]
  [TestCase(new[] { 0, 0, 0 }, 0)]
  public void Test(int[] nums, int expected)
  {
    new Solution2().TriangleNumber(nums).Should().Be(expected);
  }
}
