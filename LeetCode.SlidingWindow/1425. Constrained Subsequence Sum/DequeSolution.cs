namespace LeetCode.SlidingWindow._1425._Constrained_Subsequence_Sum;

public class DequeSolution
{
  public int ConstrainedSubsetSum(int[] nums, int k)
  {
    var d = new Deque<int>(k + 1);
    d.PushBack(0);
    var n = nums.Length;
    var dp = new int[n];
    dp[0] = nums[0];
    for (var i = 1; i < n; i++)
    {
      dp[i] = Math.Max(nums[i], dp[d.Front] + nums[i]);
      while (d.Count > 0 && dp[d.Back] <= dp[i])
        d.PopBack();
      d.PushBack(i);
      while (d.Front <= i - k)
        d.PopFront();
    }
    return dp.Max();
  }

  private class Deque<T>
  {
    private readonly int _size;
    private readonly T[] _buffer;
    private int _start;
    private int _count;

    public int Count => _count;
    public T Front => _buffer[_start];
    public T Back => _buffer[Index(_count - 1)];

    public void PushBack(T item) => _buffer[Index(_count++)] = item;

    public void PopFront()
    {
      _start++;
      if (_start == _size)
        _start = 0;
      _count--;
    }

    public void PopBack() => _count--;

    private int Index(int index) => (_start + index) % _size;

    public Deque(int capacity)
    {
      _size = capacity;
      _buffer = new T[_size];
    }
  }
}
