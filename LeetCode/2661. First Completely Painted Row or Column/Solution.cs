namespace LeetCode._2661._First_Completely_Painted_Row_or_Column;

public class Solution
{
  public int FirstCompleteIndex(int[] arr, int[][] mat)
  {
    var m = mat.Length;
    var n = mat[0].Length;
    var numRow = new int[n * m + 1];
    var numCol = new int[n * m + 1];
    for (var i = 0; i < m; i++)
    {
      var row = mat[i];
      for (var j = 0; j < n; j++)
      {
        var num = row[j];
        numRow[num] = i;
        numCol[num] = j;
      }
    }
    var rowCount = new int[m];
    var colCount = new int[n];
    for (var i = 0; i < arr.Length; i++)
    {
      var num = arr[i];
      var (r, c) = (numRow[num], numCol[num]);
      rowCount[r]++;
      colCount[c]++;
      if (rowCount[r] == n || colCount[c] == m)
        return i;
    }
    return -1;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().FirstCompleteIndex(new[] { 1, 3, 4, 2 },
      new[]
      {
        new[] { 1, 4 },
        new[] { 2, 3 }
      }).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution().FirstCompleteIndex(new[] { 2, 8, 7, 4, 1, 3, 5, 6, 9 },
      new[]
      {
        new[] { 3, 2, 5 },
        new[] { 1, 4, 6 },
        new[] { 8, 7, 9 }
      }).Should().Be(3);
  }
}
