namespace LeetCode._2570._Merge_Two_2D_Arrays_by_Summing_Values;

public class Solution
{
  public int[][] MergeArrays(int[][] nums1, int[][] nums2)
  {
    var m = nums1.Length;
    var n = nums2.Length;
    var result = new List<int[]>(m + n);
    var i = 0;
    var j = 0;
    while (i < m && j < n)
    {
      var (id1, val1) = (nums1[i][0], nums1[i][1]);
      var (id2, val2) = (nums2[j][0], nums2[j][1]);
      if (id1 < id2)
      {
        result.Add([id1, val1]);
        i++;
      }
      else if (id2 < id1)
      {
        result.Add([id2, val2]);
        j++;
      }
      else
      {
        result.Add([id1, val1 + val2]);
        i++;
        j++;
      }
    }
    for (; i < m; i++)
      result.Add([nums1[i][0], nums1[i][1]]);
    for (; j < n; j++)
      result.Add([nums2[j][0], nums2[j][1]]);
    return result.ToArray();
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MergeArrays([[1, 2], [2, 3], [4, 5]], [[1, 4], [3, 2], [4, 1]]).Should()
      .BeEquivalentTo((int[][]) [[1, 6], [2, 3], [3, 2], [4, 6]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().MergeArrays([[2, 4], [3, 6], [5, 5]], [[1, 3], [4, 3]]).Should()
      .BeEquivalentTo((int[][]) [[1, 3], [2, 4], [3, 6], [4, 3], [5, 5]], o => o.WithStrictOrdering());
  }
}
