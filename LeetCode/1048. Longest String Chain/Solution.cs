namespace LeetCode._1048._Longest_String_Chain;

public class Solution
{
  private readonly Dictionary<string, int> _cache = new();

  public int LongestStrChain(string[] words)
  {
    var wordsSet = new HashSet<string>(words);
    return words.Max(word => ChainLength(wordsSet, word));
  }

  private int ChainLength(HashSet<string> words, string word)
  {
    if (_cache.TryGetValue(word, out var maxLength))
      return maxLength;

    maxLength = 1;
    for (var i = 0; i < word.Length; i++)
    {
      var prev = word.Remove(i, 1);
      if (words.Contains(prev))
        maxLength = Math.Max(maxLength, ChainLength(words, prev) + 1);
    }

    _cache.Add(word, maxLength);
    return maxLength;
  }
}
