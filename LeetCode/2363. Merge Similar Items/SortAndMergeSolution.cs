namespace LeetCode._2363._Merge_Similar_Items;

public class SortAndMergeSolution
{
  public IList<IList<int>> MergeSimilarItems(int[][] items1, int[][] items2)
  {
    var m = items1.Length;
    var n = items2.Length;
    var result = new List<IList<int>>(m + n);
    Comparison<int[]> cmp = (x, y) => x[0] - y[0];
    Array.Sort(items1, cmp);
    Array.Sort(items2, cmp);
    for (int i = 0, j = 0; i < m || j < n;)
    {
      if (i == m || j < n && items2[j][0] < items1[i][0])
      {
        result.Add([items2[j][0], items2[j][1]]);
        j++;
      }
      else if (j == n || items1[i][0] < items2[j][0])
      {
        result.Add([items1[i][0], items1[i][1]]);
        i++;
      }
      else
      {
        result.Add([items1[i][0], items1[i][1] + items2[j][1]]);
        i++;
        j++;
      }
    }
    return result;
  }
}

[TestFixture]
public class SortAndMergeSolutionTests
{
  [Test]
  public void Test1()
  {
    new SortAndMergeSolution().MergeSimilarItems([[1, 1], [4, 5], [3, 8]], [[3, 1], [1, 5]]).Should()
      .BeEquivalentTo((int[][]) [[1, 6], [3, 9], [4, 5]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new SortAndMergeSolution().MergeSimilarItems([[1, 1], [3, 2], [2, 3]], [[2, 1], [3, 2], [1, 3]]).Should()
      .BeEquivalentTo((int[][]) [[1, 4], [2, 4], [3, 4]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new SortAndMergeSolution().MergeSimilarItems([[1, 3], [2, 2]], [[7, 1], [2, 2], [1, 4]]).Should()
      .BeEquivalentTo((int[][]) [[1, 7], [2, 4], [7, 1]], o => o.WithStrictOrdering());
  }
}
