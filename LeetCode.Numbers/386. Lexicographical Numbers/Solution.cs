namespace LeetCode.Numbers._386._Lexicographical_Numbers;

public class Solution
{
  public IList<int> LexicalOrder(int n)
  {
    var result = new List<int>(n);
    var num = 1;
    for (var i = 0; i < n; i++)
    {
      result.Add(num);
      if (num * 10 <= n)
      {
        num *= 10;
      }
      else
      {
        while (num >= n || num % 10 == 9)
        {
          num /= 10;
        }
        num++;
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(13, new[] { 1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9 })]
  [TestCase(2, new[] { 1, 2 })]
  public void Test(int n, int[] expected)
  {
    new Solution().LexicalOrder(n).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}

