namespace LeetCode._632._Smallest_Range_Covering_Elements_from_K_Lists;

public class Solution
{
  public int[] SmallestRange(IList<IList<int>> nums)
  {
    var k = nums.Count;
    var a = nums
      .SelectMany((num, i) => num.Select(val => (val, i)))
      .OrderBy(x => x)
      .ToArray();
    int[] result = null;
    var minLength = int.MaxValue;
    var n = a.Length;
    var s = new Dictionary<int, int>();
    for (int left = 0, right = 0; right < n; right++)
    {
      s[a[right].i] = s.GetValueOrDefault(a[right].i) + 1;
      for (; left <= right && s.Count == k; left++)
      {
        if (a[right].val - a[left].val < minLength)
        {
          result = [a[left].val, a[right].val];
          minLength = a[right].val - a[left].val;
        }
        if (s[a[left].i] == 1)
          s.Remove(a[left].i);
        else
          s[a[left].i]--;
      }
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution()
      .SmallestRange([[4, 10, 15, 24, 26], [0, 9, 12, 20], [5, 18, 22, 30]]).Should()
      .BeEquivalentTo([20, 24], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution()
      .SmallestRange([[1, 2, 3], [1, 2, 3], [1, 2, 3]]).Should()
      .BeEquivalentTo([1, 1], o => o.WithStrictOrdering());
  }
}
