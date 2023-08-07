using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._347._Top_K_Frequent_Elements;

public class Solution
{
  public int[] TopKFrequent(int[] nums, int k)
  {
    var counter = new Dictionary<int, int>();
    foreach (var num in nums)
    {
      if (counter.TryGetValue(num, out var count))
        counter[num] = count + 1;
      else
        counter[num] = 1;
    }

    var queue = new PriorityQueue<int, int>();
    foreach (var (num, count) in counter)
    {
      if (queue.Count < k)
        queue.Enqueue(num, count);
      else
        queue.EnqueueDequeue(num, count);
    }

    return queue.UnorderedItems.Select(item => item.Element).ToArray();
  }

  public int[] TopKFrequent_Sorting(int[] nums, int k)
  {
    const int minValue = -10000;
    const int maxValue = 10000;
    var cnt = new (int count, int value)[maxValue - minValue + 1];
    for (var i = minValue; i <= maxValue; i++)
      cnt[i - minValue].value = i;
    foreach (var n in nums)
      cnt[n - minValue].count++;
    Array.Sort(cnt, (x, y) => y.CompareTo(x));
    var result = new int[k];
    for (var i = 0; i < k; i++)
      result[i] = cnt[i].value;
    return result;
  }
}