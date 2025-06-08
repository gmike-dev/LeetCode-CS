namespace LeetCode.Numbers._386._Lexicographical_Numbers;

public class DfsSolution
{
  public IList<int> LexicalOrder(int n)
  {
    var result = new List<int>(n);
    for (var num = 1; num <= 9 && num <= n; num++)
      F(num);
    return result;

    void F(int num)
    {
      result.Add(num);
      num *= 10;
      for (var i = 0; i <= 9 && num + i <= n; i++)
        F(num + i);
    }
  }
}

[TestFixture]
public class DfsSolutionTests
{
  [TestCase(13, new[] { 1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9 })]
  [TestCase(2, new[] { 1, 2 })]
  public void Test(int n, int[] expected)
  {
    new DfsSolution().LexicalOrder(n).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
