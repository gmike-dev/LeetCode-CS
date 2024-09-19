namespace LeetCode._241._Different_Ways_to_Add_Parentheses;

public class Solution
{
  public IList<int> DiffWaysToCompute(string expression)
  {
    var numbers = expression.Split('-', '+', '*').Select(int.Parse).ToArray();
    var operations = new List<char>();
    foreach (var c in expression)
    {
      if (c is '-' or '+' or '*')
        operations.Add(c);
    }
    var n = numbers.Length;
    var cache = new List<int>[n][];
    for (var i = 0; i < n; i++)
      cache[i] = new List<int>[n];
    return F(0, n - 1);

    List<int> F(int l, int r)
    {
      if (l == r)
        return [numbers[l]];
      if (cache[l][r] != null)
        return cache[l][r];
      cache[l][r] = [];
      for (var i = l; i < r; i++)
      {
        var left = F(l, i);
        var right = F(i + 1, r);
        for (var j = 0; j < left.Count; j++)
        {
          for (var k = 0; k < right.Count; k++)
          {
            cache[l][r].Add(operations[i] switch
            {
              '-' => left[j] - right[k],
              '+' => left[j] + right[k],
              _ => left[j] * right[k]
            });
          }
        }
      }
      return cache[l][r];
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("2-1-1", new[] { 0, 2 })]
  [TestCase("2*3-4*5", new[] { -34, -14, -10, -10, 10 })]
  public void Test(string expression, int[] expected)
  {
    new Solution().DiffWaysToCompute(expression).Should().BeEquivalentTo(expected);
  }
}
