namespace LeetCode._1870._Minimum_Speed_to_Arrive_on_Time;

public class Solution
{
  public int MinSpeedOnTime(int[] dist, double hour)
  {
    const int max = 10000001;
    var vMin = 1;
    var vMax = max;
    while (vMin < vMax)
    {
      var mv = vMin + (vMax - vMin) / 2;
      var t = GetTravelTime(dist, mv);
      if (t <= hour)
        vMax = mv;
      else
        vMin = mv + 1;
    }
    return vMax == max ? -1 : vMax;
  }

  private static double GetTravelTime(int[] dist, int v)
  {
    var h = 0.0;
    for (var i = 0; i < dist.Length - 1; i++)
      h += Math.Ceiling((double)dist[i] / v);
    return h + (double)dist[^1] / v;
  }
}
