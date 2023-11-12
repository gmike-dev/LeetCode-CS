namespace LeetCode._678._Valid_Parenthesis_String;

public class Solution
{
  public bool CheckValidString(string s)
  {
    var best = 0;
    var worst = 0;
    foreach (var c in s)
    {
      if (c == '(')
      {
        best++;
        worst++;
      }
      else if (c == '*')
      {
        best++;
        worst--;
      }
      else
      {
        best--;
        worst--;
        if (best < 0)
          return false;
      }
      if (worst < 0)
        worst = 0;
    }
    return worst == 0;
  }
}