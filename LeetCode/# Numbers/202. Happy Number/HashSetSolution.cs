namespace LeetCode.__Numbers._202._Happy_Number;

public class HashSetSolution
{
  public bool IsHappy(int n)
  {
    var numbers = new HashSet<int>();
    while (n != 1)
    {
      var m = n;
      n = 0;
      while (m != 0)
      {
        var d = m % 10;
        n += d * d;
        m /= 10;
      }
      if (!numbers.Add(n))
        return false;
    }
    return true;
  }
}

[TestFixture]
public class HashSetSolutionTests
{
  [TestCase(19, true)]
  [TestCase(2, false)]
  [TestCase(21, false)]
  [TestCase(5, false)]
  [TestCase(37, false)]
  public void Test(int n, bool expected)
  {
    new HashSetSolution().IsHappy(n).Should().Be(expected);
  }
}
