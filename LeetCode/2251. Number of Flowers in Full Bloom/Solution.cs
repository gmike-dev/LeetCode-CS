namespace LeetCode._2251._Number_of_Flowers_in_Full_Bloom;

public class Solution
{
  public int[] FullBloomFlowers(int[][] flowers, int[] people)
  {
    var n = flowers.Length;
    var left = new int[n];
    var right = new int[n];
    for (var i = 0; i < n; i++)
    {
      left[i] = flowers[i][0];
      right[i] = flowers[i][1];
    }
    Array.Sort(left);
    Array.Sort(right);
    var m = people.Length;
    var sorted = new int[m];
    for (var i = 0; i < m; i++)
      sorted[i] = i;
    Array.Sort(sorted, (x, y) => people[x].CompareTo(people[y]));
    var result = new int[m];
    for (int i = 0, l = 0, r = 0; i < m; i++)
    {
      var p = sorted[i];
      while (l < n && left[l] <= people[p])
        l++;
      while (r < n && right[r] < people[p])
        r++;
      result[p] = l - r;
    }
    return result;
  }
}
