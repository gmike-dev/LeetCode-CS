namespace LeetCode.SlidingWindow._2762._Continuous_Subarrays;

public class MinMaxQueueSolution
{
  public long ContinuousSubarrays(int[] nums)
  {
    var q = new MinMaxQueue(nums.Length);
    long count = nums.Length;
    for (int l = 0, r = 0; r < nums.Length; r++)
    {
      q.Enqueue(nums[r]);
      while (q.Max - q.Min > 2)
      {
        q.Dequeue();
        l++;
      }
      count += r - l;
    }
    return count;
  }

  private class MinMaxStack(int capacity)
  {
    private readonly record struct StackElement(int Value, int Min, int Max);

    private readonly Stack<StackElement> s = new(capacity);

    public int Count => s.Count;

    public int Min => s.TryPeek(out var top) ? top.Min : int.MaxValue;

    public int Max => s.TryPeek(out var top) ? top.Max : int.MinValue;

    public void Push(int value)
    {
      var item = s.TryPeek(out var top) ?
        new StackElement(value, Math.Min(value, top.Min), Math.Max(value, top.Max)) :
        new StackElement(value, value, value);
      s.Push(item);
    }

    public int Pop() => s.Pop().Value;
  }


  private class MinMaxQueue(int capacity)
  {
    private readonly MinMaxStack front = new(capacity);
    private readonly MinMaxStack back = new(capacity);

    public int Min => Math.Min(front.Min, back.Min);

    public int Max => Math.Max(front.Max, back.Max);

    public void Enqueue(int value) => front.Push(value);

    public void Dequeue()
    {
      if (back.Count == 0)
      {
        while (front.Count > 0)
          back.Push(front.Pop());
      }
      back.Pop();
    }
  }
}

[TestFixture]
public class MinMaxQueueSolutionTests
{
  [TestCase(new[] { 5, 4, 2, 4 }, 8)]
  [TestCase(new[] { 1, 2, 3 }, 6)]
  public void Test(int[] nums, long expected)
  {
    new MinMaxQueueSolution().ContinuousSubarrays(nums).Should().Be(expected);
  }
}
