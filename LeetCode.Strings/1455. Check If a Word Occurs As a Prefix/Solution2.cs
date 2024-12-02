namespace LeetCode.Strings._1455._Check_If_a_Word_Occurs_As_a_Prefix;

public class Solution2
{
  public int IsPrefixOfWord(string sentence, string searchWord)
  {
    var wordIndex = 0;
    var prevSpace = true;
    var matchMode = false;
    for (int i = 0, j = 0; i < sentence.Length; i++)
    {
      if (sentence[i] == ' ')
      {
        prevSpace = true;
        matchMode = false;
        j = 0;
      }
      else
      {
        if (prevSpace)
        {
          wordIndex++;
          matchMode = true;
          prevSpace = false;
        }
        if (matchMode)
        {
          if (sentence[i] == searchWord[j])
          {
            j++;
          }
          else
          {
            j = 0;
            matchMode = false;
          }
          if (j == searchWord.Length)
            return wordIndex;
        }
      }
    }
    return -1;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("i love eating burger", "burg", 4)]
  [TestCase("this problem is an easy problem", "pro", 2)]
  [TestCase("i am tired", "you", -1)]
  [TestCase("i am your dad", "daddy", -1)]
  [TestCase("b bu bur burg burger", "burg", 4)]
  public void Test(string sentence, string searchWord, int expected)
  {
    new Solution2().IsPrefixOfWord(sentence, searchWord).Should().Be(expected);
  }
}
