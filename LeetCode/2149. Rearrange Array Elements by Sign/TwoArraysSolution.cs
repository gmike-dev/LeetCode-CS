using System.Linq;

namespace LeetCode._2149._Rearrange_Array_Elements_by_Sign;

public class TwoArraysSolution
{
  public int[] RearrangeArray(int[] nums)
  {
    var n = nums.Length;
    var pos = nums.Where(x => x > 0).ToArray();
    var neg = nums.Where(x => x < 0).ToArray();
    var result = new int[n];
    var j = 0;
    var k = 0;
    for (var i = 0; i < n; i += 2)
    {
      result[i] = pos[j++];
      result[i + 1] = neg[k++];
    }
    return result;
  }
}
