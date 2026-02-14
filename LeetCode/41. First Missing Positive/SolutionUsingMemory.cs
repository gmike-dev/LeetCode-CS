namespace LeetCode._41._First_Missing_Positive;

public class SolutionUsingMemory
{
  public int FirstMissingPositive(int[] a)
  {
    const int max = (int)1e5;
    var used = new BitArray(max + 1);
    foreach (var x in a)
    {
      if (x <= 0 || x > max)
        continue;
      used[x] = true;
    }
    for (var x = 1; x < max; x++)
    {
      if (!used[x])
        return x;
    }
    return max + 1;
  }
}

[TestFixture]
public class SolutionUsingMemoryTests
{
  [TestCase(new[] { 1, 2, 0 }, 3)]
  [TestCase(new[] { 3, 4, -1, 1 }, 2)]
  [TestCase(new[] { 7, 8, 9, 11, 12 }, 1)]
  [TestCase(new[] { 1, 2, (int)1e6 }, 3)]
  [TestCase(new[] { 1 }, 2)]
  public void Test(int[] a, int expected)
  {
    new SolutionUsingMemory().FirstMissingPositive(a).Should().Be(expected);
  }
}
