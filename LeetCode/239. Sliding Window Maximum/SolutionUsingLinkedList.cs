using System.Collections.Generic;

namespace LeetCode._239._Sliding_Window_Maximum;

public class SolutionUsingLinkedList
{
  public int[] MaxSlidingWindow(int[] nums, int k)
  {
    var deque = new LinkedList<int>();
    for (var i = 0; i < k; i++)
      AddToWindow(deque, nums, i);
    var n = nums.Length;
    var result = new List<int>(n) { nums[deque.First.Value] };
    for (var i = k; i < n; i++)
    {
      if (deque.First.Value == i - k)
        deque.RemoveFirst();
      AddToWindow(deque, nums, i);
      result.Add(nums[deque.First.Value]);
    }
    return result.ToArray();
  }

  private static void AddToWindow(LinkedList<int> deque, int[] nums, int index)
  {
    while (deque.Last is { } lastNode && nums[index] >= nums[lastNode.Value])
      deque.RemoveLast(); 
    deque.AddLast(index);
  }

}