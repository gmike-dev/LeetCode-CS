namespace LeetCode._295._Find_Median_from_Data_Stream;

public class MedianFinderQueue
{
  private readonly PriorityQueue<int, int> front = new();
  private readonly PriorityQueue<int, int> back = new();

  public void AddNum(int num)
  {
    if (front.Count == 0 || num <= front.Peek())
      front.Enqueue(num, -num);
    else
      back.Enqueue(num, num);

    if (front.Count - back.Count > 1)
    {
      var val = front.Dequeue();
      back.Enqueue(val, val);
    }
    else if (back.Count - front.Count > 1)
    {
      var val = back.Dequeue();
      front.Enqueue(val, -val);
    }
  }

  public double FindMedian()
  {
    if (front.Count == back.Count)
      return (front.Peek() + back.Peek()) / 2.0;
    return front.Count > back.Count ? front.Peek() : back.Peek();
  }
}

[TestFixture]
public class QueueSolutionTests
{
  [Test]
  public void Test1()
  {
    var medianFinder = new MedianFinderQueue();
    medianFinder.AddNum(1); // arr = [1]
    medianFinder.AddNum(2); // arr = [1, 2]
    medianFinder.FindMedian().Should().Be(1.5); // return 1.5 (i.e., (1 + 2) / 2)
    medianFinder.AddNum(3); // arr[1, 2, 3]
    medianFinder.FindMedian().Should().Be(2.0); // return 2.0
  }
}
