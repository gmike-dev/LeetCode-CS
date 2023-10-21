using System;
using System.Collections.Generic;

namespace LeetCode._1425._Constrained_Subsequence_Sum;

public class QueueSolution
{
  public int ConstrainedSubsetSum(int[] nums, int k)
  {
    var q = new MaxQueue(k + 1);
    q.Enqueue(nums[0]);
    var maxSum = nums[0];
    for (var i = 1; i < nums.Length; i++)
    {
      var s = Math.Max(nums[i], q.Max + nums[i]);
      maxSum = Math.Max(maxSum, s);
      q.Enqueue(s);
      if (i >= k)
        q.Dequeue();
    }
    return maxSum;
  }
  
  private class MaxStack
  {
    private readonly record struct StackElement(int Value, int Max);

    private readonly Stack<StackElement> _s;
    
    public int Count => _s.Count;

    public int Max => _s.TryPeek(out var top) ? top.Max : int.MinValue;

    public void Push(int value)
    {
      var se = _s.TryPeek(out var top) ?
        new StackElement(value, Math.Max(value, top.Max)) :
        new StackElement(value, value);
      _s.Push(se);
    }

    public int Pop() => _s.Pop().Value;

    public MaxStack(int capacity) => _s = new Stack<StackElement>(capacity);
  }


  private class MaxQueue
  {
    private readonly MaxStack _front;
    private readonly MaxStack _back;

    public MaxQueue(int capacity)
    {
      _front = new MaxStack(capacity);
      _back = new MaxStack(capacity);
    }

    public int Max => Math.Max(_front.Max, _back.Max);

    public void Enqueue(int value) => _front.Push(value);

    public void Dequeue()
    {
      if (_back.Count == 0)
      {
        while (_front.Count > 0)
          _back.Push(_front.Pop());
      }
      _back.Pop();
    }
  }
}