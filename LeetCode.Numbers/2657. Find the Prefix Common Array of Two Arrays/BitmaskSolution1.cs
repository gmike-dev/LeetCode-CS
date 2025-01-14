namespace LeetCode.Numbers._2657._Find_the_Prefix_Common_Array_of_Two_Arrays;

public class BitmaskSolution1
{
  public int[] FindThePrefixCommonArray(int[] a, int[] b)
  {
    var n = a.Length;
    long x = 0;
    long y = 0;
    var result = new int[n];
    var count = 0;
    for (var i = 0; i < n; i++)
    {
      var ai = 1L << a[i];
      var bi = 1L << b[i];
      if (a[i] == b[i])
      {
        count++;
      }
      else
      {
        if ((x & bi) != 0)
          count++;
        if ((y & ai) != 0)
          count++;
      }
      x |= ai;
      y |= bi;
      result[i] = count;
    }
    return result;
  }
}

[TestFixture]
public class BitmaskSolution1Tests
{
  [TestCase(new[] { 1, 3, 2, 4 }, new[] { 3, 1, 2, 4 }, new[] { 0, 2, 3, 4 })]
  [TestCase(new[] { 2, 3, 1 }, new[] { 3, 1, 2 }, new[] { 0, 1, 3 })]
  [TestCase(
    new[]
    {
      20, 2, 14, 19, 31, 9, 30, 13, 17, 33, 10, 3, 26, 28, 5, 8, 6, 29, 22, 21, 23, 4, 1, 27, 24, 11, 12, 18, 7, 25, 32,
      16, 15
    },
    new[]
    {
      7, 1, 3, 5, 11, 2, 16, 26, 4, 13, 22, 23, 31, 9, 18, 19, 17, 8, 32, 12, 24, 25, 20, 28, 6, 33, 14, 30, 15, 21, 10,
      29, 27
    },
    new[]
    {
      0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2, 3, 5, 6, 7, 8, 9, 10, 11, 11, 12, 13, 15, 16, 18, 20, 22, 24, 25, 27, 29, 31, 33
    })]
  public void Test(int[] a, int[] b, int[] expected)
  {
    new BitmaskSolution1().FindThePrefixCommonArray(a, b).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
