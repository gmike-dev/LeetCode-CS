namespace LeetCode._526._Beautiful_Arrangement;

public class Solution
{
  public int CountArrangement(int n)
  {
    var items = new int[n];
    for (var i = 0; i < n; i++)
      items[i] = i + 1;
    return CountBeautifulPermutations(items);
  }

  private static int CountBeautifulPermutations(int[] items, int i = 0)
  {
    if (i == items.Length)
      return 1;
    var count = 0;
    for (var j = i; j < items.Length; j++)
    {
      if ((i + 1) % items[j] == 0 || items[j] % (i + 1) == 0)
      {
        (items[i], items[j]) = (items[j], items[i]);
        count += CountBeautifulPermutations(items, i + 1);
        (items[i], items[j]) = (items[j], items[i]);
      }
    }
    return count;
  }
}