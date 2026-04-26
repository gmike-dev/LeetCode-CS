using System.IO;
using LeetCode.Common;

namespace LeetCode.___Binary_Search._3464._Maximize_the_Distance_Between_Points_on_a_Square;

public class Solution
{
  public int MaxDistance(int side, int[][] points, int k)
  {
    int n = points.Length;
    List<long> offsets = new(2 * n);
    for (int i = 0; i < n; i++)
    {
      offsets.Add(GetOffset(points[i], side));
    }
    offsets.Sort();
    for (int i = 0; i < n; i++)
    {
      offsets.Add(4 * (long)side + offsets[i]);
    }
    int l = 0;
    int r = side;
    while (l <= r)
    {
      int m = l + (r - l) / 2;
      if (CheckCanSelect(m))
      {
        l = m + 1;
      }
      else
      {
        r = m - 1;
      }
    }
    return r;

    bool CheckCanSelect(int minDist)
    {
      for (int start = 0; start < n; start++)
      {
        if (CheckCanSelectFrom(start, minDist))
        {
          return true;
        }
        if (offsets[start] - offsets[0] >= minDist)
        {
          break;
        }
      }
      return false;
    }

    bool CheckCanSelectFrom(int start, int minDist)
    {
      int i = start;
      for (int kk = k; kk > 0; kk--)
      {
        int j = LowerBound(offsets, i + 1, offsets.Count, offsets[i] + minDist);
        if (j == 2 * n || j - start > n)
        {
          return false;
        }
        i = j;
      }
      return true;
    }
  }

  private static long GetOffset(int[] a, int side)
  {
    if (a[0] == 0)
    {
      return a[1];
    }
    if (a[1] == side)
    {
      return (long)side + a[0];
    }
    if (a[0] == side)
    {
      return 3 * (long)side - a[1];
    }
    return 4 * (long)side - a[0];
  }

  private static int LowerBound(List<long> a, int beginIndex, int endIndex, long value)
  {
    if (beginIndex >= endIndex)
      return endIndex;
    int l = beginIndex;
    int r = endIndex - 1;
    while (l < r)
    {
      int m = l + (r - l) / 2;
      if (a[m] < value)
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? endIndex : l;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(2, "[[0,2],[2,0],[2,2],[0,0]]", 4, 2)]
  [TestCase(2, "[[0,0],[1,2],[2,0],[2,2],[2,1]]", 4, 1)]
  [TestCase(2, "[[0,0],[0,1],[0,2],[1,2],[2,0],[2,2],[2,1]]", 5, 1)]
  [TestCase(6, "[[2,0],[5,0],[0,0],[2,6]]", 4, 2)]
  [TestCase(38, "[[13,38],[37,0],[33,0],[0,37],[0,15],[38,18],[0,33]]", 4, 23)]
  [TestCase(37687,
    "[[14519,0],[13105,0],[37687,20696],[26583,0],[321,0],[32872,0],[0,375],[24248,0]," +
    "[37687,10805],[0,32996],[31051,37687],[493,0],[0,34155],[33812,0],[4936,37687],[18767,0]," +
    "[28627,0],[6989,37687],[0,10812],[37687,23663]]",
    4, 33864)]
  public void Test(int side, string points, int k, int expected)
  {
    new Solution().MaxDistance(side, points.Array2(), k).Should().Be(expected);
  }

  public static IEnumerable<object> GetTestCases()
  {
    string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
      "## Binary Search", "3464. Maximize the Distance Between Points on a Square", "TestCases.txt");
    using var sr = new StreamReader(source);
    while (!sr.EndOfStream)
    {
      int side = int.Parse(sr.ReadLine() ?? throw new InvalidOperationException());
      string points = sr.ReadLine() ?? throw new InvalidOperationException();
      int k = int.Parse(sr.ReadLine() ?? throw new InvalidOperationException());
      int expected = int.Parse(sr.ReadLine() ?? throw new InvalidOperationException());
      yield return new object[] { side, points, k, expected };
    }
  }

  [TestCaseSource(nameof(GetTestCases))]
  public void TestLargeInput(int side, string points, int k, int expected)
  {
    new Solution().MaxDistance(side, points.Array2(), k).Should().Be(expected);
  }
}
