namespace LeetCode.Strings._2375._Construct_Smallest_Number_From_DI_String;

public class Solution
{
  public string SmallestNumber(string pattern)
  {
    var n = pattern.Length;
    var nums = new int[n + 1];
    var used = new bool[10];
    for (var i = 1; i <= 9; i++)
    {
      nums[0] = i;
      used[i] = true;
      if (F(0))
        return BuildResult();
      used[i] = false;
    }

    return "";

    bool F(int pos)
    {
      if (pos >= n)
        return true;
      var (from, to) = pattern[pos] == 'I' ? (nums[pos] + 1, 9) : (1, nums[pos] - 1);
      for (var i = from; i <= to; i++)
      {
        if (used[i])
          continue;
        nums[pos + 1] = i;
        used[i] = true;
        if (F(pos + 1))
          return true;
        used[i] = false;
      }
      return false;
    }

    string BuildResult()
    {
      Span<char> result = stackalloc char[n + 1];
      for (var j = 0; j < n + 1; j++)
        result[j] = (char)('0' + nums[j]);
      return new string(result);
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("IIIDIDDD", "123549876")]
  [TestCase("DDD", "4321")]
  public void Test(string pattern, string expected)
  {
    new Solution().SmallestNumber(pattern).Should().Be(expected);
  }
}
