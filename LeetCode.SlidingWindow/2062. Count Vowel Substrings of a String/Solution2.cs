namespace LeetCode.SlidingWindow._2062._Count_Vowel_Substrings_of_a_String;

public class Solution2
{
  public int CountVowelSubstrings(string word)
  {
    var isVowel = new bool[128];
    foreach (var v in "aeiou")
      isVowel[v] = true;
    return AtMost(6) - AtMost(5);

    int AtMost(int n)
    {
      var freq = new Dictionary<char, int>();
      var count = 0;
      for (int l = 0, r = 0; r < word.Length; r++)
      {
        var cr = word[r];
        if (isVowel[cr])
        {
          freq[cr] = freq.GetValueOrDefault(cr) + 1;
          while (freq.Count >= n)
          {
            var cl = word[l];
            if (--freq[cl] == 0)
              freq.Remove(cl);
            l++;
          }
          count += r - l + 1;
        }
        else
        {
          l = r + 1;
          freq.Clear();
        }
      }
      return count;
    }
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("aeiouu", 2)]
  [TestCase("unicornarihan", 0)]
  [TestCase("cuaieuouac", 7)]
  [TestCase("bbaeixoubb", 0)]
  public void Test(string word, int expected)
  {
    new Solution2().CountVowelSubstrings(word).Should().Be(expected);
  }
}
