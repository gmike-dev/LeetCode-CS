namespace LeetCode._2251._Number_of_Flowers_in_Full_Bloom;

public class BinarySearchSolution
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
    var result = new int[m];
    for (var i = 0; i < m; i++)
    {
      var l = UpperBound(left, people[i]);
      var r = UpperBound(right, people[i] - 1);
      result[i] = l - r;
    }
    return result;
  }

  private static int UpperBound(int[] a, int value)
  {
    var l = 0;
    var r = a.Length - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (a[m] <= value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] <= value ? a.Length : l;
  }
}
