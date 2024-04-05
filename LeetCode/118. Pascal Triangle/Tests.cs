namespace LeetCode._118._Pascal_Triangle;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().Generate(6).Should().BeEquivalentTo(new[]
    {
      new[] { 1 },
      new[] { 1, 1 },
      new[] { 1, 2, 1 },
      new[] { 1, 3, 3, 1 },
      new[] { 1, 4, 6, 4, 1 },
      new[] { 1, 5, 10, 10, 5, 1 }
    });
  }

  [Test]
  public void Test2()
  {
    new Solution().Generate(1).Should().BeEquivalentTo(new[]
    {
      new[] { 1 }
    });
  }
}
