namespace LeetCode._2610._Convert_an_Array_Into_a_2D_Array;

public class Solution
{
  public IList<IList<int>> FindMatrix(int[] nums)
  {
    var count = new int[201];
    foreach (var num in nums)
      count[num]++;
    var result = new List<IList<int>>();
    for (var i = 1; i < count.Length; i++)
    {
      for (var j = 0; j < count[i]; j++)
      {
        if (j == result.Count)
          result.Add(new List<int>());
        result[j].Add(i);
      }
    }
    return result;
  }
}
