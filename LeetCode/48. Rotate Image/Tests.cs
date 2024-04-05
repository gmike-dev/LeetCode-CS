namespace LeetCode._48._Rotate_Image;

[TestFixture]
public class Tests
{
  private static IEnumerable<object[]> TestsCases()
  {
    yield return new object[]
    {
      new[]
      {
        new[] { 1, 2, 3 },
        new[] { 4, 5, 6 },
        new[] { 7, 8, 9 }
      },
      new[]
      {
        new[] { 7, 4, 1 },
        new[] { 8, 5, 2 },
        new[] { 9, 6, 3 }
      }
    };
    yield return new object[]
    {
      new[]
      {
        new[] { 5, 1, 9, 11 },
        new[] { 2, 4, 8, 10 },
        new[] { 13, 3, 6, 7 },
        new[] { 15, 14, 12, 16 }
      },
      new[]
      {
        new[] { 15, 13, 2, 5 },
        new[] { 14, 3, 4, 1 },
        new[] { 12, 6, 8, 9 },
        new[] { 16, 7, 10, 11 }
      }
    };
  }

  [TestCaseSource(nameof(TestsCases))]
  public void Test1(int[][] matrix, int[][] expected)
  {
    new Solution().Rotate(matrix);
    matrix.Should().BeEquivalentTo(expected);
  }

  [TestCaseSource(nameof(TestsCases))]
  public void Test2(int[][] matrix, int[][] expected)
  {
    new Solution().Rotate2(matrix);
    matrix.Should().BeEquivalentTo(expected);
  }
}
