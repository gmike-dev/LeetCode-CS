namespace LeetCode._77._Combinations;

[TestFixture]
public class Tests
{
  private static IEnumerable<Solution.ICombinationGenerator> GetImplementers()
  {
    yield return new Solution.CombinationGenerator();
    yield return new Solution.CombinationSimpleGenerator();
    yield return new Solution.CombinationRecursiveGenerator();
  }

  [TestCaseSource(nameof(GetImplementers))]
  public void Test1<T>(T generator) where T : Solution.ICombinationGenerator
  {
    generator.Generate(4, 2).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1, 2 },
        new[] { 1, 3 },
        new[] { 1, 4 },
        new[] { 2, 3 },
        new[] { 2, 4 },
        new[] { 3, 4 }
      });
  }

  [TestCaseSource(nameof(GetImplementers))]
  public void Test2<T>(T generator) where T : Solution.ICombinationGenerator
  {
    generator.Generate(1, 1).Should().BeEquivalentTo(
      new[]
      {
        new[] { 1 }
      });
  }

  [TestCaseSource(nameof(GetImplementers))]
  public void Test3<T>(T generator) where T : Solution.ICombinationGenerator
  {
    generator.Generate(20, 10).Should().HaveCount(184756);
  }
}
