namespace LeetCode.___Binary_Search._1552._Magnetic_Force_Between_Two_Balls;

/// <summary>
/// <see href="https://leetcode.com/problems/magnetic-force-between-two-balls/"/>
/// </summary>
public class Solution2
{
  public int MaxDistance(int[] position, int m)
  {
    Array.Sort(position);
    var l = 1;
    var r = position[^1] - position[0];
    var ans = 0;
    while (l <= r)
    {
      var mid = l + (r - l) / 2;
      if (CanPlace(mid))
      {
        ans = mid;
        l = mid + 1;
      }
      else
      {
        r = mid - 1;
      }
    }
    return ans;

    bool CanPlace(int dist)
    {
      var balls = m - 1;
      for (var i = 0; i < position.Length;)
      {
        var l = i + 1;
        var r = position.Length - 1;
        while (l < r)
        {
          var mid = l + (r - l) / 2;
          if (position[mid] - position[i] < dist)
            l = mid + 1;
          else
            r = mid;
        }
        if (position[r] - position[i] < dist)
          return false;
        balls--;
        if (balls == 0)
          return true;
        i = r;
      }
      return false;
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 7 }, 3, 3)]
  [TestCase(new[] { 5, 4, 3, 2, 1, 1000000000 }, 2, 999999999)]
  public void Test(int[] position, int m, int expected)
  {
    new Solution2().MaxDistance(position, m).Should().Be(expected);
  }
}
