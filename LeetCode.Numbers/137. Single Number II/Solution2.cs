using LeetCode.Common;

namespace LeetCode.Numbers._137._Single_Number_II;

public class Solution2
{
  public int SingleNumber(int[] nums)
  {
    int ones = 0; // Биты, которые встречаются один раз (по модулю 3)
    int twos = 0; // Биты, которые встречаются два раза (по модулю 3)
    foreach (int x in nums)
    {
      ones ^= x & ~twos; // Добавляем текущий элемент к ones, если его нет в twos
      twos ^= x & ~ones; // Добавляем текущий элемент к twos, если его нет в ones
    }
    return ones; // В ones остались биты, встретившиеся 1 раз
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[2,2,3,2]", 3)]
  [TestCase("[0,1,0,1,0,1,99]", 99)]
  public void Test(string nums, int expected)
  {
    new Solution2().SingleNumber(nums.Array()).Should().Be(expected);
  }
}
