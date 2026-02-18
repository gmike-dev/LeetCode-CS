using LeetCode.Common;

namespace LeetCode._493._Reverse_Pairs;

public class Solution
{
  public int ReversePairs(int[] nums)
  {
    return Merge(nums);

    int Merge(Span<int> a)
    {
      var n = a.Length;
      if (n < 2)
      {
        return 0;
      }
      var mid = a.Length / 2;
      var left = a[..mid];
      var right = a[mid..];
      var inv = Merge(left) + Merge(right) + Inversions(left, right);
      Span<int> temp = stackalloc int[n];
      var i = 0;
      var j = 0;
      var k = 0;
      while (i < left.Length && j < right.Length)
      {
        if (left[i] <= right[j])
        {
          temp[k++] = left[i++];
        }
        else
        {
          temp[k++] = right[j++];
        }
      }
      while (i < left.Length)
      {
        temp[k++] = left[i++];
      }
      while (j < right.Length)
      {
        temp[k++] = right[j++];
      }
      temp.CopyTo(a);
      return inv;
    }

    int Inversions(Span<int> a, Span<int> b)
    {
      var result = 0;
      var i = 0;
      var j = 0;
      while (i < a.Length && j < b.Length)
      {
        if (a[i] <= 2L * b[j])
        {
          i++;
        }
        else
        {
          result += a.Length - i;
          j++;
        }
      }
      return result;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,3,2,3,1]", 2)]
  [TestCase("[2,4,3,5,1]", 3)]
  public void Test(string nums, int expected)
  {
    new Solution().ReversePairs(nums.Array()).Should().Be(expected);
  }
}
