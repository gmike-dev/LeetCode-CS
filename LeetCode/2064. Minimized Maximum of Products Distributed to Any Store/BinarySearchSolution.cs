namespace LeetCode._2064._Minimized_Maximum_of_Products_Distributed_to_Any_Store;

public class BinarySearchSolution
{
  public int MinimizedMaximum(int n, int[] quantities)
  {
    var l = 1;
    var r = quantities.Max();
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (CanDistribute(m))
        r = m;
      else
        l = m + 1;
    }
    return r;

    bool CanDistribute(int maxPortion)
    {
      var i = 0;
      foreach (var q in quantities)
      {
        i += (q + maxPortion - 1) / maxPortion;
        if (i > n)
          return false;
      }
      return true;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(6, new[] { 11, 6 }, 3)]
  [TestCase(7, new[] { 15, 10, 10 }, 5)]
  [TestCase(1, new[] { 100000 }, 100000)]
  [TestCase(2, new[] { 5, 7 }, 7)]
  public void Test(int n, int[] quantities, int expected)
  {
    new BinarySearchSolution().MinimizedMaximum(n, quantities).Should().Be(expected);
  }
}
