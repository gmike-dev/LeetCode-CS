namespace LeetCode._3016._Minimum_Number_of_Pushes_to_Type_Word_II;

public class Solution
{
  public int MinimumPushes(string word)
  {
    var count = new int[26];
    foreach (var c in word)
      count[c - 'a']++;
    Array.Sort(count, (x, y) => y - x);
    var answer = 0;
    var chunkNum = 1;
    foreach (var chunk in count.Chunk(8))
    {
      answer += chunkNum * chunk.Sum();
      chunkNum++;
    }
    return answer;
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abcde", 5)]
  [TestCase("xyzxyzxyzxyz", 12)]
  [TestCase("aabbccddeeffgghhiiiiii", 24)]
  public void Test(string word, int expected)
  {
    new Solution().MinimumPushes(word).Should().Be(expected);
  }
}
