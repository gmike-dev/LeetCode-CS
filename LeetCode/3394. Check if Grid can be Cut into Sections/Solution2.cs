namespace LeetCode._3394._Check_if_Grid_can_be_Cut_into_Sections;

public class Solution2
{
  public bool CheckValidCuts(int n, int[][] rectangles)
  {
    var m = rectangles.Length;
    Span<(int start, int end)> x = stackalloc (int, int)[m];
    Span<(int start, int end)> y = stackalloc (int, int)[m];
    for (var i = 0; i < rectangles.Length; i++)
    {
      var r = rectangles[i];
      x[i] = (r[0], r[2]);
      y[i] = (r[1], r[3]);
    }
    return Check(x) || Check(y);

    bool Check(Span<(int start, int end)> points)
    {
      points.Sort();
      var lines = 0;
      var prev = 0;
      for (var i = 0; i < points.Length; i++)
      {
        if (prev <= points[i].start)
          lines++;
        prev = Math.Max(prev, points[i].end);
      }
      return lines > 2;
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().CheckValidCuts(5, [
      [1, 0, 5, 2],
      [0, 2, 2, 4],
      [3, 2, 5, 3],
      [0, 4, 4, 5]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution2().CheckValidCuts(4, [
      [0, 0, 1, 1],
      [2, 0, 3, 4],
      [0, 2, 2, 3],
      [3, 0, 4, 3]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test3()
  {
    new Solution2().CheckValidCuts(4, [
        [0, 2, 2, 4],
        [1, 0, 3, 2],
        [2, 2, 3, 4],
        [3, 0, 4, 2],
        [3, 2, 4, 4]
      ]).Should()
      .BeFalse();
  }
}
