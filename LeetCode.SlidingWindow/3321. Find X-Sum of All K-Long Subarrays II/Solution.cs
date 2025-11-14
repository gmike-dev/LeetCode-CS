using System.IO;
using LeetCode.Common;

namespace LeetCode.SlidingWindow._3321._Find_X_Sum_of_All_K_Long_Subarrays_II;

public class Solution
{
  private readonly struct Item(int freq, int val) : IComparable<Item>
  {
    public readonly int freq = freq;
    public readonly int val = val;

    public int CompareTo(Item other)
    {
      var cmp = freq - other.freq;
      if (cmp != 0)
        return cmp;
      return val - other.val;
    }
  }

  public long[] FindXSum(int[] nums, int k, int x)
  {
    var s1 = new SortedSet<Item>();
    var s2 = new SortedSet<Item>();
    var large = new HashSet<int>();
    var small = new HashSet<int>();
    var sum = 0L;
    var freq = new Dictionary<int, int>();
    var n = nums.Length;
    var answer = new long[n - k + 1];
    for (var i = 0; i < n; i++)
    {
      var current = nums[i];
      freq[current] = freq.GetValueOrDefault(current) + 1;
      if (large.Contains(current))
      {
        s1.Remove(new Item(freq[current] - 1, current));
        s1.Add(new Item(freq[current], current));
        sum += current;
      }
      else
      {
        if (!small.Add(current))
        {
          s2.Remove(new Item(freq[current] - 1, current));
        }
        s2.Add(new Item(freq[current], current));
        if (s1.Count < x)
        {
          var s2Max = s2.Max;
          small.Remove(s2Max.val);
          large.Add(s2Max.val);
          s2.Remove(s2Max);
          s1.Add(s2Max);
          sum += (long)s2Max.val * s2Max.freq;
        }
        else
        {
          var s1Min = s1.Min;
          var s2Max = s2.Max;
          if (s2Max.CompareTo(s1Min) > 0)
          {
            large.Remove(s1Min.val);
            large.Add(s2Max.val);
            small.Remove(s2Max.val);
            small.Add(s1Min.val);
            s1.Remove(s1Min);
            s1.Add(s2Max);
            s2.Remove(s2Max);
            s2.Add(s1Min);
            sum -= (long)s1Min.val * s1Min.freq;
            sum += (long)s2Max.val * s2Max.freq;
          }
        }
      }

      if (i < k - 1)
        continue;

      answer[i - k + 1] = sum;

      var prev = nums[i - k + 1];
      freq[prev]--;

      if (large.Contains(prev))
      {
        s1.Remove(new Item(freq[prev] + 1, prev));
        s1.Add(new Item(freq[prev], prev));
        sum -= prev;
        var s1Min = s1.Min;
        var s2Max = s2.Max;
        if (s2Max.CompareTo(s1Min) > 0)
        {
          large.Remove(s1Min.val);
          large.Add(s2Max.val);
          small.Remove(s2Max.val);
          small.Add(s1Min.val);
          s1.Remove(s1Min);
          s1.Add(s2Max);
          s2.Remove(s2Max);
          s2.Add(s1Min);
          sum -= (long)s1Min.val * s1Min.freq;
          sum += (long)s2Max.val * s2Max.freq;
        }
      }
      else
      {
        s2.Remove(new Item(freq[prev] + 1, prev));
        s2.Add(new Item(freq[prev], prev));
      }
    }
    return answer;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,1,2,2,3,4,2,3]", 6, 2, "[6,10,12]")]
  [TestCase("[3,8,7,8,7,5]", 2, 2, "[11,15,15,15,12]")]
  [TestCase("[4,4,4,10]", 2, 1, "[8,8,10]")]
  public void Test(string nums, int k, int x, string expected)
  {
    var actual = new Solution().FindXSum(nums.Array(), k, x);
    actual.String().Should().BeEquivalentTo(expected);
  }

  [Test]
  public void TestLarge()
  {
    var source = Path.Join(TestContext.CurrentContext.WorkDirectory, "3321. Find X-Sum of All K-Long Subarrays II",
      "TestCases.txt");
    using var sr = new StreamReader(source);
    while (!sr.EndOfStream)
    {
      var rains = sr.ReadLine();
      var k = int.Parse(sr.ReadLine());
      var x = int.Parse(sr.ReadLine());
      var expected = sr.ReadLine();
      var actual = new Solution().FindXSum(rains.Array(), k, x);
      actual.String().Should().BeEquivalentTo(expected);
    }
  }
}
