namespace LeetCode._939._Minimum_Area_Rectangle;

public class Solution
{
  public int MinAreaRect(int[][] points)
  {
    var pointsByX = new Dictionary<int, HashSet<int>>();
    foreach (var p in points)
    {
      if (pointsByX.TryGetValue(p[0], out var list))
        list.Add(p[1]);
      else
        pointsByX.Add(p[0], [p[1]]);
    }
    var pointsList = pointsByX.ToList();
    var s = int.MaxValue;
    for (var i = 0; i < pointsList.Count; i++)
    {
      var x1 = pointsList[i].Key;
      for (var j = 0; j < pointsList.Count; j++)
      {
        if (i == j)
          continue;
        var x2 = pointsList[j].Key;
        foreach (var y1 in pointsList[i].Value)
        {
          if (pointsList[j].Value.Contains(y1))
          {
            foreach (var y2 in pointsList[i].Value)
            {
              if (y1 == y2)
                continue;
              if (pointsList[j].Value.Contains(y2))
                s = Math.Min(s, Math.Abs((x1 - x2) * (y1 - y2)));
            }
          }
        }
      }
    }
    return s == int.MaxValue ? 0 : s;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MinAreaRect([[1, 1], [1, 3], [3, 1], [3, 3], [2, 2]]).Should().Be(4);
  }

  [Test]
  public void Test2()
  {
    new Solution().MinAreaRect([[1, 1], [1, 3], [3, 1], [3, 3], [4, 1], [4, 3]]).Should().Be(2);
  }
}
