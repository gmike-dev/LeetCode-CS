using System.Linq;

namespace LeetCode._767._Reorganize_String;

public class Solution
{
  public string ReorganizeString(string s)
  {
    var stats = new (int count, char c)[26];
    for (var i = 0; i < 26; i++)
      stats[i].c = (char)('a' + i);
    foreach (var c in s)
      stats[c - 'a'].count++;
    stats = stats.OrderByDescending(x => x.count).ToArray(); // Linq uses stable sort. Needed for tests.

    var n = s.Length;
    var result = new char[n];
    for (int i = 0, j = 0, k = 0; i < n; i++)
    {
      if (stats[k].count == 0)
        k++;
      result[j] = stats[k].c;
      stats[k].count--;
      j += 2;
      if (j >= n)
        j = 1;
    }

    for (var i = 0; i < n - 1; i++)
      if (result[i] == result[i + 1])
        return string.Empty;

    return new string(result);
  }
}