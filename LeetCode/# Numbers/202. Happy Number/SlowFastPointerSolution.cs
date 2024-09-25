namespace LeetCode.__Numbers._202._Happy_Number;

public class SlowFastPointerSolution
{
  public bool IsHappy(int n)
  {
    var slow = NextNumber(n);
    var fast = NextNumber(slow);
    while (slow != fast)
    {
      slow = NextNumber(slow);
      fast = NextNumber(NextNumber(fast));
    }
    return slow == 1;
  }

  private static int NextNumber(int n)
  {
    var next = 0;
    while (n != 0)
    {
      var d = n % 10;
      next += d * d;
      n /= 10;
    }
    return next;
  }
}

[TestFixture]
public class SlowFastPointerSolutionTests
{
  [TestCase(19, true)]
  [TestCase(2, false)]
  [TestCase(21, false)]
  [TestCase(5, false)]
  [TestCase(37, false)]
  public void Test(int n, bool expected)
  {
    new SlowFastPointerSolution().IsHappy(n).Should().Be(expected);
  }
}
