namespace LeetCode.DP._1125._Smallest_Sufficient_Team;

public class RecursiveSolution
{
  private int reqSkillMask;
  private int[] skills;
  private int peopleCount;

  public int[] SmallestSufficientTeam(string[] reqSkills, IList<IList<string>> people)
  {
    peopleCount = people.Count;
    reqSkillMask = (1 << reqSkills.Length) - 1;
    skills = new int[peopleCount];
    for (var i = 0; i < peopleCount; i++)
    {
      foreach (var skill in people[i])
        skills[i] |= 1 << Array.IndexOf(reqSkills, skill);
    }
    var teamMask = FindSmallestTeam(0, 0, 0, peopleCount);
    var team = new List<int>();
    for (var i = 0; teamMask != 0; i++)
    {
      if ((teamMask & 1) != 0)
        team.Add(i);
      teamMask >>= 1;
    }
    return team.ToArray();
  }

  private ulong FindSmallestTeam(int start, int mask, ulong curTeam, int minTeamSize)
  {
    for (var i = start; i < peopleCount; i++)
    {
      if ((mask | skills[i]) == reqSkillMask)
        return curTeam | (1ul << i);
    }
    var minTeam = ulong.MaxValue;
    for (var i = start; i < peopleCount - 1; i++)
    {
      var newMask = mask | skills[i];
      if (newMask != mask && BitOperations.PopCount(curTeam) + 1 < minTeamSize)
      {
        var team = FindSmallestTeam(i + 1, newMask, curTeam | (1ul << i), minTeamSize);
        var teamSize = BitOperations.PopCount(team);
        if (teamSize < BitOperations.PopCount(minTeam))
        {
          minTeam = team;
          minTeamSize = teamSize;
        }
      }
    }
    return minTeam;
  }
}
