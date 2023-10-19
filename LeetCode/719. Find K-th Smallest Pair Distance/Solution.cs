using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._719._Find_K_th_Smallest_Pair_Distance;

public class Solution
{
  public int SmallestDistancePair(int[] nums, int k)
  {
    var n = nums.Max() + 1;
    var cnt = new int[n];
    foreach (var num in nums)
      cnt[num]++;
    var a = new List<(int val, int cnt)>();
    for (var i = 0; i < n; i++)
    {
      if (cnt[i] > 0)
        a.Add((i, cnt[i]));
    }
    var dist = new int[n];
    for (var i = 0; i < a.Count; i++)
    {
      dist[0] += a[i].cnt * (a[i].cnt - 1) / 2;
      for (var j = i + 1; j < a.Count; j++)
        dist[Math.Abs(a[j].val - a[i].val)] += a[i].cnt * a[j].cnt;
    }
    var pos = 0;
    for (var d = 0; d < dist.Length; d++)
    {
      pos += dist[d];
      if (k <= pos)
        return d;
    }
    return -1;
  }
}