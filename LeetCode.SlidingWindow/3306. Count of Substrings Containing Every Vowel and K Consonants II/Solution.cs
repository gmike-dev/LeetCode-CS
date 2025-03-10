namespace LeetCode.SlidingWindow._3306._Count_of_Substrings_Containing_Every_Vowel_and_K_Consonants_II;

public class Solution
{
  public long CountOfSubstrings(string word, int k)
  {
    bool[] isVowel = GetVowels();

    var l1 = 0;
    var l2 = 0;
    var r = 0;
    var vowels1 = new int[128];
    var vowels2 = new int[128];
    var consonants1 = 0;
    var consonants2 = 0;
    long count = 0;
    for (; r < word.Length; r++)
    {
      Include(word[r], vowels1, ref consonants1);
      Include(word[r], vowels2, ref consonants2);
      if (consonants1 < k || !AllVowels(vowels1))
        continue;
      for (; l1 < r && consonants1 > k; l1++)
      {
        Exclude(word[l1], vowels1, ref consonants1);
        if (l1 >= l2)
          Exclude(word[l1], vowels2, ref consonants2);
      }
      for (l2 = Math.Max(l1, l2); l2 < r && consonants2 == k && AllVowels(vowels2); l2++)
        Exclude(word[l2], vowels2, ref consonants2);
      count += l2 - l1;
    }
    return count;

    void Include(char c, int[] vowels, ref int consonants)
    {
      if (isVowel[c])
        vowels[c]++;
      else
        consonants++;
    }

    void Exclude(char c, int[] vowels, ref int consonants)
    {
      if (isVowel[c])
        vowels[c]--;
      else
        consonants--;
    }

    bool AllVowels(int[] cnt) =>
      cnt['a'] != 0 && cnt['e'] != 0 && cnt['i'] != 0 &&
      cnt['o'] != 0 && cnt['u'] != 0;

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
public class SolutionTests
{
  [TestCase("aeioqq", 1, 0L)]
  [TestCase("aeiou", 0, 1L)]
  [TestCase("ieaouqqieaouqq", 1, 3L)]
  [TestCase("akikjebkdifeiocuieckguach", 9, 5L)]
  public void Test(string word, int k, long expected)
  {
    new Solution().CountOfSubstrings(word, k).Should().Be(expected);
  }
}
