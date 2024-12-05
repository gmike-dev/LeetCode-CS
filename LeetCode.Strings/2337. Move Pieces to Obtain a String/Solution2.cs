namespace LeetCode.Strings._2337._Move_Pieces_to_Obtain_a_String;

public class Solution2
{
  public bool CanChange(string start, string target)
  {
    var n = start.Length;
    for (int i = 0, j = 0; i < n || j < n; i++, j++)
    {
      while (i < n && target[i] == '_')
        i++;
      while (j < n && start[j] == '_')
        j++;
      if (i == n || j == n)
        return i == j;
      if (start[j] != target[i] ||
          start[j] == 'L' && j < i ||
          start[j] == 'R' && j > i)
        return false;
    }
    return true;
  }
}

[TestFixture]
public class Solution2Tests
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
    new Solution2().CanChange(start, target).Should().Be(expected);
  }
}
