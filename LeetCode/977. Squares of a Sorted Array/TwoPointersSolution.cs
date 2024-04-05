namespace LeetCode._977._Squares_of_a_Sorted_Array;

public class TwoPointersSolution
{
  public int[] SortedSquares(int[] a)
  {
    var n = a.Length;
    var l = 0;
    var r = n - 1;
    var result = new int[n];
    var i = n - 1;
    while (l <= r)
    {
      var next = Math.Abs(a[l]) >= Math.Abs(a[r]) ? a[l++] : a[r--];
      result[i--] = next * next;
    }
    return result;
  }
}

[TestFixture]
public class TwoPointersSolutionTests
{
  [TestCase(new[] { -4, 4 }, new[] { 16, 16 })]
  [TestCase(new[] { 0 }, new[] { 0 })]
  [TestCase(new[] { 0, 0 }, new[] { 0, 0 })]
  [TestCase(new[] { -4, -1, 0, 3, 10 }, new[] { 0, 1, 9, 16, 100 })]
  [TestCase(new[] { -7, -3, 2, 3, 11 }, new[] { 4, 9, 9, 49, 121 })]
  public void Test(int[] nums, int[] expected)
  {
    new TwoPointersSolution().SortedSquares(nums)
      .Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
