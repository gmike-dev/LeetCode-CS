namespace LeetCode._118._Pascal_Triangle;

public class Solution
{
  public IList<IList<int>> Generate(int numRows)
  {
    var result = new int[numRows][];
    for (var i = 0; i < numRows; i++)
      result[i] = new int[i + 1];
    result[0][0] = 1;
    for (var i = 1; i < numRows; i++)
    {
      var prev = result[i - 1];
      var curr = result[i];
      curr[0] = 1;
      for (var j = 1; j < i; j++)
        curr[j] = prev[j - 1] + prev[j];
      curr[^1] = 1;
    }
    return result;
  }
}
