namespace LeetCode.Numbers._1545._Find_Kth_Bit_in_Nth_Binary_String;

public class IterativeSolution
{
  public char FindKthBit(int n, int k)
  {
    int invert = 0;
    while (n > 1)
    {
      int m = 1 << (n - 1);
      if (k == m)
      {
        invert = 1 - invert;
        break;
      }
      if (k > m)
      {
        k = 2 * m - k;
        invert = 1 - invert;
      }
      n--;
    }

    return (char)('0' + invert);
  }
}

[TestFixture]
public class IterativeSolutionTests
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
    new IterativeSolution().FindKthBit(n, k).Should().Be(expected);
  }
}
