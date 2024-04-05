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

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().GroupAnagrams(new[] { "eat", "tea", "tan", "ate", "nat", "bat" }).Should().BeEquivalentTo(new[]
    {
      new[] { "bat" }, new[] { "nat", "tan" }, new[] { "ate", "eat", "tea" }
    });
  }

  [Test]
  public void Test2()
  {
    new Solution().GroupAnagrams(new[] { "" }).Should().BeEquivalentTo(new[]
    {
      new[] { "" }
    });
  }

  [Test]
  public void Test3()
  {
    new Solution().GroupAnagrams(new[] { "a" }).Should().BeEquivalentTo(new[]
    {
      new[] { "a" }
    });
  }
}
