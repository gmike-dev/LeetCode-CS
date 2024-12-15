namespace LeetCode._1792._Maximum_Average_Pass_Ratio;

public class Solution
{
  public double MaxAverageRatio(int[][] classes, int extraStudents)
  {
    var q = new PriorityQueue<int, double>();
    for (var i = 0; i < classes.Length; i++)
    {
      var c = classes[i];
      var r1 = (double)c[0] / c[1];
      var r2 = (double)(c[0] + 1) / (c[1] + 1);
      q.Enqueue(i, r1 - r2);
    }
    while (extraStudents != 0)
    {
      var i = q.Dequeue();
      var c = classes[i];
      c[0]++;
      c[1]++;
      var r1 = (double)c[0] / c[1];
      var r2 = (double)(c[0] + 1) / (c[1] + 1);
      q.Enqueue(i, r1 - r2);
      extraStudents--;
    }
    return classes.Average(c => (double)c[0] / c[1]);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxAverageRatio([[1, 2], [3, 5], [2, 2]], 2)
      .Should()
      .BeApproximately(0.78333, 1e-5);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxAverageRatio([[2, 4], [3, 9], [4, 5], [2, 10]], 4)
      .Should()
      .BeApproximately(0.53485, 1e-5);
  }
}
