using System.Text;

namespace LeetCode.Integer_to_Roman;

public class Solution
{
  public string IntToRoman(int num)
  {
    var sb = new StringBuilder();
    while (num >= 1000)
    {
      sb.Append('M');
      num -= 1000;
    }
    while (num >= 500)
    {
      sb.Append('D');
      num -= 500;
    }
    while (num >= 100)
    {
      sb.Append('C');
      num -= 100;
    }
    while (num >= 50)
    {
      sb.Append('L');
      num -= 50;
    }
    while (num >= 10)
    {
      sb.Append('X');
      num -= 10;
    }
    while (num >= 5)
    {
      sb.Append('V');
      num -= 5;
    }
    while (num >= 1)
    {
      sb.Append('I');
      num -= 1;
    }
    return sb.ToString();
  }
}