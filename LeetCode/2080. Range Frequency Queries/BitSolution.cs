namespace LeetCode._2080._Range_Frequency_Queries;

public class BitRangeFreqQuery(int[] arr)
{
  private readonly Bit t = new(arr);

  public int Query(int left, int right, int value)
  {
    return t.Query(left, right, value);
  }

  private class Bit
  {
    private readonly Dictionary<int, int>[] bit;

    public Bit(int[] arr)
    {
      bit = new Dictionary<int, int>[arr.Length + 1];
      for (var i = 0; i < bit.Length; i++)
        bit[i] = new Dictionary<int, int>();
      for (var i = 0; i < arr.Length; i++)
        Set(i, arr[i]);
    }

    public int Query(int left, int right, int value)
    {
      return Query(right, value) - Query(left - 1, value);
    }

    private int Query(int i, int value)
    {
      var count = 0;
      // Bit is 1-indexed.
      for (i++; i > 0; i -= i & -i)
        count += bit[i].GetValueOrDefault(value);
      return count;
    }

    private void Set(int i, int value)
    {
      // Bit is 1-indexed.
      for (i++; i < bit.Length; i += i & -i)
        bit[i][value] = bit[i].GetValueOrDefault(value) + 1;
    }
  }
}

[TestFixture]
public class BitRangeFreqQueryTests
{
  [Test]
  public void Test1()
  {
    var rfq = new BitRangeFreqQuery([12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56]);
    rfq.Query(1, 2, 4).Should().Be(1);
    rfq.Query(0, 11, 33).Should().Be(2);
    rfq.Query(0, 11, 2).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    var rfq = new BitRangeFreqQuery([2, 2, 1, 2, 2]);
    rfq.Query(2, 4, 1).Should().Be(1);
    rfq.Query(1, 3, 1).Should().Be(1);
    rfq.Query(0, 2, 1).Should().Be(1);
  }
}
