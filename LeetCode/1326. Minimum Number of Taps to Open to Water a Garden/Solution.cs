namespace LeetCode._1326._Minimum_Number_of_Taps_to_Open_to_Water_a_Garden;

public class Solution
{
  public int MinTaps(int n, int[] ranges)
  {
    var segments = new List<(int l, int r)>();
    for (var i = 0; i <= n; i++)
      segments.Add((Math.Max(0, i - ranges[i]), Math.Min(n, i + ranges[i])));
    segments.Sort();
    var curr = 0;
    while (curr < n && segments[curr].l == segments[curr + 1].l)
      curr++;
    var count = 1;
    while (curr < n && segments[curr].r < n)
    {
      var next = curr;
      for (var i = next + 1; i <= n && segments[i].l <= segments[curr].r; i++)
      {
        if (segments[i].r > segments[next].r)
          next = i;
      }
      if (next == curr)
        return -1;
      count++;
      curr = next;
    }
    if (segments[curr].r < n)
      return -1;
    return count;
  }
}
