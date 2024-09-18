namespace LeetCode.__Strings._211._Design_Add_and_Search_Words_Data_Structure;

public class WordDictionary
{
  private readonly TrieNode trie = new();

  public void AddWord(string word)
  {
    var root = trie;
    foreach (var c in word)
      root = root.Next[c - 'a'] ??= new TrieNode();
    root.EndWord = true;
  }

  public bool Search(string word)
  {
    return Search(trie, word, 0);
  }

  private bool Search(TrieNode node, string word, int pos)
  {
    if (pos == word.Length)
      return node.EndWord;
    if (word[pos] != '.')
    {
      var next = node.Next[word[pos] - 'a'];
      return next != null && Search(next, word, pos + 1);
    }
    foreach (var next in node.Next)
    {
      if (next != null && Search(next, word, pos + 1))
        return true;
    }
    return false;
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public bool EndWord;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var wordDictionary = new WordDictionary();
    wordDictionary.AddWord("bad");
    wordDictionary.AddWord("dad");
    wordDictionary.AddWord("mad");
    wordDictionary.Search("pad").Should().BeFalse();
    wordDictionary.Search("bad").Should().BeTrue();
    wordDictionary.Search(".ad").Should().BeTrue();
    wordDictionary.Search("b..").Should().BeTrue();
  }
}
