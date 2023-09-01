namespace LeetCode._338._Counting_Bits;

public class Solution
{
  public int[] CountBits(int n)
  {
    var count = new int[n + 1];
    for (var i = 1; i <= n; i++)
    {
      var k = i;
      var cnt = 0;
      while (k != 0)
      {
        cnt += k & 1;
        k >>= 1;
      }
      count[i] = cnt;
    }
    return count;
  }
}