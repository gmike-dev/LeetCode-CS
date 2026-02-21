namespace LeetCode.___Binary_Search._1482._Minimum_Number_of_Days_to_Make_m_Bouquets;

/// <summary>
/// <see href="https://leetcode.com/problems/minimum-number-of-days-to-make-m-bouquets/"/>
/// </summary>
public class Solution
{
  public int MinDays(int[] bloomDay, int m, int k)
  {
    var n = bloomDay.Length;
    var l = 0;
    var r = bloomDay.Max();
    var ans = -1;
    while (l <= r)
    {
      var mid = l + (r - l) / 2;
      if (CheckCanMakeBouquets(mid))
      {
        ans = mid;
        r = mid - 1;
      }
      else
      {
        l = mid + 1;
      }
    }
    return ans;

    bool CheckCanMakeBouquets(int maxBloomDay)
    {
      var count = 0;
      var bouquets = 0;
      for (var i = 0; i < n; i++)
      {
        if (bloomDay[i] <= maxBloomDay)
        {
          count++;
          if (count == k)
          {
            bouquets++;
            if (bouquets == m)
              return true;
            count = 0;
          }
        }
        else
        {
          count = 0;
        }
      }
      return false;
    }
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 10, 3, 10, 2 }, 3, 1, 3)]
  [TestCase(new[] { 1, 10, 3, 10, 2 }, 3, 2, -1)]
  [TestCase(new[] { 7, 7, 7, 7, 12, 7, 7 }, 2, 3, 12)]
  [TestCase(new[] { 62, 75, 98, 63, 47, 65, 51, 87, 22, 27, 73, 92, 76, 44, 13, 90, 100, 85 }, 2, 7, 98)]
  [TestCase(new[]
  {
    7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
    7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
    7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7,
    7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7
  }, 10, 1, 7)]
  public void Test(int[] bloomDay, int m, int k, int expected)
  {
    new Solution().MinDays(bloomDay, m, k).Should().Be(expected);
  }
}
