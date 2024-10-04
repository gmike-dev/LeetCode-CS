namespace LeetCode._2491._Divide_Players_Into_Teams_of_Equal_Skill;

public class Solution
{
  public long DividePlayers(int[] skill)
  {
    skill.AsSpan().Sort();
    var s = skill[0] + skill[^1];
    long p = 0;
    for (int l = 0, r = skill.Length - 1; l < r; l++, r--)
    {
      if (skill[l] + skill[r] != s)
        return -1;
      p += (long)skill[l] * skill[r];
    }
    return p;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(new[] { 3, 2, 5, 1, 3, 4 }, 22)]
  [TestCase(new[] { 3, 4 }, 12)]
  [TestCase(new[] { 1, 1, 2, 3 }, -1)]
  public void Test(int[] skill, long result)
  {
    new Solution().DividePlayers(skill).Should().Be(result);
  }
}
