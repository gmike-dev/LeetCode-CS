namespace LeetCode.Strings._2337._Move_Pieces_to_Obtain_a_String;

public class Solution
{
  public bool CanChange(string start, string target)
  {
    var n = start.Length;
    var i = 0;
    var j = 0;
    while (i < n && j < n)
    {
      if (target[i] == '_')
      {
        i++;
        continue;
      }
      if (start[j] == '_')
      {
        j++;
        continue;
      }
      if (start[j] != target[i] ||
          start[j] == 'L' && j < i ||
          start[j] == 'R' && j > i)
        return false;
      i++;
      j++;
    }
    while (i < n && target[i] == '_')
      i++;
    while (j < n && start[j] == '_')
      j++;
    return i == j;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("_L__R__R_", "L______RR", true)]
  [TestCase("R_L_", "__LR", false)]
  [TestCase("_R", "R_", false)]
  [TestCase("RRR___", "R_R_R_", true)]
  [TestCase("___LLL", "_L_L_L", true)]
  [TestCase("L___R", "R___L", false)]
  [TestCase("L_R_R", "LRR__", false)]
  [TestCase("_", "_", true)]
  [TestCase("___LLL", "LLLL__", false)]
  public void Test(string start, string target, bool expected)
  {
    new Solution().CanChange(start, target).Should().Be(expected);
  }
}
