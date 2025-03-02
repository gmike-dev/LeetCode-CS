namespace LeetCode._2570._Merge_Two_2D_Arrays_by_Summing_Values;

public class Solution2
{
  public int[][] MergeArrays(int[][] nums1, int[][] nums2)
  {
    var m = nums1.Length;
    var n = nums2.Length;
    var result = new List<int[]>(m + n);
    for (int i = 0, j = 0; i < m || j < n;)
    {
      if (i == m || j < n && nums2[j][0] < nums1[i][0])
      {
        result.Add([nums2[j][0], nums2[j][1]]);
        j++;
      }
      else if (j == n || nums1[i][0] < nums2[j][0])
      {
        result.Add([nums1[i][0], nums1[i][1]]);
        i++;
      }
      else
      {
        result.Add([nums1[i][0], nums1[i][1] + nums2[j][1]]);
        i++;
        j++;
      }
    }
    return result.ToArray();
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().MergeArrays([[1, 2], [2, 3], [4, 5]], [[1, 4], [3, 2], [4, 1]]).Should()
      .BeEquivalentTo((int[][]) [[1, 6], [2, 3], [3, 2], [4, 6]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution2().MergeArrays([[2, 4], [3, 6], [5, 5]], [[1, 3], [4, 3]]).Should()
      .BeEquivalentTo((int[][]) [[1, 3], [2, 4], [3, 6], [4, 3], [5, 5]], o => o.WithStrictOrdering());
  }
}
