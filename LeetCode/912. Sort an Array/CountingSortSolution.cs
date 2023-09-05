namespace LeetCode._912._Sort_an_Array;

public class CountingSortSolution
{
  public int[] SortArray(int[] nums)
  {
    const int M = 50000;
    var cnt = new int[2 * M + 1];
    foreach (var num in nums)
    {
      cnt[M + num]++;
    }
    var pos = 0;
    for (var num = 0; num < cnt.Length; num++)
    {
      while (cnt[num] > 0)
      {
        nums[pos++] = num - M;
        cnt[num]--;
      }
    }
    return nums;
  }
}