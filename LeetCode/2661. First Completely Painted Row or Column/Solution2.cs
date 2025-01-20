namespace LeetCode._2661._First_Completely_Painted_Row_or_Column;

public class Solution2
{
  public int FirstCompleteIndex(int[] arr, int[][] mat)
  {
    var n = mat.Length;
    var m = mat[0].Length;
    Span<int> index = stackalloc int[n * m + 1];
    for (int i = 0, id = 0; i < n; i++)
    {
      for (var j = 0; j < m; j++)
        index[mat[i][j]] = id++;
    }
    Span<int> rowCount = stackalloc int[n];
    Span<int> colCount = stackalloc int[m];
    for (var i = 0; i < arr.Length; i++)
    {
      var ind = index[arr[i]];
      var row = ind / m;
      var col = ind % m;
      rowCount[row]++;
      colCount[col]++;
      if (rowCount[row] == m || colCount[col] == n)
        return i;
    }
    return -1;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2().FirstCompleteIndex([1, 3, 4, 2],
    [
      [1, 4],
      [2, 3]
    ]).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    new Solution2().FirstCompleteIndex([2, 8, 7, 4, 1, 3, 5, 6, 9],
    [
      [3, 2, 5],
      [1, 4, 6],
      [8, 7, 9]
    ]).Should().Be(3);
  }
}
