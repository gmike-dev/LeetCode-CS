namespace LeetCode._2080._Range_Frequency_Queries;

public class BinarySearchRangeFreqQuery
{
  private readonly Dictionary<int, List<int>> positions = new();

  public BinarySearchRangeFreqQuery(int[] arr)
  {
    for (var i = 0; i < arr.Length; i++)
    {
      if (positions.TryGetValue(arr[i], out var list))
        list.Add(i);
      else
        positions.Add(arr[i], [i]);
    }
  }

  public int Query(int left, int right, int value)
  {
    if (!positions.TryGetValue(value, out var list))
      return 0;
    var lower = list.BinarySearch(left);
    if (lower < 0)
      lower = ~lower;
    var upper = list.BinarySearch(right);
    if (upper < 0)
      upper = ~upper;
    else
      upper++;
    return upper - lower;
  }
}

[TestFixture]
public class BinarySearchRangeFreqQueryTests
{
  [Test]
  public void Test1()
  {
    var rfq = new BinarySearchRangeFreqQuery([12, 33, 4, 56, 22, 2, 34, 33, 22, 12, 34, 56]);
    rfq.Query(1, 2, 4).Should().Be(1);
    rfq.Query(0, 11, 33).Should().Be(2);
    rfq.Query(0, 11, 2).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    var rfq = new BinarySearchRangeFreqQuery([2, 2, 1, 2, 2]);
    rfq.Query(2, 4, 1).Should().Be(1);
    rfq.Query(1, 3, 1).Should().Be(1);
    rfq.Query(0, 2, 1).Should().Be(1);
  }
}
