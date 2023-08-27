using System;
using System.Collections.Generic;

namespace LeetCode._415._Add_Strings;

public class Solution
{
  public string AddStrings(string num1, string num2)
  {
    var result = new List<char>();
    var carry = 0;
    var n = Math.Max(num1.Length, num2.Length);
    for (var i = 0; i < n || carry > 0; i++)
    {
      var s = carry;
      if (i < num1.Length)
        s += num1[^(i + 1)] - '0';
      if (i < num2.Length)
        s += num2[^(i + 1)] - '0';
      result.Add((char)(s % 10 + '0'));
      carry = s / 10;
    }
    result.Reverse();
    return string.Join("", result);
  }
}