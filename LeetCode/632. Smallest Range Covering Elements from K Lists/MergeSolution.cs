namespace LeetCode._632._Smallest_Range_Covering_Elements_from_K_Lists;

public class MergeSolution
{
  public int[] SmallestRange(IList<IList<int>> nums)
  {
    var k = nums.Count;
    var a = MergeLists(nums, 0, nums.Count - 1);
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

  private static (int val, int i)[] MergeLists(IList<IList<int>> nums, int l, int r)
  {
    if (l == r)
      return nums[l].Select(n => (n, l)).ToArray();
    var m = l + (r - l) / 2;
    var left = MergeLists(nums, l, m);
    var right = MergeLists(nums, m + 1, r);
    return Merge(left, right);
  }

  private static (int, int)[] Merge((int, int)[] first, (int, int)[] second)
  {
    var result = new (int, int)[first.Length + second.Length];
    var i = 0;
    var j = 0;
    var k = 0;
    while (i < first.Length && j < second.Length)
    {
      if (first[i].Item1 < second[j].Item1 ||
          first[i].Item1 == second[j].Item1 &&
          first[i].Item2 <= second[j].Item2)
        result[k++] = first[i++];
      else
        result[k++] = second[j++];
    }
    while (i < first.Length)
      result[k++] = first[i++];
    while (j < second.Length)
      result[k++] = second[j++];
    return result;
  }
}

[TestFixture]
public class MergeSolutionTests
{
  [Test]
  public void Test1()
  {
    new MergeSolution()
      .SmallestRange([[4, 10, 15, 24, 26], [0, 9, 12, 20], [5, 18, 22, 30]]).Should()
      .BeEquivalentTo([20, 24], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new MergeSolution()
      .SmallestRange([[1, 2, 3], [1, 2, 3], [1, 2, 3]]).Should()
      .BeEquivalentTo([1, 1], o => o.WithStrictOrdering());
  }
}
