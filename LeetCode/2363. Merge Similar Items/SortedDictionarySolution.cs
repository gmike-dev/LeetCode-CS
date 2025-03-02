namespace LeetCode._2363._Merge_Similar_Items;

public class SortedDictionarySolution
{
  public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
  {
    var d = new SortedDictionary<int, int>();
    foreach (var item in items1.Concat(items2))
      d[item[0]] = d.GetValueOrDefault(item[0]) + item[1];
    return d.Select(p => new[] { p.Key, p.Value }).ToArray<IList<int>>();
  }
}

[TestFixture]
public class SortedDictionarySolutionTests
{
  [Test]
  public void Test1()
  {
    new SortedDictionarySolution().MergeSimilarItems([[1, 1], [4, 5], [3, 8]], [[3, 1], [1, 5]]).Should()
      .BeEquivalentTo((int[][]) [[1, 6], [3, 9], [4, 5]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new SortedDictionarySolution().MergeSimilarItems([[1, 1], [3, 2], [2, 3]], [[2, 1], [3, 2], [1, 3]]).Should()
      .BeEquivalentTo((int[][]) [[1, 4], [2, 4], [3, 4]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new SortedDictionarySolution().MergeSimilarItems([[1, 3], [2, 2]], [[7, 1], [2, 2], [1, 4]]).Should()
      .BeEquivalentTo((int[][]) [[1, 7], [2, 4], [7, 1]], o => o.WithStrictOrdering());
  }
}
