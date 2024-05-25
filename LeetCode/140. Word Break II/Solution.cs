namespace LeetCode._140._Word_Break_II;

public class Solution
{
  public IList<string> WordBreak(string s, IList<string> wordDict)
  {
    var t = BuildTrie(wordDict);
    var result = new List<string>();
    var sentence = new List<string>();
    F(0);
    return result;

    void F(int left)
    {
      if (left == s.Length)
      {
        result.Add(string.Join(' ', sentence));
        return;
      }
      var tn = t;
      for (var i = left; i < s.Length; i++)
      {
        tn = tn.Next[s[i] - 'a'];
        if (tn == null)
          return;
        var word = tn.Word;
        if (word != null)
        {
          sentence.Add(word);
          F(i + 1);
          sentence.RemoveAt(sentence.Count - 1);
        }
      }
    }
  }

  private class TrieNode
  {
    public readonly TrieNode[] Next = new TrieNode[26];
    public string Word;
  }

  private static TrieNode BuildTrie(IList<string> dictionary)
  {
    var root = new TrieNode();
    foreach (var word in dictionary)
      AddToTrie(root, word);
    return root;
  }

  private static void AddToTrie(TrieNode root, string value)
  {
    foreach (var c in value)
      root = root.Next[c - 'a'] ??= new TrieNode();
    root.Word = value;
  }
}
