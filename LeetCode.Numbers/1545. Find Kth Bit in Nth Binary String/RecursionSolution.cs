namespace LeetCode.Numbers._1545._Find_Kth_Bit_in_Nth_Binary_String;

public class RecursionSolution
{
  public char FindKthBit(int n, int k)
  {
    if (n == 1)
    {
      return '0';
    }
    var m = 1 << (n - 1);
    if (k == m)
    {
      return '1';
    }
    if (k < m)
    {
      return FindKthBit(n - 1, k);
    }
    return (char)('0' + '1' - FindKthBit(n - 1, 2 * m - k));
  }
}

[TestFixture]
public class RecursionSolutionTests
{
  [TestCase(3, 1, '0')]
  [TestCase(4, 11, '1')]
  [TestCase(1, 1, '0')]
  [TestCase(2, 1, '0')]
  [TestCase(2, 2, '1')]
  [TestCase(2, 3, '1')]
  [TestCase(3, 4, '1')]
  [TestCase(3, 5, '0')]
  [TestCase(3, 6, '0')]
  [TestCase(3, 7, '1')]
  [TestCase(20, 1, '0')]
  [TestCase(20, 2, '1')]
  public void Test(int n, int k, char expected)
  {
    new RecursionSolution().FindKthBit(n, k).Should().Be(expected);
  }
}
