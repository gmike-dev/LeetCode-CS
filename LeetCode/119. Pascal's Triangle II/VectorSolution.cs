namespace LeetCode._119._Pascal_s_Triangle_II;

public class VectorSolution
{
  public IList<int> GetRow(int rowIndex)
  {
    var n = rowIndex + 1;
    var a = new int[n];
    var b = new int[n];
    for (var i = 0; i < n; i++)
    {
      a[0] = 1;
      FastSum(a.AsSpan(0, i), a.AsSpan(1, i), b.AsSpan(1, i));
      b[i] = 1;
      (a, b) = (b, a);
    }
    return a;
  }

  private static void FastSum(Span<int> a, Span<int> b, Span<int> result)
  {
    var n = a.Length;
    var remaining = n % Vector<int>.Count;
    for (var i = 0; i < n - remaining; i += Vector<int>.Count)
    {
      var v1 = new Vector<int>(a[i..]);
      var v2 = new Vector<int>(b[i..]);
      (v1 + v2).CopyTo(result[i..]);
    }
    for (var i = n - remaining; i < n; i++)
    {
      result[i] = a[i] + b[i];
    }
  }
}
