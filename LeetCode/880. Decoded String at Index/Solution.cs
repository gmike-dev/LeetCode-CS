namespace LeetCode._880._Decoded_String_at_Index;

public class Solution
{
  public string DecodeAtIndex(string s, int k)
  {
    var i = 0;
    long n = 0;
    long m = k;
    for (; n < m; i++)
    {
      if (char.IsDigit(s[i]))
        n *= s[i] - '0';
      else
        n++;
    }
    for (i = i - 1; i >= 0; i--)
    {
      if (char.IsDigit(s[i]))
      {
        n /= s[i] - '0';
        m %= n;
      }
      else
      {
        if (m % n == 0)
          return s[i].ToString();
        n--;
      }
    }
    return string.Empty;
  }
}