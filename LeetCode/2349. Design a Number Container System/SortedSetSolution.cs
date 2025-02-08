namespace LeetCode._2349._Design_a_Number_Container_System;

public class NumberContainers
{
  private readonly Dictionary<int, int> numberAtIndex = new();
  private readonly Dictionary<int, SortedSet<int>> indexes = new();

  public void Change(int index, int number)
  {
    if (numberAtIndex.TryGetValue(index, out var oldNumber))
    {
      if (oldNumber == number)
        return;
      indexes[oldNumber].Remove(index);
      if (indexes[oldNumber].Count == 0)
        indexes.Remove(oldNumber);
    }
    numberAtIndex[index] = number;
    if (indexes.TryGetValue(number, out var list))
      list.Add(index);
    else
      indexes[number] = [index];
  }

  public int Find(int number)
  {
    return indexes.TryGetValue(number, out var list) ? list.Min : -1;
  }
}

[TestFixture]
public class NumberContainersTests
{
  [Test]
  public void Test1()
  {
    var nc = new NumberContainers();
    nc.Find(10).Should().Be(-1);
    nc.Change(2, 10);
    nc.Change(1, 10);
    nc.Change(3, 10);
    nc.Change(5, 10);
    nc.Find(10).Should().Be(1);
    nc.Change(1, 20);
    nc.Find(10).Should().Be(2);
  }

  [Test]
  public void Test2()
  {
    var nc = new NumberContainers();
    nc.Change(1, 10);
    nc.Find(10).Should().Be(1);
    nc.Change(1, 20);
    nc.Find(10).Should().Be(-1);
    nc.Find(20).Should().Be(1);
    nc.Find(30).Should().Be(-1);
  }
}
