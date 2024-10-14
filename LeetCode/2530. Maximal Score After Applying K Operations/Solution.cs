namespace LeetCode._2530._Maximal_Score_After_Applying_K_Operations;

public class Solution
{
  public long MaxKelements(int[] nums, int k)
  {
    var q = new PriorityQueue<int, int>(nums.Length);
    foreach (var num in nums)
      q.Enqueue(num, -num);
    long score = 0;
    for (var i = 0; i < k; i++)
    {
      var val = q.Dequeue();
      if (val == 0)
        break;
      score += val;
      val = (val + 2) / 3;
      q.Enqueue(val, -val);
    }
    return score;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 10, 10, 10, 10, 10 }, 5, 50)]
  [TestCase(new[] { 1, 10, 3, 3, 3 }, 3, 17)]
  public void Test(int[] nums, int k, long expected)
  {
    new Solution().MaxKelements(nums, k).Should().Be(expected);
  }
}
