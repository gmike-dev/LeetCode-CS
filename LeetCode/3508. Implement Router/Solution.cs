namespace LeetCode._3508._Implement_Router;

public class Router(int memoryLimit)
{
  private readonly record struct Packet(int Source, int Destination, int Timestamp);

  private readonly Queue<Packet> queue = new(memoryLimit);
  private readonly HashSet<Packet> packets = new(memoryLimit);
  private readonly Dictionary<int, List<int>> timestamps = new();

  public bool AddPacket(int source, int destination, int timestamp)
  {
    var newPacket = new Packet(source, destination, timestamp);
    if (!packets.Add(newPacket))
      return false;

    if (timestamps.TryGetValue(destination, out var ts))
    {
      var index = ts.BinarySearch(timestamp);
      ts.Insert(index < 0 ? ~index : index, timestamp);
    }
    else
    {
      timestamps[destination] = [timestamp];
    }

    if (queue.Count == memoryLimit)
      RemoveFirstPacket();
    queue.Enqueue(newPacket);

    return true;
  }

  public int[] ForwardPacket()
  {
    if (queue.Count == 0)
      return [];
    var packet = RemoveFirstPacket();
    return [packet.Source, packet.Destination, packet.Timestamp];
  }

  public int GetCount(int destination, int startTime, int endTime)
  {
    if (!timestamps.TryGetValue(destination, out var ts) || ts.Count == 0)
      return 0;
    return UpperBound(ts, endTime) - LowerBound(ts, startTime);
  }

  private Packet RemoveFirstPacket()
  {
    var firstPacket = queue.Dequeue();
    packets.Remove(firstPacket);
    var ts = timestamps[firstPacket.Destination];
    ts.RemoveAt(ts.BinarySearch(firstPacket.Timestamp));
    return firstPacket;
  }

  private static int LowerBound(List<int> a, int value)
  {
    var (l, r) = (0, a.Count - 1);
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (value > a[m])
        l = m + 1;
      else
        r = m;
    }
    return a[l] < value ? r + 1 : l;
  }

  private static int UpperBound(List<int> a, int value)
  {
    var (l, r) = (0, a.Count - 1);
    while (l < r)
    {
      var m = l + (r - l) / 2;
      if (value < a[m])
        r = m;
      else
        l = m + 1;
    }
    return a[l] <= value ? r + 1 : l;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var router = new Router(3);
    router.AddPacket(1, 4, 90).Should().BeTrue();
    router.AddPacket(2, 5, 90).Should().BeTrue();
    router.AddPacket(1, 4, 90).Should().BeFalse();
    router.AddPacket(3, 5, 95).Should().BeTrue();
    router.AddPacket(4, 5, 105).Should().BeTrue();
    router.ForwardPacket().Should().BeEquivalentTo([2, 5, 90]);
    router.AddPacket(5, 2, 110).Should().BeTrue();
    router.GetCount(5, 100, 110).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    var router = new Router(2);
    router.AddPacket(7, 4, 90).Should().BeTrue();
    router.ForwardPacket().Should().BeEquivalentTo([7, 4, 90]);
    router.ForwardPacket().Should().BeEmpty();
  }

  [Test]
  public void Test69()
  {
    var router = new Router(2);
    router.AddPacket(2,5,1).Should().BeTrue();
    router.ForwardPacket().Should().BeEquivalentTo([2, 5, 1]);
    router.GetCount(5,1,1).Should().Be(0);
  }

  [Test]
  public void Test436()
  {
    var router = new Router(4);
    router.AddPacket(5, 4, 1).Should().BeTrue();
    router.AddPacket(3, 2, 1).Should().BeTrue();
    router.GetCount(4, 1, 1).Should().Be(1);
    router.GetCount(2, 1, 1).Should().Be(1);
    router.GetCount(4, 1, 1).Should().Be(1);
    router.AddPacket(1, 4, 1).Should().BeTrue();
    router.AddPacket(1, 3, 4).Should().BeTrue();
    router.GetCount(2, 1, 4).Should().Be(1);
    router.AddPacket(2, 4, 4).Should().BeTrue();
  }
}
