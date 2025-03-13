namespace LeetCode._3356._Zero_Array_Transformation_II;

public class LineSweepSolution
{
  public int MinZeroArray(int[] nums, int[][] queries)
  {
    Span<int> diff = stackalloc int[nums.Length + 1];
    var k = 0;
    var s = 0;
    for (var i = 0; i < nums.Length; i++)
    {
      while (s + diff[i] < nums[i])
      {
        if (k >= queries.Length)
          return -1;
        var q = queries[k];
        var (l, r, val) = (q[0], q[1], q[2]);
        if (r >= i)
        {
          diff[Math.Max(i, l)] += val;
          diff[r + 1] -= val;
        }
        k++;
      }
      s += diff[i];
    }
    return k;
  }
}

[TestFixture]
public class LineSweepSolutionTests
{
  [Test]
  public void Test1()
  {
    new LineSweepSolution().MinZeroArray([2, 0, 2], [[0, 2, 1], [0, 2, 1], [1, 1, 3]]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new LineSweepSolution().MinZeroArray([4, 3, 2, 1], [[1, 3, 2], [0, 2, 1]]).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new LineSweepSolution().MinZeroArray([0], [[0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5]]).Should().Be(0);
  }
}
