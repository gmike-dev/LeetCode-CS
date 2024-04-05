namespace LeetCode._912._Sort_an_Array;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 5, 2, 3, 1 }, new[] { 1, 2, 3, 5 })]
  [TestCase(new[] { 5, 1, 1, 2, 0, 0 }, new[] { 0, 0, 1, 1, 2, 5 })]
  [TestCase(new[] { 0, -1 }, new[] { -1, 0 })]
  [TestCase(new[] { 50000, -50000, 0 }, new[] { -50000, 0, 50000 })]
  [TestCase(new int[] { }, new int[] { })]
  public void Test(int[] nums, int[] expected)
  {
    new CountingSortSolution().SortArray(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
    new RadixSortSolution().SortArray(nums).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
