namespace LeetCode.__Monotonic._907._Sum_of_Subarray_Minimums;

/// <summary>
/// https://leetcode.com/problems/sum-of-subarray-minimums
/// </summary>
public class Solution
{
  public int SumSubarrayMins(int[] arr)
  {
    var a = new int[arr.Length + 1];
    arr.CopyTo(a, 1);
    var n = a.Length;
    var s = new Stack<int>();
    s.Push(0);
    var count = new int[n];
    for (var i = 0; i < n; i++)
    {
      while (s.Count > 0 && a[i] < a[s.Peek()])
        s.Pop();
      var j = s.Peek();
      count[i] = count[j] + (i - j) * a[i];
      s.Push(i);
    }
    var result = 0;
    const int m = (int)1e9 + 7;
    foreach (var c in count)
      result = (result + c) % m;
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 3, 1, 2, 4 }, 17)]
  [TestCase(new[] { 11, 81, 94, 43, 3 }, 444)]
  public void Test(int[] arr, int expected)
  {
    new Solution().SumSubarrayMins(arr).Should().Be(expected);
  }
}
