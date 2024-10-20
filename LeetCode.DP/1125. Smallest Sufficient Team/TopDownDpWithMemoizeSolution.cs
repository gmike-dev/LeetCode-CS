namespace LeetCode.DP._1125._Smallest_Sufficient_Team;

public class TopDownDpWithMemoizeSolution
{
  private ulong[] dp;
  private uint[] skills;

  public int[] SmallestSufficientTeam(string[] reqSkills, IList<IList<string>> people)
  {
    skills = new uint[people.Count];
    for (var i = 0; i < people.Count; i++)
    {
      foreach (var skill in people[i])
        skills[i] |= 1u << Array.IndexOf(reqSkills, skill);
    }
    dp = new ulong[1u << reqSkills.Length];
    var reqSkillsMask = (1u << reqSkills.Length) - 1;
    return GetTeam(GetSmallestTeamMask(reqSkillsMask));
  }

  private ulong GetSmallestTeamMask(uint skillMask)
  {
    if (skillMask == 0u)
      return 0ul;
    if (dp[skillMask] != 0)
      return dp[skillMask];
    for (var i = 0; i < skills.Length; i++)
    {
      var diff = skillMask & ~skills[i];
      if (diff != skillMask)
      {
        var team = GetSmallestTeamMask(diff) | (1ul << i);
        if (dp[skillMask] == 0 || BitOperations.PopCount(team) < BitOperations.PopCount(dp[skillMask]))
          dp[skillMask] = team;
      }
    }
    return dp[skillMask];
  }

  private static int[] GetTeam(ulong teamMask)
  {
    var result = new List<int>();
    for (var i = 0; teamMask != 0; i++)
    {
      if ((teamMask & 1) != 0)
        result.Add(i);
      teamMask >>= 1;
    }
    return result.ToArray();
  }
}
