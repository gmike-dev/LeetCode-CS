using System;

namespace LeetCode._1347._Minimum_Number_of_Steps_to_Make_Two_Strings_Anagram;

public class SolutionV1
{
  public int MinSteps(string s, string t)
  {
    const int n = 26;
    var cs = new int[n];
    var ct = new int[n];
    foreach (var c in s)
      cs[c - 'a']++;
    foreach (var c in t)
      ct[c - 'a']++;
    var result = 0;
    for (var i = 0; i < n; i++)
      result += cs[i] - Math.Min(cs[i], ct[i]);
    return result;
  }
}