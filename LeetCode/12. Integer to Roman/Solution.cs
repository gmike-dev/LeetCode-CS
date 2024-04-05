namespace LeetCode._12._Integer_to_Roman;

public class Solution
{
  public string IntToRoman(int num)
  {
    var sb = new StringBuilder();
    AppendTo(sb, ref num, 1000, "M");
    AppendTo(sb, ref num, 900, "CM");
    AppendTo(sb, ref num, 500, "D");
    AppendTo(sb, ref num, 400, "CD");
    AppendTo(sb, ref num, 100, "C");
    AppendTo(sb, ref num, 90, "XC");
    AppendTo(sb, ref num, 50, "L");
    AppendTo(sb, ref num, 40, "XL");
    AppendTo(sb, ref num, 10, "X");
    AppendTo(sb, ref num, 9, "IX");
    AppendTo(sb, ref num, 5, "V");
    AppendTo(sb, ref num, 4, "IV");
    AppendTo(sb, ref num, 1, "I");
    return sb.ToString();
  }

  private static void AppendTo(StringBuilder sb, ref int num, int targetValue, string replacement)
  {
    while (num >= targetValue)
    {
      sb.Append(replacement);
      num -= targetValue;
    }
  }
}
