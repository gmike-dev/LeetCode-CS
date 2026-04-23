using LeetCode.Common;

namespace LeetCode._2615._Sum_of_Distances;

public class Solution2
{
  public long[] Distance(int[] nums)
  {
    int n = nums.Length;
    Dictionary<int, List<int>> indexGroups = new();
    for (int i = 0; i < n; i++)
    {
      if (indexGroups.TryGetValue(nums[i], out List<int> indexes))
      {
        indexes.Add(i);
      }
      else
      {
        indexGroups[nums[i]] = [i];
      }
    }
    long[] arr = new long[n];
    foreach (List<int> indexes in indexGroups.Values)
    {
      long countRight = indexes.Count;
      if (countRight == 1)
      {
        continue;
      }
      long countLeft = 0;
      long leftSum = 0;
      long rightSum = 0;
      foreach (int i in indexes)
      {
        rightSum += i;
      }
      foreach (int i in indexes)
      {
        countRight--;
        rightSum -= i;
        arr[i] = (countLeft - countRight) * i + (rightSum - leftSum);
        countLeft++;
        leftSum += i;
      }
    }
    return arr;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[1,3,1,1,2]", "[5,0,3,4,0]")]
  [TestCase("[0,5,3]", "[0,0,0]")]
  public void Test(string nums, string expected)
  {
    new Solution2().Distance(nums.Array()).Should().BeEquivalentTo(expected.Array());
  }
}
