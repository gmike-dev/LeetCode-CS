namespace LeetCode._1718._Construct_the_Lexicographically_Largest_Valid_Sequence;

public class BacktrackSolution
{
  public int[] ConstructDistancedSequence(int n)
  {
    var result = new int[2 * n - 1];
    var used = new bool[n + 1];
    TryBuild(0);
    return result;

    bool TryBuild(int pos)
    {
      while (pos < result.Length)
      {
        if (result[pos] != 0)
        {
          pos++;
          continue;
        }
        for (var i = n; i > 0; i--)
        {
          if (used[i])
            continue;
          used[i] = true;
          result[pos] = i;
          if (i == 1)
          {
            if (TryBuild(pos + 1))
              return true;
          }
          else if (pos + i < result.Length && result[pos + i] == 0)
          {
            result[pos + i] = i;
            if (TryBuild(pos + 1))
              return true;
            result[pos + i] = 0;
          }
          result[pos] = 0;
          used[i] = false;
        }
        return false;
      }
      return true;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(1, new[] { 1 })]
  [TestCase(3, new[] { 3, 1, 2, 3, 2 })]
  [TestCase(5, new[] { 5, 3, 1, 4, 3, 5, 2, 4, 2 })]
  [TestCase(6, new[] { 6, 4, 2, 5, 2, 4, 6, 3, 5, 1, 3 })]
  [TestCase(20, new[]
  {
    20, 18, 19, 15, 13, 17, 10, 16, 7, 5, 3, 14, 12, 3, 5, 7, 10, 13, 15, 18, 20, 19, 17, 16, 12, 14, 11, 9, 4, 6, 8,
    2, 4, 2, 1, 6, 9, 11, 8
  })]
  public void Test(int n, int[] expected)
  {
    new BacktrackSolution().ConstructDistancedSequence(n).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
