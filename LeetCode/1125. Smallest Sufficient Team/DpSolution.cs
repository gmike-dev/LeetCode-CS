using System;
using System.Collections.Generic;
using System.Numerics;

namespace LeetCode._1125._Smallest_Sufficient_Team;

public class DpSolution
{
  public int[] SmallestSufficientTeam(string[] reqSkills, IList<IList<string>> people)
  {
    var n = people.Count;
    var m = reqSkills.Length;
    var skills = new uint[n];
    for (var i = 0; i < n; i++)
    {
      foreach (var skill in people[i])
        skills[i] |= 1u << Array.IndexOf(reqSkills, skill);
    }
    var dp = new ulong[1u << m];
    Array.Fill(dp, (1ul << n) - 1);
    dp[0] = 0;
    for (var skillMask = 1u; skillMask < 1u << m; skillMask++)
    {
      for (var i = 0; i < n; i++)
      {
        var diff = skillMask & ~skills[i];
        if (diff != skillMask)
        {
          var team = dp[diff] | (1ul << i);
          if (BitOperations.PopCount(team) < BitOperations.PopCount(dp[skillMask]))
            dp[skillMask] = team;
        }
      }
    }
    return GetTeam(dp[^1]);
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