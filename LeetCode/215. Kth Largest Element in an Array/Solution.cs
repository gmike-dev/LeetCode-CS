namespace LeetCode._215._Kth_Largest_Element_in_an_Array;

public class Solution
{
  public int FindKthLargest(int[] nums, int k)
  {
    var q = new PriorityQueue<int, int>(k);
    foreach (var num in nums)
    {
      if (q.Count < k)
        q.Enqueue(num, num);
      else
        q.EnqueueDequeue(num, num);
    }
    return q.Peek();
  }
}
