using System;

namespace LeetCode._1071._Greatest_Common_Divisor_of_Strings;

public class Solution
{
  public string GcdOfStrings(string str1, string str2)
  {
    if (str1 + str2 != str2 + str1)
      return string.Empty;
    var gcd = Gcd(str1.Length, str2.Length);
    return str1[..gcd];
  }

  private static int Gcd(int a, int b)
  {
    while (b != 0)
    {
      a %= b;
      (b, a) = (a, b);
    }
    return a;
  }
  
  public string GcdOfStrings_Bruteforce(string str1, string str2)
  {
    if (str1.Length > str2.Length)
      (str1, str2) = (str2, str1);
    for (var gcdLength = str1.Length; gcdLength > 0; gcdLength--)
    {
      var substring = str1.AsSpan(0, gcdLength);
      if (IsDivisible(str1, substring) && IsDivisible(str2, substring))
        return str1[..gcdLength];
    }
    return string.Empty;
  }

  private static bool IsDivisible(string testString, ReadOnlySpan<char> substring)
  {
    if (testString.Length % substring.Length != 0)
      return false;
    for (var i = 0; i < substring.Length; i++)
    {
      for (var j = i; j < testString.Length; j += substring.Length)
      {
        if (testString[j] != substring[i])
          return false;
      }
    }
    return true;
  }
}