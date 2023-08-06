namespace LeetCode._70._Climbing_Stairs;

public class Solution
{
  public int ClimbStairs(int n)
  {
    if (n == 1)
      return 1;

    var a = 1;
    var b = 2;
    for (var i = 3; i <= n; i++)
      (b, a) = (a + b, b);
    return b;
  }
}