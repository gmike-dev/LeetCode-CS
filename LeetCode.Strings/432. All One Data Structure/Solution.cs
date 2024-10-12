namespace LeetCode.Strings._432._All_One_Data_Structure;

public class AllOne
{
  private readonly TrieNode trie = new();

  public void Inc(string key)
  {
    var t = trie;
    foreach (var c in key)
    {
      t = t.Next[c - 'a'] ??= new TrieNode();
      t.Count++;
    }
    t.Key = key;
  }

  public void Dec(string key)
  {
    var t = trie;
    foreach (var c in key)
    {
      var i = c - 'a';
      if (t.Next[i] == null || t.Next[i].Count == 1)
      {
        t.Next[i] = null;
        break;
      }
      t = t.Next[i];
      t.Count--;
    }
  }

  public string GetMaxKey()
  {
    for (var t = trie; t != null; t = t.Next.MaxBy(n => n?.Count))
    {
      if (t.Key != null)
        return t.Key;
    }
    return "";
  }

  public string GetMinKey()
  {
    for (var t = trie; t != null; t = t.Next.MinBy(n => n?.Count))
    {
      if (t.Key != null)
        return t.Key;
    }
    return "";
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public int Count;
    public string Key;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var allOne = new AllOne();
    allOne.Inc("hello");
    allOne.Inc("hello");
    allOne.GetMaxKey().Should().Be("hello"); // return "hello"
    allOne.GetMinKey().Should().Be("hello"); // return "hello"
    allOne.Inc("leet");
    allOne.GetMaxKey().Should().Be("hello"); // return "hello"
    allOne.GetMinKey().Should().Be("leet"); // return "leet"
  }
}
