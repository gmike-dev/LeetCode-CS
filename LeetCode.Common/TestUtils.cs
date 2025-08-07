namespace LeetCode.Common;

public static class TestUtils
{
  public static int[] Array(this string s)
  {
    var trimmed = s.Trim('[', ']');
    return trimmed == "" ? [] : trimmed.Split(",").Select(int.Parse).ToArray();
  }

  public static int[][] Array2(this string s)
  {
    var trimmed = s[1..^1];
    return trimmed == "" ? [] : trimmed.Split("],[").Select(row => row.Array()).ToArray();
  }

  public static string String(this int[] a)
  {
    return $"[{string.Join(",", a)}]";
  }

  public static string String(this int[][] a)
  {
    return $"[{string.Join(",", a.Select(aa => aa.String()))}]";
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void ToArrayTest()
  {
    "[]".Array().Should().BeEmpty();
    "[1]".Array().Should().BeEquivalentTo([1]);
    "[1,-2,3]".Array().Should().BeEquivalentTo([1, -2, 3], o => o.WithStrictOrdering());
  }

  [Test]
  public void ToArray2Test()
  {
    "[]".Array2().Should().BeEmpty();
    "[[]]".Array2().Should().BeEquivalentTo((int[][]) [[]]);
    "[[1]]".Array2().Should().BeEquivalentTo((int[][]) [[1]]);
    "[[],[1],[1,-2,22]]".Array2().Should().BeEquivalentTo((int[][]) [[], [1], [1, -2, 22]]);
    "[[],[]]".Array2().Should().BeEquivalentTo((int[][]) [[], []]);
  }

  [Test]
  public void ArrayToStringTest()
  {
    Array.Empty<int>().String().Should().Be("[]");
    new[] { 1 }.String().Should().Be("[1]");
    new[] { 1, -2, 3 }.String().Should().Be("[1,-2,3]");
  }

  [Test]
  public void Array2ToStringTest()
  {
    ((int[][]) []).String().Should().Be("[]");
    ((int[][]) [[]]).String().Should().Be("[[]]");
    ((int[][]) [[1]]).String().Should().Be("[[1]]");
    ((int[][]) [[], [1], [1, -2, 22]]).String().Should().Be("[[],[1],[1,-2,22]]");
    ((int[][]) [[], []]).String().Should().Be("[[],[]]");
  }
}
