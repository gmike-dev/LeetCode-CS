namespace LeetCode._41._First_Missing_Positive;

public class InPlaceSolution
{
  public int FirstMissingPositive(int[] a)
  {
    if (!a.Contains(1))
      return 1;
    var n = a.Length;
    for (var i = 0; i < n; i++)
    {
      if (a[i] <= 0 || a[i] > n)
        a[i] = 1;
    }
    for (var i = 0; i < a.Length; i++)
    {
      var x = Math.Abs(a[i]);
      if (a[x - 1] > 0)
        a[x - 1] *= -1;
    }
    for (var i = 1; i < n; i++)
    {
      if (a[i] > 0)
        return i + 1;
    }
    return n + 1;
  }

}
