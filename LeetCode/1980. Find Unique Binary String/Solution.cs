namespace LeetCode._1980._Find_Unique_Binary_String;

public class Solution
{
  public string FindDifferentBinaryString(string[] nums) {
    var n = nums.Length;
    for (var i = 0; i < (1 << (n + 1)); i++) {
      var s = Convert.ToString(i, 2).PadLeft(n, '0');
      if (!nums.Contains(s)) {
        return s;
      }
    }
    return null;
  }
}
