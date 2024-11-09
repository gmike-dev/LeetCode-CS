namespace LeetCode._3347._Maximum_Frequency_of_an_Element_After_Performing_Operations_II;

public class SweepLineSolution
{
  public int MaxFrequency(int[] nums, int k, int numOperations)
  {
    var cnt = new Dictionary<int, int>();
    var inc = new Dictionary<int, int>();
    var p = new HashSet<int>();
    foreach (var x in nums)
    {
      cnt[x] = cnt.GetValueOrDefault(x) + 1;
      inc[x - k] = inc.GetValueOrDefault(x - k) + 1;
      inc[x + k + 1] = inc.GetValueOrDefault(x + k + 1) - 1;
      p.Add(x);
      p.Add(x - k);
      p.Add(x + k + 1);
    }
    var s = 0;
    var result = 1;
    var sp = p.ToArray();
    sp.AsSpan().Sort();
    foreach (var x in sp)
    {
      s += inc.GetValueOrDefault(x);
      var count = cnt.GetValueOrDefault(x);
      var freq = count + Math.Min(numOperations, s - count);
      result = Math.Max(result, freq);
    }
    return result;
  }
}

public class SweepLineSolutionTests
{
  [TestCase(new[] { 1, 4, 5 }, 1, 2, 2)]
  [TestCase(new[] { 1, 4, 5 }, 0, 2, 1)]
  [TestCase(new[] { 1, 4, 5, 5 }, 0, 2, 2)]
  [TestCase(new[] { 1, 4, 5, 5 }, 1000, 0, 2)]
  [TestCase(new[] { 1, 4, 5, 6 }, 1000, 0, 1)]
  [TestCase(new[] { 5, 11, 20, 20 }, 5, 1, 2)]
  [TestCase(new[] { 5, 64 }, 42, 2, 2)]
  [TestCase(new[] { 25, 59 }, 39, 2, 2)]
  [TestCase(new[] { 1, 78, 70 }, 39, 3, 3)]
  [TestCase(new[] { 94, 10 }, 51, 1, 1)]
  [TestCase(new[] { 1, 2, 4, 5 }, 2, 4, 4)]
  [TestCase(new[] { 15, 113, 122, 102 }, 90, 3, 4)]
  public void Test1(int[] nums, int k, int numOperations, int expected)
  {
    new SweepLineSolution().MaxFrequency(nums, k, numOperations).Should().Be(expected);
  }
}
