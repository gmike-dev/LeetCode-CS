namespace LeetCode.___Binary_Search._1552._Magnetic_Force_Between_Two_Balls;

public class Solution
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
      var prevPos = position[0];
      var balls = m - 1;
      for (var i = 1; i < position.Length; i++)
      {
        if (position[i] - prevPos >= dist)
        {
          balls--;
          if (balls == 0)
            return true;
          prevPos = position[i];
        }
      }
      return false;
    }
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 2, 3, 4, 7 }, 3, 3)]
  [TestCase(new[] { 5, 4, 3, 2, 1, 1000000000 }, 2, 999999999)]
  public void Test(int[] position, int m, int expected)
  {
    new Solution().MaxDistance(position, m).Should().Be(expected);
  }
}
