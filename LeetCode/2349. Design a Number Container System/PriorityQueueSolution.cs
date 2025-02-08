namespace LeetCode._2349._Design_a_Number_Container_System;

public class NumberContainersPriorityQueue
{
  private readonly Dictionary<int, int> numberAtIndex = new();
  private readonly Dictionary<int, PriorityQueue<int, int>> numIndexes = new();

  public void Change(int index, int number)
  {
    numberAtIndex[index] = number;
    if (!numIndexes.TryGetValue(number, out var q))
    {
      q = new PriorityQueue<int, int>();
      numIndexes[number] = q;
    }
    q.Enqueue(index, index);
  }

  public int Find(int number)
  {
    if (!numIndexes.TryGetValue(number, out var q))
      return -1;
    while (q.Count > 0 && numberAtIndex[q.Peek()] != number)
      q.Dequeue();
    return q.Count > 0 ? q.Peek() : -1;
  }
}

[TestFixture]
public class NumberContainersPriorityQueueTests
{
  [Test]
  public void Test1()
  {
    var nc = new NumberContainersPriorityQueue();
    nc.Find(10).Should().Be(-1);
    nc.Change(2, 10);
    nc.Change(1, 10);
    nc.Change(3, 10);
    nc.Change(5, 10);
    nc.Find(10).Should().Be(1);
    nc.Change(1, 20);
    nc.Find(10).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    var nc = new NumberContainersPriorityQueue();
    nc.Change(1, 10);
    nc.Find(10).Should().Be(1);
    nc.Change(1, 20);
    nc.Find(10).Should().Be(-1);
    nc.Find(20).Should().Be(1);
    nc.Find(30).Should().Be(-1);
  }
}
