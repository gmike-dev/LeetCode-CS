namespace LeetCode._3394._Check_if_Grid_can_be_Cut_into_Sections;

public class Solution
{
  public bool CheckValidCuts(int n, int[][] rectangles)
  {
    var xPoints = new List<(int, int)>();
    var yPoints = new List<(int, int)>();
    foreach (var r in rectangles)
    {
      var (x1, y1, x2, y2) = (r[0], r[1], r[2], r[3]);
      xPoints.Add((x1, 1));
      xPoints.Add((x2, -1));
      yPoints.Add((y1, 1));
      yPoints.Add((y2, -1));
    }
    xPoints.Sort();
    yPoints.Sort();
    return Check(xPoints) || Check(yPoints);

    bool Check(List<(int, int)> points)
    {
      var count = 0;
      var groups = 0;
      foreach (var (_, start) in points)
      {
        count += start;
        if (count == 0)
          groups++;
      }
      return groups > 2;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().CheckValidCuts(5, [
      [1, 0, 5, 2],
      [0, 2, 2, 4],
      [3, 2, 5, 3],
      [0, 4, 4, 5]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test2()
  {
    new Solution().CheckValidCuts(4, [
      [0, 0, 1, 1],
      [2, 0, 3, 4],
      [0, 2, 2, 3],
      [3, 0, 4, 3]
    ]).Should().BeTrue();
  }

  [Test]
  public void Test3()
  {
    new Solution().CheckValidCuts(4, [
        [0, 2, 2, 4],
        [1, 0, 3, 2],
        [2, 2, 3, 4],
        [3, 0, 4, 2],
        [3, 2, 4, 4]
      ]).Should()
      .BeFalse();
  }
}
