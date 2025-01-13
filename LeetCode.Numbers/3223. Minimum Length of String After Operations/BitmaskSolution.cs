namespace LeetCode.Numbers._3223._Minimum_Length_of_String_After_Operations;

public class BitmaskSolution
{
  public int MinimumLength(string s)
  {
    uint used = 0;
    uint odd = 0;
    foreach (var c in s)
    {
      var mask = 1u << (c - 'a');
      used |= mask;
      odd ^= mask;
    }
    var count = BitOperations.PopCount(used);
    var oddCount = BitOperations.PopCount(odd);
    return 2 * count - oddCount;
  }
}

[TestFixture]
public class BitmaskSolutionTests
{
  [TestCase("abaacbcbb", 5)]
  [TestCase("aa", 2)]
  public void Test(string s, int expected)
  {
    new BitmaskSolution().MinimumLength(s).Should().Be(expected);
  }
}
