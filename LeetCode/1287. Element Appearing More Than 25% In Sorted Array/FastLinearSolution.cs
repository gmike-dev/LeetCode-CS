namespace LeetCode._1287._Element_Appearing_More_Than_25__In_Sorted_Array;

public class FastLinearSolution
{
  public int FindSpecialInteger(int[] a)
  {
    var n = a.Length;
    var len = n / 4;
    for (var i = 0; i < n - len; i++)
    {
      if (a[i] == a[i + len])
        return a[i];
    }
    return 0;
  }

}