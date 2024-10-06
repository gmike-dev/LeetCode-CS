namespace LeetCode.__Strings._1813._Sentence_Similarity_III;

public class Solution
{
  public bool AreSentencesSimilar(string sentence1, string sentence2)
  {
    var words1 = sentence1.Split();
    var words2 = sentence2.Split();
    if (words1.Length > words2.Length)
      (words1, words2) = (words2, words1);
    var l1 = 0;
    var r1 = words1.Length - 1;
    var r2 = words2.Length - 1;
    while (l1 <= r1 && words1[l1] == words2[l1])
      l1++;
    while (l1 <= r1 && words1[r1] == words2[r2])
    {
      r1--;
      r2--;
    }
    return l1 > r1;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("My name is Haley", "My Haley", true)]
  [TestCase("of", "A lot of words", false)]
  [TestCase("Eating right now", "Eating", true)]
  [TestCase("Hello Jane", "Hello my name is Jane", true)]
  [TestCase("Frog cool", "Frogs are cool", false)]
  [TestCase("a b c", "a c", true)]
  [TestCase("a b c", "a b", true)]
  [TestCase("a b c", "b c", true)]
  [TestCase("a b c", "a b c", true)]
  public void Test(string sentence1, string sentence2, bool expected)
  {
    new Solution().AreSentencesSimilar(sentence1, sentence2).Should().Be(expected);
  }
}
