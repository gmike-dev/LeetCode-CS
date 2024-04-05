namespace LeetCode._239._Sliding_Window_Maximum;

public class SolutionUsingDeque
{
  public int[] MaxSlidingWindow(int[] nums, int k)
  {
    var deque = new Deque<int>(k);
    for (var i = 0; i < k; i++)
    {
      while (deque.Count > 0 && nums[i] >= nums[deque.Back])
        deque.PopBack();
      deque.PushBack(i);
    }
    var n = nums.Length;
    var result = new List<int>(n) { nums[deque.Front] };
    for (var i = k; i < n; i++)
    {
      if (deque.Front == i - k)
        deque.PopFront();
      while (deque.Count > 0 && nums[i] >= nums[deque.Back])
        deque.PopBack();
      deque.PushBack(i);
      result.Add(nums[deque.Front]);
    }
    return result.ToArray();
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
