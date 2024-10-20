namespace LeetCode.Numbers._50._Pow_x__n_;

public class Solution
{
  public double MyPow(double x, int n)
  {
    double res = 1;

    long m = n;
    if (m < 0)
    {
      m = -m;
      while (m != 0)
      {
        if ((m & 1) != 0)
          res /= x;
        x *= x;
        m >>= 1;
      }
    }
    else
    {
      while (m != 0)
      {
        if ((m & 1) != 0)
          res *= x;
        x *= x;
        m >>= 1;
      }
    }
    return res;
  }
}
