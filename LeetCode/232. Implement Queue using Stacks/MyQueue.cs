using System.Collections.Generic;

namespace LeetCode._232._Implement_Queue_using_Stacks;

public class MyQueue
{
  private readonly Stack<int> head = new();
  private readonly Stack<int> tail = new();

  public void Push(int x) => tail.Push(x);

  public int Pop()
  {
    if (head.Count == 0)
    {
      while (tail.Count > 0)
        head.Push(tail.Pop());
    }
    return head.Pop();
  }

  public int Peek()
  {
    if (head.Count == 0)
    {
      while (tail.Count > 0)
        head.Push(tail.Pop());
    }
    return head.Peek();
  }

  public bool Empty() => head.Count == 0 && tail.Count == 0;
}