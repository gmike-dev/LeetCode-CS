namespace LeetCode.PalindromeNumber;

public class Solution
{
  public bool IsPalindrome(int x)
  {
    if (x < 0)
      return false;
    var n = x;
    var m = 0;
    while (n != 0)
    {
      m = m * 10 + n % 10;
      n /= 10;
    }
    return x == m;
  }
}