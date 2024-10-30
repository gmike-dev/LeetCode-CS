namespace LeetCode.DP._1671._Minimum_Number_of_Removals_to_Make_Mountain_Array;

public class BinarySearchSolution
{
  public int MinimumMountainRemovals(int[] nums)
  {
    var n = nums.Length;

    var lisLength = new int[n];
    List<int> lis = [nums[0]];
    for (var i = 0; i < n; i++)
    {
      if (nums[i] > lis[^1])
      {
        lis.Add(nums[i]);
      }
      else
      {
        var j = lis.BinarySearch(nums[i]);
        if (j < 0)
          j = ~j;
        lis[j] = nums[i];
      }
      lisLength[i] = lis.Count;
    }

    var ldsLength = new int[n];
    List<int> lds = [nums[^1]];
    for (var i = n - 1; i >= 0; i--)
    {
      if (nums[i] > lds[^1])
      {
        lds.Add(nums[i]);
      }
      else
      {
        var j = lds.BinarySearch(nums[i]);
        if (j < 0)
          j = ~j;
        lds[j] = nums[i];
      }
      ldsLength[i] = lds.Count;
    }

    var minRemovals = n;
    for (var i = 1; i < n - 1; i++)
    {
      if (lisLength[i] > 1 && ldsLength[i] > 1)
        minRemovals = Math.Min(minRemovals, n - lisLength[i] - ldsLength[i] + 1);
    }
    return minRemovals;
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 1, 3, 1 }, 0)]
  [TestCase(new[] { 2, 1, 1, 5, 6, 2, 3, 1 }, 3)]
  [TestCase(new[] { 100, 92, 89, 77, 74, 66, 64, 66, 64 }, 6)]
  public void Test(int[] nums, int expected)
  {
    new BinarySearchSolution().MinimumMountainRemovals(nums).Should().Be(expected);
  }
}
