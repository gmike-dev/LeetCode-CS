namespace LeetCode.Numbers._66._Plus_One;

public class Solution
{
  public int[] PlusOne(int[] digits)
  {
    var result = new Stack<int>(digits.Length + 1);
    var carry = 1;
    for (var i = digits.Length - 1; i >= 0; i--)
    {
      var s = digits[i] + carry;
      result.Push(s % 10);
      carry = s / 10;
    }
    if (carry != 0)
      result.Push(carry);
    return result.ToArray();
  }
}
