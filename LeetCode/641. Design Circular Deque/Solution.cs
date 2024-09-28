namespace LeetCode._641._Design_Circular_Deque;

public class MyCircularDeque
{
  private readonly int n;
  private readonly int[] deque;
  private int size;
  private int first;
  private int last;

  public MyCircularDeque(int k)
  {
    n = k;
    deque = new int[k];
    size = 0;
    first = 0;
    last = n - 1;
  }

  public bool InsertFront(int value)
  {
    if (IsFull())
      return false;
    first = (n + first - 1) % n;
    deque[first] = value;
    size++;
    return true;
  }

  public bool InsertLast(int value)
  {
    if (IsFull())
      return false;
    last = (last + 1) % n;
    deque[last] = value;
    size++;
    return true;
  }

  public bool DeleteFront()
  {
    if (IsEmpty())
      return false;
    first = (first + 1) % n;
    size--;
    return true;
  }

  public bool DeleteLast()
  {
    if (IsEmpty())
      return false;
    last = (n + last - 1) % n;
    size--;
    return true;
  }

  public int GetFront() => IsEmpty() ? -1 : deque[first];

  public int GetRear() => IsEmpty() ? -1 : deque[last];

  public bool IsEmpty() => size == 0;

  public bool IsFull() => size == n;
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var myCircularDeque = new MyCircularDeque(3);
    myCircularDeque.InsertLast(1).Should().BeTrue();  // return True
    myCircularDeque.InsertLast(2).Should().BeTrue();  // return True
    myCircularDeque.InsertFront(3).Should().BeTrue(); // return True
    myCircularDeque.InsertFront(4).Should().BeFalse(); // return False, the queue is full.
    myCircularDeque.GetRear().Should().Be(2);      // return 2
    myCircularDeque.IsFull().Should().BeTrue();       // return True
    myCircularDeque.DeleteLast().Should().BeTrue();   // return True
    myCircularDeque.InsertFront(4).Should().BeTrue(); // return True
    myCircularDeque.GetFront().Should().Be(4);     // return 4
  }

  [Test]
  public void Test2()
  {
    var myCircularDeque = new MyCircularDeque(5);
    myCircularDeque.InsertFront(7).Should().BeTrue();
    myCircularDeque.InsertLast(0).Should().BeTrue();
    myCircularDeque.GetFront().Should().Be(7);
    myCircularDeque.InsertLast(3).Should().BeTrue();
    myCircularDeque.GetFront().Should().Be(7);
    myCircularDeque.InsertFront(9).Should().BeTrue();
    myCircularDeque.GetRear().Should().Be(3);
    myCircularDeque.GetFront().Should().Be(9);
    myCircularDeque.GetFront().Should().Be(9);
    myCircularDeque.DeleteLast().Should().BeTrue();
    myCircularDeque.GetRear().Should().Be(0);
  }
}
