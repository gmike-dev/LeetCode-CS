namespace LeetCode.__Numbers._43._Multiply_Strings;

public class Solution
{
  public string Multiply(string num1, string num2)
  {
    var result = new List<int>();
    for (var i = 1; i <= num2.Length; i++)
    {
      var line = new List<int>();
      for (var j = 1; j < i; j++)
        line.Add(0);
      var d2 = num2[^i] - '0';
      var carry = 0;
      for (var j = 1; j <= num1.Length; j++)
      {
        var d1 = num1[^j] - '0';
        var s = carry + d1 * d2;
        line.Add(s % 10);
        carry = s / 10;
      }
      while (carry > 0)
      {
        line.Add(carry);
        carry /= 10;
      }
      Add(result, line);
    }
    return NumToString(result);
  }

  private static string NumToString(List<int> num)
  {
    if (num[^1] == 0)
      return "0";
    var sb = new StringBuilder();
    for (var i = num.Count - 1; i >= 0; i--)
      sb.Append((char)(num[i] + '0'));
    return sb.ToString();
  }

  private static void Add(List<int> result, List<int> value)
  {
    var carry = 0;
    for (var i = 0; i < Math.Max(result.Count, value.Count) || carry > 0; i++)
    {
      var s = carry;
      if (i < value.Count)
        s += value[i];
      if (i < result.Count)
        s += result[i];
      var d = s % 10;
      if (i < result.Count)
        result[i] = d;
      else
        result.Add(d);
      carry = s / 10;
    }
  }
}
