namespace LeetCode._2363._Merge_Similar_Items;

public class DictionarySolution
{
  public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
  {
    var d = new Dictionary<int, int>();
    foreach (var item in items1)
      d[item[0]] = item[1];
    foreach (var item in items2)
      d[item[0]] = d.GetValueOrDefault(item[0]) + item[1];
    var result = new int[d.Count][];
    var index = 0;
    foreach (var (value, weight) in d)
      result[index++] = [value, weight];
    Array.Sort(result, (x, y) => x[0] - y[0]);
    return result;
  }
}

[TestFixture]
public class DictionarySolutionTests
{
  [Test]
  public void Test1()
  {
    new DictionarySolution().MergeSimilarItems([[1, 1], [4, 5], [3, 8]], [[3, 1], [1, 5]]).Should()
      .BeEquivalentTo((int[][]) [[1, 6], [3, 9], [4, 5]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new DictionarySolution().MergeSimilarItems([[1, 1], [3, 2], [2, 3]], [[2, 1], [3, 2], [1, 3]]).Should()
      .BeEquivalentTo((int[][]) [[1, 4], [2, 4], [3, 4]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new DictionarySolution().MergeSimilarItems([[1, 3], [2, 2]], [[7, 1], [2, 2], [1, 4]]).Should()
      .BeEquivalentTo((int[][]) [[1, 7], [2, 4], [7, 1]], o => o.WithStrictOrdering());
  }
}
