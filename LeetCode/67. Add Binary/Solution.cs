using System;

namespace LeetCode._67._Add_Binary;

public class Solution
{
  public string AddBinary(string a, string b)
  {
    var result = new char[Math.Max(a.Length, b.Length) + 1];
    var carry = 0;
    var i = a.Length - 1;
    var j = b.Length - 1;
    var k = result.Length;
    
    while (i >= 0 || j >= 0)
    {
      var s = carry;
      if (i >= 0)
        s += a[i--] - '0';
      if (j >= 0)
        s += b[j--] - '0';
      var d = s & 1;
      result[--k] = (char)(d + '0');
      carry = s >> 1;
    }
    if (carry != 0)
      result[--k] = '1';
    return new string(result.AsSpan(k));
  }
}