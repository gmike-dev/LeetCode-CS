namespace LeetCode.SlidingWindow._3306._Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II;

public class Solution3
{
  public long CountOfSubstrings(string word, int k)
  {
    const int allVowels = 1 | (1 << ('e' - 'a')) | (1 << ('i' - 'a')) | (1 << ('o' - 'a')) | (1 << ('u' - 'a'));
    bool[] isVowel = GetVowels();
    return AtLeastK(k) - AtLeastK(k + 1);

    long AtLeastK(int minConsonants)
    {
      var vowels = 0;
      var vowelCount = new int[128];
      var consonants = 0;
      long count = 0;
      for (int l = 0, r = 0; r < word.Length; r++)
      {
        Include(word[r]);
        for (; l < r && consonants >= minConsonants && vowels == allVowels; l++)
          Exclude(word[l]);
        count += l;
      }
      return count;

      void Include(char c)
      {
        if (isVowel[c])
        {
          if (vowelCount[c]++ == 0)
            vowels |= 1 << (c - 'a');
        }
        else
        {
          consonants++;
        }
      }

      void Exclude(char c)
      {
        if (isVowel[c])
        {
          if (--vowelCount[c] == 0)
            vowels ^= 1 << (c - 'a');
        }
        else
        {
          consonants--;
        }
      }
    }

    bool[] GetVowels()
    {
      var vowels = new bool[128];
      foreach (var v in "aeiou")
        vowels[v] = true;
      return vowels;
    }
  }
}

[TestFixture]
public class Solution3Tests
{
  [TestCase("aeioqq", 1, 0L)]
  [TestCase("aeiou", 0, 1L)]
  [TestCase("ieaouqqieaouqq", 1, 3L)]
  [TestCase("akikjebkdifeiocuieckguach", 9, 5L)]
  public void Test(string word, int k, long expected)
  {
    new Solution3().CountOfSubstrings(word, k).Should().Be(expected);
  }
}
