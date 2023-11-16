namespace LeetCode._1980._Find_Unique_Binary_String;

public class CantorDiagonalSolution
{
  public string FindDifferentBinaryString(string[] nums)
  {
    var n = nums.Length;
    var s = new char[n];
    for (var i = 0; i < n; i++)
      s[i] = nums[i][i] == '0' ? '1' : '0';
    return new string(s);
  }
}