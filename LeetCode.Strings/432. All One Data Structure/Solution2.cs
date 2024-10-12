namespace LeetCode.Strings._432._All_One_Data_Structure;

public class AllOne2
{
  private readonly TrieNode trie = new();

  public void Inc(string key)
  {
    var t = trie;
    foreach (var c in key)
    {
      if (t.Next.TryGetValue(c, out var next))
        t = next;
      else
        t = t.Next[c] = new TrieNode();
      t.Count++;
    }
    t.Key = key;
  }

  public void Dec(string key)
  {
    var t = trie;
    foreach (var c in key)
    {
      var next = t.Next[c];
      if (next.Count == 1)
      {
        t.Next.Remove(c);
        break;
      }
      t = next;
      t.Count--;
    }
  }

  public string GetMaxKey()
  {
    for (var t = trie; t != null; t = t.Next.Values.MaxBy(n => n.Count))
    {
      if (t.Key != null)
        return t.Key;
    }
    return "";
  }

  public string GetMinKey()
  {
    for (var t = trie; t != null; t = t.Next.Values.MinBy(n => n.Count))
    {
      if (t.Key != null)
        return t.Key;
    }
    return "";
  }

  private class TrieNode
  {
    public readonly Dictionary<char, TrieNode> Next = new();
    public string Key;
    public int Count;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    var allOne = new AllOne2();
    allOne.Inc("hello");
    allOne.Inc("hello");
    allOne.GetMaxKey().Should().Be("hello");
    allOne.GetMinKey().Should().Be("hello");
    allOne.Inc("leet");
    allOne.GetMaxKey().Should().Be("hello");
    allOne.GetMinKey().Should().Be("leet");
  }
  [Test]
  public void Test2()
  {
    var allOne = new AllOne2();
    allOne.Inc("a");
    allOne.Inc("b");
    allOne.Inc("b");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Dec("b");
    allOne.Dec("b");
    allOne.GetMinKey().Should().Be("a");
    allOne.GetMaxKey().Should().Be("c");
    allOne.Dec("a");
    allOne.GetMaxKey().Should().Be("c");
    allOne.GetMinKey().Should().Be("c");
  }
}
