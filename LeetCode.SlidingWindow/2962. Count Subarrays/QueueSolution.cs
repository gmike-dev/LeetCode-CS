namespace LeetCode.SlidingWindow._2962._Count_Subarrays;

public class QueueSolution
{
  public long CountSubarrays(int[] a, int k)
  {
    var n = a.Length;
    var max = a.Max();
    var q = new Queue<int>();
    var answer = 0L;
    for (var r = 0; r < n; r++)
    {
      if (a[r] == max)
      {
        q.Enqueue(r);
        if (q.Count > k)
          q.Dequeue();
      }
      if (q.Count == k)
        answer += q.Peek() + 1;
    }
    return answer;
  }
}
