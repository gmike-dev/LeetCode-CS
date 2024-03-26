using System.Collections;

namespace LeetCode._41._First_Missing_Positive;

public class SolutionUsingMemory
{
  public int FirstMissingPositive(int[] a)
  {
    const int max = (int)1e5;
    var used = new BitArray(max + 1);
    foreach (var x in a)
    {
      if (x <= 0 || x > max)
        continue;
      used[x] = true;
    }
    for (var x = 1; x < max; x++)
    {
      if (!used[x])
        return x;
    }
    return max + 1;
  }
}
