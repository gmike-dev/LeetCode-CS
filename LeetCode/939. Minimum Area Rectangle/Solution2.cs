namespace LeetCode._939._Minimum_Area_Rectangle;

public class Solution2
{
  public int MinAreaRect(int[][] points)
  {
    var minArea = int.MaxValue;
    HashSet<(int, int)> used = [];
    foreach (var p in points)
    {
      var (x1, y1) = (p[0], p[1]);
      foreach (var (x2, y2) in used)
      {
        if (used.Contains((x1, y2)) && used.Contains((x2, y1)))
        {
          var s = Math.Abs((x1 - x2) * (y1 - y2));
          if (s != 0 && s < minArea)
            minArea = s;
        }
      }
      used.Add((x1, y1));
    }
    return minArea == int.MaxValue ? 0 : minArea;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().MinAreaRect([[1, 1], [1, 3], [3, 1], [3, 3], [2, 2]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution2().MinAreaRect([[1, 1], [1, 3], [3, 1], [3, 3], [4, 1], [4, 3]]).Should().Be(2);
  }
}
