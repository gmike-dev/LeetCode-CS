namespace LeetCode._415._Add_Strings;

public class Solution
{
  public string AddStrings(string num1, string num2)
  {
    var carry = 0;
    var n = Math.Max(num1.Length, num2.Length);
    var result = new Stack<char>(n + 1);
    for (var i = 1; i <= n || carry > 0; i++)
    {
      var s = carry;
      if (i <= num1.Length)
        s += num1[^i] - '0';
      if (i <= num2.Length)
        s += num2[^i] - '0';
      result.Push((char)(s % 10 + '0'));
      carry = s / 10;
    }
    return new string(result.ToArray());
  }
}
