namespace LeetCode.___Binary_Search._2226._Maximum_Candies_Allocated_to_K_Children;

public class BinarySearchSolution2
{
  public int MaximumCandies(int[] candies, long k)
  {
    var maxCandies = 0;
    foreach (var candy in candies)
      maxCandies = Math.Max(maxCandies, candy);
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

    bool CanAllocate(int count)
    {
      long sum = 0;
      foreach (var c in candies)
      {
        sum += c / count;
        if (sum >= k)
          return true;
      }
      return false;
    }
  }
}

[TestFixture]
public class BinarySearchSolution2Tests
{
  [TestCase(new[] { 5, 8, 6 }, 3, 5)]
  [TestCase(new[] { 2, 5 }, 11, 0)]
  [TestCase(new[] { 1, 2, 3, 4, 10 }, 5, 3)]
  public void Test(int[] candies, long k, int expected)
  {
    new BinarySearchSolution2().MaximumCandies(candies, k).Should().Be(expected);
  }
}
