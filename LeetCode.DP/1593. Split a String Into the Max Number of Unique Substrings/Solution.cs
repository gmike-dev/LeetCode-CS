namespace LeetCode.DP._1593._Split_a_String_Into_the_Max_Number_of_Unique_Substrings;

public class Solution
{
  public int MaxUniqueSplit(string s)
  {
    var set = new HashSet<string>();
    return F(0);

    int F(int pos)
    {
      if (pos >= s.Length)
        return set.Count;
      var count = 0;
      for (var i = pos; i < s.Length; i++)
      {
        var val = s.Substring(pos, i - pos + 1);
        if (set.Add(val))
        {
          count = Math.Max(count, F(i + 1));
          set.Remove(val);
        }
      }
      return count;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("ababccc", 5)]
  [TestCase("aba", 2)]
  [TestCase("aa", 1)]
  [TestCase("a", 1)]
  public void Test(string s, int expected)
  {
    new Solution().MaxUniqueSplit(s).Should().Be(expected);
  }
}
