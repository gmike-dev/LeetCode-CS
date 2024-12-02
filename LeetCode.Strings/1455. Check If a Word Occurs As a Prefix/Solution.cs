namespace LeetCode.Strings._1455._Check_If_a_Word_Occurs_As_a_Prefix;

public class Solution
{
  public int IsPrefixOfWord(string sentence, string searchWord)
  {
    var wordIndex = 1;
    foreach (var word in sentence.Split(' '))
    {
      if (word.StartsWith(searchWord))
        return wordIndex;
      wordIndex++;
    }
    return -1;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("i love eating burger", "burg", 4)]
  [TestCase("this problem is an easy problem", "pro", 2)]
  [TestCase("i am tired", "you", -1)]
  public void Test(string sentence, string searchWord, int expected)
  {
    new Solution().IsPrefixOfWord(sentence, searchWord).Should().Be(expected);
  }
}
