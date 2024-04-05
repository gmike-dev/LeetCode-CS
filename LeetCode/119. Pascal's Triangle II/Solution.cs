namespace LeetCode._119._Pascal_s_Triangle_II;

public class Solution
{
  public IList<int> GetRow(int rowIndex)
  {
    var a = new int[rowIndex + 1];
    for (var i = 0; i <= rowIndex; i++)
    {
      a[0] = 1;
      var prev = a[0];
      for (var j = 1; j <= i; j++)
      {
        (a[j], prev) = (prev + a[j], a[j]);
      }
    }
    return a;
  }
}
