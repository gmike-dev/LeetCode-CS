namespace LeetCode._739._Daily_Temperatures;

public class StackSolution
{
  public int[] DailyTemperatures(int[] t)
  {
    var n = t.Length;
    var result = new int[n];
    var s = new Stack<int>(n);
    for (var i = 0; i < n; i++)
    {
      while (s.TryPeek(out var d) && t[d] < t[i])
      {
        result[d] = i - d;
        s.Pop();
      }
      s.Push(i);
    }
    return result;
  }
}
