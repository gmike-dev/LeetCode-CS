using System.Linq;

namespace LeetCode._1347._Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram;

public class SolutionV2
{
  public int MinSteps(string s, string t)
  {
    var count = new int[26];
    for (var i = 0; i < s.Length; i++)
    {
      count[s[i] - 'a']++;
      count[t[i] - 'a']--;
    }
    return count.Where(c => c > 0).Sum();
  }
}