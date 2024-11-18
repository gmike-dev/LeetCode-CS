namespace LeetCode._1574._Shortest_Subarray_to_be_Removed_to_Make_Array_Sorted;

public class BinarySearchSolution
{
  public int FindLengthOfShortestSubarray(int[] a)
  {
    var n = a.Length;
    var sortedPrefix = new bool[n + 1];
    var sortedSuffix = new bool[n + 1];
    sortedPrefix[0] = sortedPrefix[1] = true;
    sortedSuffix[^1] = sortedSuffix[^2] = true;
    for (var i = 1; i < n && a[i - 1] <= a[i]; i++)
      sortedPrefix[i + 1] = true;
    for (var i = n - 2; i >= 0 && a[i] <= a[i + 1]; i--)
      sortedSuffix[i] = true;

    var l = 0;
    var r = n - 1;
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (CheckCanRemove(m))
        r = m;
      else
        l = m + 1;
    }
    return r;

    bool CheckCanRemove(int length)
    {
      for (var i = 0; i <= n - length; i++)
      {
        if (sortedPrefix[i] && sortedSuffix[i + length] &&
            (i == 0 || i + length == n || a[i - 1] <= a[i + length]))
          return true;
      }
      return false;
    }
  }
}

[TestFixture]
public class BinarySearchSolutionTests
{
  [TestCase(new[] { 1, 2, 3, 10, 4, 2, 3, 5 }, 3)]
  [TestCase(new[] { 5, 4, 3, 2, 1 }, 4)]
  [TestCase(new[] { 1, 2, 3 }, 0)]
  [TestCase(new[] { 2, 2, 2, 1, 1, 1 }, 3)]
  [TestCase(new[] { 10, 13, 17, 21, 15, 15, 9, 17, 22, 22, 13 }, 7)]
  public void Test(int[] a, int expected)
  {
    new BinarySearchSolution().FindLengthOfShortestSubarray(a).Should().Be(expected);
  }
}
