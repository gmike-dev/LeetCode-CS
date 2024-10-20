namespace LeetCode.DP._552._Student_Attendance_Record_II;

public class Solution
{
  public int CheckRecord(int n)
  {
    const int mod = (int)1e9 + 7;

    var curr = new int[2, 3];
    var prev = new int[2, 3];
    for (var absent = 0; absent < 2; absent++)
    for (var late = 0; late < 3; late++)
      prev[absent, late] = 1;

    for (var i = 1; i <= n; i++)
    {
      for (var absent = 0; absent < 2; absent++)
      {
        for (var late = 0; late < 3; late++)
        {
          var count = prev[absent, 2];
          if (absent > 0)
            count = (count + prev[absent - 1, 2]) % mod;
          if (late > 0)
            count = (count + prev[absent, late - 1]) % mod;
          curr[absent, late] = count;
        }
      }
      (curr, prev) = (prev, curr);
    }
    return prev[1, 2];
  }
}

[TestFixture]
public class Tests
{
  [TestCase(2, 8)]
  [TestCase(1, 3)]
  [TestCase(10101, 183236316)]
  public void Test(int n, int expected)
  {
    new Solution().CheckRecord(n).Should().Be(expected);
  }
}
