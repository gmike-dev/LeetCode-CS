using System.Collections.Generic;
using System.Linq;

namespace LeetCode._989._Add_to_Array_Form_of_Integer;

public class Solution
{
  public IList<int> AddToArrayForm(int[] num, int k)
  {
    var carry = 0;
    var result = new Stack<int>();
    for (var i = 1; i <= num.Length || k > 0 || carry > 0; i++)
    {
      var s = carry + k % 10;
      if (i <= num.Length)
        s += num[^i];
      result.Push(s % 10);
      carry = s / 10;
      k /= 10;
    }
    return result.ToList();
  }
}