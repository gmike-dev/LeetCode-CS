namespace LeetCode.Strings._386._Lexicographical_Numbers;

public class BucketSolution
{
  public IList<int> LexicalOrder(int n)
  {
    var result = new int[n];
    for (var i = 0; i < n; i++)
      result[i] = i + 1;
    var maxDigits = DigitCount(n);
    for (var k = 0; k < maxDigits; k++)
    {
      var buckets = new List<int>[10];
      foreach (var num in result)
      {
        var d = KthDigit(num, maxDigits, k);
        (buckets[d] ??= []).Add(num);
      }
      var i = 0;
      foreach (var bucket in buckets)
      {
        if (bucket == null)
          continue;
        foreach (var num in bucket)
          result[i++] = num;
      }
    }
    return result;
  }

  private static int KthDigit(int n, int maxDigits, int k)
  {
    var s = new Stack<int>();
    while (n > 0)
    {
      s.Push(n % 10);
      n /= 10;
    }
    if (maxDigits - k > s.Count)
      return 0;
    for (var i = 0; i < maxDigits - k - 1; i++)
      s.Pop();
    return s.Peek();
  }

  private static int DigitCount(int n)
  {
    var digits = 0;
    while (n > 0)
    {
      digits++;
      n /= 10;
    }
    return digits;
  }
}

[TestFixture]
public class BucketSolutionTests
{
  [TestCase(13, new[] { 1, 10, 11, 12, 13, 2, 3, 4, 5, 6, 7, 8, 9 })]
  [TestCase(2, new[] { 1, 2 })]
  public void Test(int n, int[] expected)
  {
    new BucketSolution().LexicalOrder(n).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
