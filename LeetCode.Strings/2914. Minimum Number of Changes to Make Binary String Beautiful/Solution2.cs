namespace LeetCode.Strings._2914._Minimum_Number_of_Changes_to_Make_Binary_String_Beautiful;

public class Solution2
{
  public int MinChanges(string s)
  {
    return s.Chunk(2).Count(c => c[0] != c[1]);
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("1001", 2)]
  [TestCase("10", 1)]
  [TestCase("0000", 0)]
  [TestCase("11000111", 1)]
  public void Test(string s, int expected)
  {
    new Solution2().MinChanges(s).Should().Be(expected);
  }
}
