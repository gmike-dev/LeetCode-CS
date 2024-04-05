namespace LeetCode._442._Find_All_Duplicates_in_an_Array;

public class Solution
{
  public IList<int> FindDuplicates(int[] a)
  {
    var result = new List<int>();
    var n = a.Length;
    for (var i = 0; i < n; i++)
    {
      var j = Math.Abs(a[i]) - 1;
      if (a[j] < 0)
        result.Add(j + 1);
      a[j] = -a[j];
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 2, 3 })]
  [TestCase(new[] { 1, 1, 2 }, new[] { 1 })]
  [TestCase(new[] { 1 }, new int[] { })]
  [TestCase(new[] { 2, 2, 3, 1, 3 }, new[] { 2, 3 })]
  [TestCase(new[] { 2, 2, 3, 1, 3, 1 }, new[] { 1, 2, 3 })]
  public void Test(int[] a, int[] expected)
  {
    new Solution().FindDuplicates(a).Should().BeEquivalentTo(expected);
  }
}
