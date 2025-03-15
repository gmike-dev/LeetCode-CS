namespace LeetCode.___Binary_Search._2226._Maximum_Candies_Allocated_to_K_Children;

public class BinarySearchSolution
{
  public int MaximumCandies(int[] candies, long k)
  {
    var maxCandies = candies.Max();
    var l = 1;
    var r = maxCandies;
    while (l <= r)
    {
      var m = l + (r - l) / 2;
      if (CanAllocate(m))
        l = m + 1;
      else
        r = m - 1;
    }
    return r;

    bool CanAllocate(int count) =>
      candies.Sum(c => (long)c / count) >= k;
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 5, 8, 6 }, 3, 5)]
  [TestCase(new[] { 2, 5 }, 11, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 10 }, 5, 3)]
  public void Test(int[] candies, long k, int expected)
  {
    new BinarySearchSolution().MaximumCandies(candies, k).Should().Be(expected);
  }
}
