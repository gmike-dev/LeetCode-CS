namespace LeetCode._452._Minimum_Number_of_Arrows_to_Burst_Balloons;

public class Solution
{
  public int FindMinArrowShots(int[][] points)
  {
    var a = points.OrderBy(p => p[1]).ToArray();
    var j = a[0][1];
    var arrows = 1;
    for (var i = 1; i < points.Length; i++)
    {
      if (a[i][0] <= j)
        continue;
      j = a[i][1];
      arrows++;
    }
    return arrows;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { 10, 16 }, new[] { 2, 8 }, new[] { 1, 6 }, new[] { 7, 12 } })
      .Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 6 }, new[] { 7, 8 } })
      .Should().Be(4);
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { 1, 2 }, new[] { 2, 3 }, new[] { 3, 4 }, new[] { 4, 5 } })
      .Should().Be(2);
  }

  [Test]
  public void Test4()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { 1, 1 } })
      .Should().Be(1);
  }

  [Test]
  public void Test5()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { 1, 5 }, new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5, 5 } })
      .Should().Be(3);
  }

  [Test]
  public void Test49()
  {
    new Solution()
      .FindMinArrowShots(new[] { new[] { -2147483646, -2147483645 }, new[] { 2147483646, 2147483647 } })
      .Should().Be(2);
  }
}
