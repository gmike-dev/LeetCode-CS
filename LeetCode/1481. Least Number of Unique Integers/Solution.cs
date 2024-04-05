namespace LeetCode._1481._Least_Number_of_Unique_Integers;

public class Solution
{
  public int FindLeastNumOfUniqueInts(int[] arr, int k)
  {
    var counter = new Dictionary<int, int>();
    foreach (var x in arr)
      counter[x] = counter.GetValueOrDefault(x) + 1;
    var result = counter.Count;
    var counts = counter.Values.ToArray();
    Array.Sort(counts);
    foreach (var count in counts.TakeWhile(c => k - c >= 0))
    {
      k -= count;
      result--;
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 5, 5, 4 }, 1, 1)]
  [TestCase(new[] { 4, 3, 1, 1, 3, 3, 2 }, 3, 2)]
  public void Test(int[] arr, int k, int expected)
  {
    new Solution().FindLeastNumOfUniqueInts(arr, k).Should().Be(expected);
  }
}
