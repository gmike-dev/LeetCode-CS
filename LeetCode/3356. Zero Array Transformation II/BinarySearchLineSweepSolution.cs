namespace LeetCode._3356._Zero_Array_Transformation_II;

public class BinarySearchLineSweepSolution
{
  public int MinZeroArray(int[] nums, int[][] queries)
  {
    var diff = new int[nums.Length + 1];
    var low = 0;
    var high = queries.Length;
    while (low <= high)
    {
      var mid = low + (high - low) / 2;
      ApplyFirstKQueries(mid);
      if (IsArrayZeroed())
        high = mid - 1;
      else
        low = mid + 1;
    }
    return low > queries.Length ? -1 : low;

    void ApplyFirstKQueries(int k)
    {
      diff.AsSpan().Clear();
      for (var i = 0; i < k; i++)
      {
        var q = queries[i];
        var (l, r, val) = (q[0], q[1], q[2]);
        diff[l] += val;
        diff[r + 1] -= val;
      }
    }

    bool IsArrayZeroed()
    {
      var sum = 0;
      for (var i = 0; i < nums.Length; i++)
      {
        sum += diff[i];
        if (sum < nums[i])
          return false;
      }
      return true;
    }
  }
}

[TestFixture]
public class BinarySearchLineSweepSolutionTests
{
  [Test]
  public void Test1()
  {
    new BinarySearchLineSweepSolution().MinZeroArray([2, 0, 2], [[0, 2, 1], [0, 2, 1], [1, 1, 3]]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new BinarySearchLineSweepSolution().MinZeroArray([4, 3, 2, 1], [[1, 3, 2], [0, 2, 1]]).Should().Be(-1);
  }

  [Test]
  public void Test3()
  {
    new BinarySearchLineSweepSolution().MinZeroArray([0], [[0, 0, 2], [0, 0, 4], [0, 0, 4], [0, 0, 3], [0, 0, 5]])
      .Should().Be(0);
  }

  [Test]
  public void Test4()
  {
    new BinarySearchLineSweepSolution().MinZeroArray([7, 6, 8], [[0, 0, 2], [0, 1, 5], [2, 2, 5], [0, 2, 4]]).Should()
      .Be(4);
  }
}
