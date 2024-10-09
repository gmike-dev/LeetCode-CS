namespace LeetCode._295._Find_Median_from_Data_Stream;

public class MedianFinderList
{
  private readonly List<int> sorted = [];

  public void AddNum(int num)
  {
    var pos = sorted.BinarySearch(num);
    if (pos < 0)
      pos = ~pos;
    sorted.Insert(pos, num);
  }

  public double FindMedian()
  {
    if (sorted.Count % 2 == 0)
      return (sorted[sorted.Count / 2 - 1] + sorted[sorted.Count / 2]) / 2.0;
    return sorted[sorted.Count / 2];
  }
}

[TestFixture]
public class ListSolutionTests
{
  [Test]
  public void Test1()
  {
    var medianFinder = new MedianFinderList();
    medianFinder.AddNum(1); // arr = [1]
    medianFinder.AddNum(2); // arr = [1, 2]
    medianFinder.FindMedian().Should().Be(1.5); // return 1.5 (i.e., (1 + 2) / 2)
    medianFinder.AddNum(3); // arr[1, 2, 3]
    medianFinder.FindMedian().Should().Be(2.0); // return 2.0
  }
}
