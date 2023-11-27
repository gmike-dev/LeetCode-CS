namespace LeetCode._935._Knight_Dialer;

public class BetterDpSolution
{
  public int KnightDialer(int n)
  {
    const int mod = (int)1e9 + 7;
    /* Transition map:
     * A B A
     * C _ C
     * A B A
     * _ D _ */
    if (n == 1)
      return 10;
    var a = 4L;
    var b = 2L;
    var c = 2L;
    var d = 1L;
    for (var i = 1; i < n; i++)
    {
      (a, b, c, d) = (2 * (b + c) % mod, a, (a + 2 * d) % mod, c);
    }
    return (int)((a + b + c + d) % mod);
  }
}