namespace LeetCode.SlidingWindow._2062._Count_Vowel_Substrings_of_a_String;

public class Solution
{
  public int CountVowelSubstrings(string word)
  {
    Span<bool> isVowel = stackalloc bool[128];
    foreach (var v in "aeiou")
      isVowel[v] = true;
    Span<int> vowels = stackalloc int[128];
    var count = 0;
    var length1 = 0;
    var length2 = 0;
    for (var i = 0; i < word.Length; i++)
    {
      if (isVowel[word[i]])
      {
        length1++;
        length2++;
        vowels[word[i]]++;
        while (vowels['a'] != 0 && vowels['e'] != 0 && vowels['i'] != 0 && vowels['o'] != 0 && vowels['u'] != 0)
        {
          vowels[word[i - length2 + 1]]--;
          length2--;
        }
        count += length1 - length2;
      }
      else
      {
        length1 = 0;
        length2 = 0;
        foreach (var v in "aeiou")
          vowels[v] = 0;
      }
    }
    return count;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("aeiouu", 2)]
  [TestCase("unicornarihan", 0)]
  [TestCase("cuaieuouac", 7)]
  [TestCase("bbaeixoubb", 0)]
  public void Test(string word, int expected)
  {
    new Solution().CountVowelSubstrings(word).Should().Be(expected);
  }
}
