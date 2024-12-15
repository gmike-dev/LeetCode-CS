namespace LeetCode._1792._Maximum_Average_Pass_Ratio;

public class Solution2
{
  public double MaxAverageRatio(int[][] classes, int extraStudents)
  {
    var n = classes.Length;
    var q = new PriorityQueue<int, double>(n);
    for (var i = 0; i < n; i++)
    {
      var c = classes[i];
      var priority = (double)c[0] / c[1] - (double)(c[0] + 1) / (c[1] + 1);
      q.Enqueue(i, priority);
    }
    while (extraStudents > 0)
    {
      q.TryDequeue(out var i, out var priority);
      q.TryPeek(out _, out var nextPriority);
      for (var c = classes[i]; extraStudents > 0 && priority <= nextPriority; extraStudents--)
      {
        c[0]++;
        c[1]++;
        priority = (double)c[0] / c[1] - (double)(c[0] + 1) / (c[1] + 1);
      }
      q.Enqueue(i, priority);
    }
    var result = 0.0;
    foreach (var c in classes)
      result += (double)c[0] / c[1];
    return result / n;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().MaxAverageRatio([[1, 2], [3, 5], [2, 2]], 2)
      .Should()
      .BeApproximately(0.78333, 1e-5);
  }

  [Test]
  public void Test2()
  {
    new Solution2().MaxAverageRatio([[2, 4], [3, 9], [4, 5], [2, 10]], 4)
      .Should()
      .BeApproximately(0.53485, 1e-5);
  }

  [Test]
  public void Test3()
  {
    new Solution2().MaxAverageRatio([[2, 4]], 1)
      .Should()
      .BeApproximately(0.6, 1e-5);
  }

  [Test]
  public void Test4()
  {
    new Solution2().MaxAverageRatio([[2, 2]], 1)
      .Should()
      .BeApproximately(1.0, 1e-5);
  }
}
