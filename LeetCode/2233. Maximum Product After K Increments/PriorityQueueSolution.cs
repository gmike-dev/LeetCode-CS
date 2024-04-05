namespace LeetCode._2233._Maximum_Product_After_K_Increments;

public class PriorityQueueSolution
{
  public int MaximumProduct(int[] nums, int k)
  {
    var q = new PriorityQueue<int, int>();
    foreach (var num in nums)
      q.Enqueue(num, num);
    for (var i = 0; i < k; i++)
    {
      var min = q.Peek();
      q.EnqueueDequeue(min + 1, min + 1);
    }
    return (int)q.UnorderedItems.Aggregate(1L, (p, item) => p * item.Element % 1000000007);
  }
}
