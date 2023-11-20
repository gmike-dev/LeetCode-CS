namespace LeetCode._2391._Minimum_Amount_of_Time_to_Collect_Garbage;

public class Solution
{
  public int GarbageCollection(string[] garbage, int[] travel)
  {
    var n = garbage.Length;
    const int full = 0x5040;//  (1 << ('M' - 'A')) | (1 << ('P' - 'A')) | (1 << ('G' - 'A'));
    var met = 0;
    var metCnt = 0;
    var ans = 0;
    for (var i = n - 1; i >= 0; i--)
    {
      var s = garbage[i];
      for (var j = 0; j < s.Length && met != full; j++)
      {
        var mask = 1 << (s[j] - 'A');
        if ((met & mask) == 0)
        {
          metCnt++;
          met |= mask;
        }
      }
      ans += s.Length;
      if (i > 0)
        ans += metCnt * travel[i - 1];
    }
    return ans;
  }
}