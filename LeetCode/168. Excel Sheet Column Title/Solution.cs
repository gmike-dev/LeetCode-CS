namespace LeetCode._168._Excel_Sheet_Column_Title;

public class Solution
{
  public string ConvertToTitle(int columnNumber)
  {
    var s = new Stack<char>();

    while (columnNumber > 0)
    {
      columnNumber--;
      var d = columnNumber % 26;
      s.Push((char)('A' + d));
      columnNumber /= 26;
    }

    return string.Join("", s);
  }
}
