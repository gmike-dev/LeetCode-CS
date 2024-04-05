namespace LeetCode.__Strings._290._Word_Pattern;

public class Solution
{
  public bool WordPattern(string pattern, string s)
  {
    var words = s.Split();
    if (words.Length != pattern.Length)
      return false;
    var charWord = new Dictionary<char, string>();
    var wordChar = new Dictionary<string, char>();
    foreach (var (c, word) in pattern.Zip(words))
    {
      if (!charWord.TryAdd(c, word) && word != charWord[c])
        return false;
      if (!wordChar.TryAdd(word, c) && c != wordChar[word])
        return false;
    }
    return true;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abba", "dog cat cat dog", true)]
  [TestCase("abba", "dog cat cat fish", false)]
  [TestCase("aaaa", "dog cat cat dog", false)]
  [TestCase("abba", "dog cat cat", false)]
  [TestCase("abb", "dog cat cat", true)]
  [TestCase("abba", "dog dog dog dog", false)]
  public void Test(string pattern, string s, bool expected)
  {
    new Solution().WordPattern(pattern, s).Should().Be(expected);
  }
}
