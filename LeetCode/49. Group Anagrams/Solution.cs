using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode._49._Group_Anagrams;

public class Solution
{
  public IList<IList<string>> GroupAnagrams(string[] strs)
  {
    var d = new Dictionary<string, IList<string>>();
    foreach (var s in strs)
    {
      var chars = s.ToCharArray();
      Array.Sort(chars);
      var key = new string(chars);
      if (d.TryGetValue(key, out var list))
        list.Add(s);
      else
        d.Add(key, new List<string> { s });
    }
    return d.Values.ToList();
  }
}