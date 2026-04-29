using LeetCode.Common;

namespace LeetCode.Numbers._137._Single_Number_II;

public class Solution1
{
  public int SingleNumber(int[] nums)
  {
    Span<uint> bitCount = stackalloc uint[32];
    foreach (int num in nums)
    {
      uint x = (uint)num;
      int bit = 0;
      while (x != 0)
      {
        bitCount[bit] += x & 1;
        bit++;
        x >>= 1;
      }
    }
    uint result = 0;
    for (int i = 0; i < 32; i++)
    {
      result |= (bitCount[i] % 3) << i;
    }
    return (int)result;
  }
}

[TestFixture]
public class Solution1Tests
{
  [TestCase("[2,2,3,2]", 3)]
  [TestCase("[0,1,0,1,0,1,99]", 99)]
  public void Test(string nums, int expected)
  {
    new Solution1().SingleNumber(nums.Array()).Should().Be(expected);
  }
}
