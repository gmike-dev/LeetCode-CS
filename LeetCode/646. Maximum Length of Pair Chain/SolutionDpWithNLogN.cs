namespace LeetCode._646._Maximum_Length_of_Pair_Chain;

public class SolutionDpWithNLogN
{
  public int FindLongestChain(int[][] pairs)
  {
    Array.Sort(pairs, (p1, p2) => p1[0].CompareTo(p2[0]));
    const int min = -1001;
    const int max = 1001;
    var n = pairs.Length;
    var d = new int[n + 1];
    d[0] = min;
    d.AsSpan(1).Fill(max);
    for (var i = 0; i < n; i++)
    {
      var len = UpperBound(d, pairs[i][0]);
      if (d[len - 1] < pairs[i][0] && pairs[i][1] < d[len])
        d[len] = pairs[i][1];
    }
    for (var len = n; len > 0; len--)
      if (d[len] != max)
        return len;
    return 0;
  }

  private static int UpperBound(int[] a, int value)
  {
    var result = a.AsSpan().BinarySearch(value);
    return result > 0 ? result + 1 : ~result;
  }
}
