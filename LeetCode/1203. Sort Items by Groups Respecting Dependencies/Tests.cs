namespace LeetCode._1203._Sort_Items_by_Groups_Respecting_Dependencies;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var group = new[] { -1, -1, 1, 0, 0, 1, 0, -1 };
    var beforeItems = new List<IList<int>>
    {
      Array.Empty<int>(), new[] { 6 }, new[] { 5 }, new[] { 6 }, new[] { 3, 6 },
      Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>()
    };
    var expectation = new[] { 6, 3, 4, 1, 5, 2, 0, 7 };
    new Solution().SortItems(8, 2, group, beforeItems).Should().BeEquivalentTo(expectation);
  }

  [Test]
  public void Test2()
  {
    var group = new[] { -1, -1, 1, 0, 0, 1, 0, -1 };
    var beforeItems = new List<IList<int>>
    {
      Array.Empty<int>(), new[] { 6 }, new[] { 5 }, new[] { 6 }, new[] { 3 },
      Array.Empty<int>(), new[] { 4 }, Array.Empty<int>()
    };
    var expectation = Array.Empty<int>();
    new Solution().SortItems(8, 2, group, beforeItems).Should().BeEquivalentTo(expectation);
  }
}
