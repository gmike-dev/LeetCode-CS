namespace LeetCode._1._Two_Sum;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var result = sln.TwoSum(new[] { -1, 2, 3, 4, 5 }, 5);
    result.Should().BeEquivalentTo(new[] { 1, 2 });
  }
}
