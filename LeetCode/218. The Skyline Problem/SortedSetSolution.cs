namespace LeetCode._218._The_Skyline_Problem;

public class SortedSetSolution
{
  public IList<IList<int>> GetSkyline(int[][] buildings)
  {
    var points = new List<(int x, int h)>(2 * buildings.Length);
    foreach (var b in buildings)
    {
      points.Add((b[0], -b[2]));
      points.Add((b[1], b[2]));
    }
    points.Sort();
    var s = new SortedSet<int> { 0 };
    var count = new Dictionary<int, int> { { 0, 1 } };
    var prevH = 0;
    var result = new List<IList<int>>();
    foreach (var (x, h) in points)
    {
      if (h < 0) // start
      {
        if (s.Add(-h))
          count[-h] = 1;
        else
          count[-h]++;
      }
      else
      {
        if (--count[h] == 0)
          s.Remove(h);
      }
      var currH = s.Max;
      if (currH != prevH)
      {
        result.Add([x, currH]);
        prevH = currH;
      }
    }
    return result;
  }
}

[TestFixture]
public class SortedSetSolutionTests
{
  [Test]
  public void Test1()
  {
    IList<IList<int>> expected = [[2, 10], [3, 15], [7, 12], [12, 0], [15, 10], [20, 8], [24, 0]];
    new SortedSetSolution()
      .GetSkyline([[2, 9, 10], [3, 7, 15], [5, 12, 12], [15, 20, 10], [19, 24, 8]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test2()
  {
    IList<IList<int>> expected = [[0, 3], [5, 0]];
    new SortedSetSolution()
      .GetSkyline([[0, 2, 3], [2, 5, 3]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test3()
  {
    IList<IList<int>> expected = [[1, 1], [2, 0], [2147483646, 2147483647], [2147483647, 0]];
    new SortedSetSolution()
      .GetSkyline([[1, 2, 1], [2147483646, 2147483647, 2147483647]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test4()
  {
    IList<IList<int>> expected = [[1, 1], [2, 0], [6, 1], [7, 0]];
    new SortedSetSolution()
      .GetSkyline([[1, 2, 1], [6, 7, 1]])
      .Should()
      .BeEquivalentTo(expected);
  }

  [Test]
  public void Test5()
  {
    IList<IList<int>> expected = [[2, 10], [9, 15], [12, 0]];
    new SortedSetSolution()
      .GetSkyline([[2, 9, 10], [9, 12, 15]])
      .Should()
      .BeEquivalentTo(expected);
  }
}
