using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._49._Group_Anagrams;

public class CountingSortSolution
{
  public IList<IList<string>> GroupAnagrams(string[] strs)
  {
    var d = new Dictionary<string, IList<string>>();
    foreach (var s in strs)
    {
      var key = Sort(s);
      if (d.TryGetValue(key, out var list))
        list.Add(s);
      else
        d.Add(key, new List<string> { s });
    }
    return d.Values.ToList();
  }

  private static string Sort(string s)
  {
    var ch = new int[26];
    foreach (var c in s)
      ch[c - 'a']++;
    var m = s.Length;
    var result = new char[m];
    for (int n = 0, i = 0; n < m; i++)
    {
      for (var j = ch[i]; j > 0; j--)
        result[n++] = (char)('a' + i);
    }
    return new string(result);
  }
}

[TestFixture]
public class CountingSortSolutionTests
{
  [Test]
  public void Test1()
  {
    new CountingSortSolution().GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }).Should().BeEquivalentTo(new[]
    {
      new[] { "bat" }, new[] { "nat", "tan" }, new[] { "ate", "eat", "tea" }
    });
  }

  [Test]
  public void Test2()
  {
    new CountingSortSolution().GroupAnagrams(new[] { "" }).Should().BeEquivalentTo(new[]
    {
      new[] { "" }
    });
  }

  [Test]
  public void Test3()
  {
    new CountingSortSolution().GroupAnagrams(new[] { "a" }).Should().BeEquivalentTo(new[]
    {
      new[] { "a" }
    });
  }
}
