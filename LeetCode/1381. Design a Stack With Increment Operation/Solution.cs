namespace LeetCode._1381._Design_a_Stack_With_Increment_Operation;

public class CustomStack(int maxSize)
{
  private readonly int[] s = new int[maxSize];
  private readonly int[] inc = new int[maxSize];
  private int size;

  public void Push(int x)
  {
    if (size < maxSize)
    {
      s[size] = x;
      inc[size] = 0;
      size++;
    }
  }

  public int Pop()
  {
    if (size == 0)
      return -1;
    size--;
    if (size > 0)
      inc[size - 1] += inc[size];
    return s[size] + inc[size];
  }

  public void Increment(int k, int val)
  {
    if (size > 0)
      inc[Math.Min(size - 1, k - 1)] += val;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var stk = new CustomStack(3); // Stack is Empty []
    stk.Push(1); // stack becomes [1]
    stk.Push(2); // stack becomes [1, 2]
    stk.Pop().Should().Be(2); // return 2 --> Return top of the stack 2, stack becomes [1]
    stk.Push(2); // stack becomes [1, 2]
    stk.Push(3); // stack becomes [1, 2, 3]
    stk.Push(4); // stack still [1, 2, 3], Do not add another elements as size is 4
    stk.Increment(5, 100); // stack becomes [101, 102, 103]
    stk.Increment(2, 100); // stack becomes [201, 202, 103]
    stk.Pop().Should().Be(103); // return 103 --> Return top of the stack 103, stack becomes [201, 202]
    stk.Pop().Should().Be(202); // return 202 --> Return top of the stack 202, stack becomes [201]
    stk.Pop().Should().Be(201); // return 201 --> Return top of the stack 201, stack becomes []
    stk.Pop().Should().Be(-1); // return -1 --> Stack is empty return -1.
  }

  [Test]
  public void Test2()
  {
    var stk = new CustomStack(3);
    stk.Increment(10, 10);
    stk.Increment(10, 1);
    stk.Increment(10, 0);
    stk.Pop().Should().Be(-1);
  }
}
