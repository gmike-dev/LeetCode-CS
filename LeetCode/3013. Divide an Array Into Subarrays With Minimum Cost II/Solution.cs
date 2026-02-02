using LeetCode.Common;

namespace LeetCode._3013._Divide_an_Array_Into_Subarrays_With_Minimum_Cost_II;

public class Solution
{
  public long MinimumCost(int[] nums, int k, int dist)
  {
    var n = nums.Length;
    var maxQ = new PriorityQueue<int, int>();
    var maxQItems = new HashSet<int>();
    var minQ = new PriorityQueue<int, int>();
    var minQItems = new HashSet<int>();
    var sum = 0L;
    for (var i = 2; i < n && i <= 1 + dist; i++)
    {
      maxQ.Enqueue(i, -nums[i]);
      maxQItems.Add(i);
      sum += nums[i];
      if (maxQItems.Count > k - 2)
      {
        var max = maxQ.Dequeue();
        maxQItems.Remove(max);
        sum -= nums[max];
        minQ.Enqueue(max, nums[max]);
        minQItems.Add(max);
      }
    }
    var minSum = nums[1] + sum;
    for (var i = 2; i < n - k + 2; i++)
    {
      if (!minQItems.Remove(i))
      {
        maxQItems.Remove(i);
        sum -= nums[i];
        while (minQ.Count > 0 && !minQItems.Contains(minQ.Peek()))
        {
          minQ.Dequeue();
        }
        if (minQ.Count > 0)
        {
          var min = minQ.Dequeue();
          minQItems.Remove(min);
          maxQ.Enqueue(min, -nums[min]);
          maxQItems.Add(min);
          sum += nums[min];
        }
      }
      var j = i + dist;
      if (j < n)
      {
        maxQ.Enqueue(j, -nums[j]);
        maxQItems.Add(j);
        sum += nums[j];
        if (maxQItems.Count > k - 2)
        {
          while (maxQ.Count > 0 && !maxQItems.Contains(maxQ.Peek()))
          {
            maxQ.Dequeue();
          }
          var max = maxQ.Dequeue();
          maxQItems.Remove(max);
          sum -= nums[max];
          minQ.Enqueue(max, nums[max]);
          minQItems.Add(max);
        }
      }
      minSum = Math.Min(minSum, nums[i] + sum);
    }
    return nums[0] + minSum;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,3,2,6,4,2]", 3, 3, 5)]
  [TestCase("[10,1,2,2,2,1]", 4, 3, 15)]
  [TestCase("[10,8,18,9]", 3, 1, 36)]
  [TestCase("[1,5,3,6]", 3, 2, 9)]
  [TestCase("[1024,131072,32768,134217728,16777216,1048576,64,8,8388608,268435456,512,8192,256,2097152,262144,536870912,524288,33554432,32,2048,67108864,4194304,2,65536,4,4096,16384,16,128,1]", 15, 15, 38624439)]
  public void Test(string nums, int k, int dist, long expected)
  {
    new Solution().MinimumCost(nums.Array(), k, dist).Should().Be(expected);
  }
}
