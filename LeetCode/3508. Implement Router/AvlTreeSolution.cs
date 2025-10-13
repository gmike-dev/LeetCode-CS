using LeetCode.Common;

namespace LeetCode._3508._Implement_Router.AvlTreeSolution;

public class Router(int memoryLimit)
{
  private readonly record struct Packet(int Source, int Destination, int Timestamp);

  private readonly Queue<Packet> queue = new(memoryLimit);
  private readonly HashSet<Packet> packets = new(memoryLimit);
  private readonly Dictionary<int, AvlTree> timestamps = new();

  public bool AddPacket(int source, int destination, int timestamp)
  {
    var newPacket = new Packet(source, destination, timestamp);
    if (!packets.Add(newPacket))
      return false;

    if (!timestamps.TryGetValue(destination, out var ts))
    {
      ts = new AvlTree();
      timestamps[destination] = ts;
    }
    ts.Insert(timestamp);

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
    if (!timestamps.TryGetValue(destination, out var ts))
      return 0;
    return ts.GetCountBetween(startTime, endTime);
  }

  private Packet RemoveFirstPacket()
  {
    var firstPacket = queue.Dequeue();
    packets.Remove(firstPacket);
    var ts = timestamps[firstPacket.Destination];
    ts.Delete(firstPacket.Timestamp);
    return firstPacket;
  }
}

public class AvlTree
{
  private AvlNode root;

  public void Insert(int key) => root = Insert(root, key);

  public void Delete(int key) => root = Delete(root, key);

  public bool Contains(int key) => Contains(root, key);

  public int GetCountBetween(int minKey, int maxKey) => GetCountBetween(root, minKey, maxKey);

  public static int GetCountBetween(AvlNode node, int minKey, int maxKey)
  {
    if (node == null || node.Max < minKey || maxKey < node.Min)
      return 0;
    if (maxKey < node.Key)
      return GetCountBetween(node.Left, minKey, maxKey);
    if (node.Key < minKey)
      return GetCountBetween(node.Right, minKey, maxKey);
    if (minKey <= node.Min && node.Max <= maxKey)
      return node.Size;
    var count = 1;
    if (minKey <= node.Key)
      count += GetCountBetween(node.Left, minKey, node.Key);
    if (node.Key <= maxKey)
      count += GetCountBetween(node.Right, node.Key, maxKey);
    return count;
  }

  private static int GetHeight(AvlNode node) => node?.Height ?? 0;

  private static int GetBalance(AvlNode node) => node == null ? 0 : GetHeight(node.Left) - GetHeight(node.Right);

  private static void UpdateHeight(AvlNode node)
  {
    if (node != null)
      node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
  }

  private static AvlNode RightRotate(AvlNode node)
  {
    var left = node.Left;
    if (left == null)
      return node;

    node.Size -= left.Size;
    node.Size += left.Right?.Size ?? 0;
    left.Size -= left.Right?.Size ?? 0;
    left.Size += node.Size;
    node.Min = left.Right?.Min ?? node.Key;
    left.Max = node.Max;

    (left.Right, node.Left) = (node, left.Right);
    UpdateHeight(node);
    UpdateHeight(left);
    return left;
  }

  private static AvlNode LeftRotate(AvlNode node)
  {
    var right = node.Right;
    if (right == null)
      return node;

    node.Size -= right.Size;
    node.Size += right.Left?.Size ?? 0;
    right.Size -= right.Left?.Size ?? 0;
    right.Size += node.Size;
    node.Max = right.Left?.Max ?? node.Key;
    right.Min = node.Min;

    (right.Left, node.Right) = (node, right.Left);
    UpdateHeight(node);
    UpdateHeight(right);
    return right;
  }

  private static AvlNode Insert(AvlNode node, int key)
  {
    if (node == null)
      return new AvlNode(key);

    var cmp = key.CompareTo(node.Key);
    if (cmp <= 0)
    {
      node.Left = Insert(node.Left, key);
      node.Size++;
      node.Min = node.Left.Min;
    }
    else
    {
      node.Right = Insert(node.Right, key);
      node.Size++;
      node.Max = node.Right.Max;
    }

    UpdateHeight(node);

    switch (GetBalance(node))
    {
      case > 1 when key.CompareTo(node.Left.Key) < 0:
        return RightRotate(node);
      case < -1 when key.CompareTo(node.Right.Key) > 0:
        return LeftRotate(node);
      case > 1 when key.CompareTo(node.Left.Key) > 0:
        node.Left = LeftRotate(node.Left);
        return RightRotate(node);
      case < -1 when key.CompareTo(node.Right.Key) < 0:
        node.Right = RightRotate(node.Right);
        return LeftRotate(node);
      default:
        return node;
    }
  }

  private static AvlNode FindMinNode(AvlNode node)
  {
    var current = node;
    while (current.Left != null)
      current = current.Left;
    return current;
  }

  private static AvlNode Delete(AvlNode node, int key)
  {
    if (node == null)
      return null;

    var cmp = key.CompareTo(node.Key);
    if (cmp < 0)
    {
      node.Left = Delete(node.Left, key);
      node.Size--;
      node.Min = node.Left?.Min ?? node.Key;
    }
    else if (cmp > 0)
    {
      node.Right = Delete(node.Right, key);
      node.Size--;
      node.Max = node.Right?.Max ?? node.Key;
    }
    else
    {
      if (node.Left != null && node.Right != null)
      {
        var minNode = FindMinNode(node.Right);
        node.Key = minNode.Key;
        node.Right = Delete(node.Right, minNode.Key);
        node.Size = node.Left.Size + (node.Right?.Size ?? 0) + 1;
      }
      else
      {
        node = node.Left ?? node.Right;
      }
    }

    if (node == null)
      return null;

    UpdateHeight(node);

    switch (GetBalance(node))
    {
      case > 1 when GetBalance(node.Left) >= 0:
        return RightRotate(node);
      case > 1 when GetBalance(node.Left) < 0:
        node.Left = LeftRotate(node.Left);
        return RightRotate(node);
      case < -1 when GetBalance(node.Right) <= 0:
        return LeftRotate(node);
      case < -1 when GetBalance(node.Right) > 0:
        node.Right = RightRotate(node.Right);
        return LeftRotate(node);
      default:
        return node;
    }
  }

  private static bool Contains(AvlNode node, int key)
  {
    if (node == null)
      return false;

    return key.CompareTo(node.Key) switch
    {
      0 => true,
      < 0 => Contains(node.Left, key),
      _ => Contains(node.Right, key)
    };
  }
}

public class AvlNode(int key)
{
  public int Key { get; set; } = key;
  public AvlNode Left { get; set; }
  public AvlNode Right { get; set; }
  public int Height { get; set; } = 1;
  public int Size { get; set; } = 1;
  public int Min { get; set; } = key;
  public int Max { get; set; } = key;
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
    router.AddPacket(2, 5, 1).Should().BeTrue();
    router.ForwardPacket().Should().BeEquivalentTo([2, 5, 1]);
    router.GetCount(5, 1, 1).Should().Be(0);
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

  [Test]
  public void Test645()
  {
    var commands = new string[]
    {
      "addPacket", "getCount", "addPacket", "getCount", "getCount", "forwardPacket", "addPacket", "addPacket",
      "addPacket", "addPacket", "forwardPacket", "addPacket", "addPacket", "addPacket", "forwardPacket",
      "forwardPacket", "addPacket", "addPacket", "getCount", "getCount", "getCount", "forwardPacket", "getCount",
      "getCount", "forwardPacket", "getCount", "forwardPacket", "addPacket", "getCount", "getCount", "getCount",
      "addPacket", "addPacket", "getCount", "getCount", "getCount", "forwardPacket", "forwardPacket", "addPacket",
      "addPacket", "addPacket", "addPacket", "getCount", "addPacket", "addPacket", "addPacket", "forwardPacket",
      "forwardPacket", "getCount", "addPacket", "forwardPacket", "addPacket", "getCount", "forwardPacket", "addPacket",
      "addPacket", "getCount", "getCount", "addPacket", "getCount", "addPacket", "forwardPacket", "addPacket",
      "addPacket", "getCount", "addPacket", "getCount", "getCount", "getCount", "getCount", "getCount", "addPacket",
      "getCount", "getCount", "addPacket", "getCount", "getCount", "getCount", "addPacket", "addPacket",
      "forwardPacket", "forwardPacket", "forwardPacket", "forwardPacket", "forwardPacket", "addPacket", "forwardPacket",
      "forwardPacket", "addPacket", "addPacket", "getCount", "addPacket", "addPacket", "forwardPacket", "addPacket",
      "addPacket", "addPacket", "getCount", "getCount", "addPacket", "addPacket", "getCount", "addPacket", "getCount",
      "forwardPacket", "getCount", "getCount", "getCount", "addPacket", "getCount", "getCount", "forwardPacket",
      "getCount", "addPacket", "addPacket", "getCount", "addPacket", "getCount", "getCount", "addPacket", "getCount",
      "getCount", "forwardPacket", "getCount", "getCount", "forwardPacket", "addPacket", "addPacket", "forwardPacket",
      "addPacket", "addPacket", "addPacket", "getCount", "addPacket", "forwardPacket", "getCount", "getCount",
      "addPacket", "getCount", "addPacket", "addPacket", "addPacket", "addPacket", "addPacket", "addPacket",
      "addPacket", "addPacket", "forwardPacket", "addPacket", "addPacket", "addPacket", "forwardPacket", "addPacket",
      "forwardPacket", "forwardPacket", "addPacket", "getCount", "forwardPacket", "addPacket", "getCount", "getCount",
      "addPacket", "getCount", "forwardPacket", "getCount", "getCount", "addPacket", "addPacket", "forwardPacket",
      "getCount", "addPacket", "addPacket", "forwardPacket", "getCount", "addPacket", "addPacket", "getCount",
      "addPacket", "getCount", "addPacket", "forwardPacket", "addPacket", "addPacket", "getCount", "getCount",
      "addPacket", "forwardPacket", "getCount", "forwardPacket", "addPacket", "getCount", "addPacket", "addPacket",
      "forwardPacket", "addPacket", "addPacket", "forwardPacket", "addPacket", "addPacket", "getCount", "getCount",
      "addPacket", "addPacket", "addPacket", "getCount", "getCount", "getCount", "forwardPacket", "addPacket",
      "addPacket", "getCount", "getCount", "getCount", "addPacket", "addPacket", "forwardPacket", "getCount",
      "getCount", "addPacket", "addPacket", "forwardPacket", "getCount", "getCount", "forwardPacket", "addPacket",
      "forwardPacket", "forwardPacket", "getCount", "forwardPacket", "forwardPacket", "addPacket", "getCount",
      "getCount", "getCount", "addPacket", "getCount", "addPacket", "getCount", "getCount", "forwardPacket", "getCount",
      "addPacket", "addPacket", "getCount", "getCount", "getCount", "addPacket", "addPacket", "forwardPacket",
      "forwardPacket", "addPacket", "addPacket", "addPacket", "addPacket", "addPacket", "addPacket", "forwardPacket",
      "forwardPacket", "forwardPacket", "addPacket", "getCount", "getCount", "getCount", "forwardPacket", "addPacket",
      "getCount", "addPacket", "getCount", "getCount", "addPacket", "forwardPacket", "getCount", "addPacket",
      "addPacket", "forwardPacket", "addPacket", "getCount", "addPacket", "addPacket", "getCount", "getCount",
      "addPacket", "getCount", "forwardPacket", "addPacket", "addPacket", "addPacket", "getCount", "addPacket",
      "addPacket", "forwardPacket", "getCount", "addPacket", "addPacket", "getCount", "addPacket", "getCount"
    };
    var args = ("[[5,11,2],[11,1,1],[8,1,2],[11,1,1],[11,2,2],[],[1,6,3],[4,8,3],[12,8,3],[2,10,3],[]," +
                "[10,9,3],[10,8,7],[1,10,7],[],[],[4,9,8],[2,7,10],[1,5,7],[6,8,10],[6,1,2],[],[6,5,10],[8,1,7]," +
                "[],[9,9,9],[],[12,4,10],[9,3,8],[1,8,10],[4,4,10],[11,7,11],[1,7,16],[9,1,10],[8,4,16],[1,7,14]," +
                "[],[],[9,7,16],[6,8,16],[6,4,16],[3,10,16],[4,3,9],[7,6,17],[7,4,18],[4,11,19],[],[],[6,14,19]," +
                "[7,2,19],[],[12,6,20],[2,10,20],[],[9,6,20],[7,12,20],[12,14,19],[8,15,18],[6,4,21],[8,6,21]," +
                "[3,6,21],[],[10,12,21],[4,6,21],[4,11,13],[2,6,25],[9,7,19],[10,3,9],[7,2,2],[2,22,25],[8,16,24]," +
                "[11,1,25],[10,2,9],[10,21,23],[2,12,25],[6,21,24],[10,17,21],[2,11,13],[7,12,25],[10,1,25],[],[]," +
                "[],[],[],[12,8,27],[],[],[9,1,32],[3,12,32],[6,16,27],[11,4,35],[4,5,35],[],[5,3,35],[7,3,35]," +
                "[3,1,39],[3,37,39],[1,39,39],[11,8,39],[3,12,39],[6,37,38],[3,9,42],[3,30,42],[],[1,39,39],[7,18,28]," +
                "[6,11,37],[1,10,42],[3,15,22],[8,9,27],[],[2,22,22],[10,11,45],[4,5,45],[8,30,37],[10,2,45],[6,36,39]," +
                "[10,28,32],[7,8,45],[2,35,35],[7,33,33],[],[7,30,35],[9,2,11],[],[7,1,45],[1,2,45],[],[1,6,45]," +
                "[2,12,45],[1,8,45],[10,4,17],[12,2,45],[],[7,20,33],[11,30,42],[5,8,45],[5,10,27],[4,12,48]," +
                "[2,4,48],[11,8,48],[12,3,48],[3,8,48],[6,10,48],[6,8,48],[6,8,48],[],[11,5,48],[2,10,48]," +
                "[10,2,53],[],[10,8,53],[],[],[12,7,53],[2,51,53],[],[12,8,56],[9,49,52],[8,53,54],[3,11,61]," +
                "[8,35,54],[],[3,34,47],[8,54,54],[5,3,61],[7,10,61],[],[12,48,53],[2,5,61],[4,7,61],[],[1,44,47]," +
                "[10,11,61],[12,7,61],[11,39,41],[12,11,61],[7,41,47],[5,10,61],[],[12,8,61],[1,11,61],[5,51,55]," +
                "[11,55,57],[2,11,61],[],[7,21,54],[],[5,3,61],[3,9,33],[10,11,61],[11,2,63],[],[6,3,65],[3,7,65],[]," +
                "[9,6,68],[6,1,68],[9,18,34],[2,55,65],[5,4,68],[5,12,68],[3,5,73],[8,11,45],[10,48,54],[4,38,49],[]," +
                "[3,11,73],[8,4,73],[12,39,57],[12,23,45],[6,64,72],[6,1,76],[6,2,76],[],[9,24,75],[7,20,42]," +
                "[7,1,76],[10,3,76],[],[3,75,75],[4,6,74],[],[7,12,80],[],[],[11,57,58],[],[],[10,8,80],[12,70,79]," +
                "[1,25,70],[4,38,48],[8,11,82],[5,80,81],[2,9,82],[12,68,75],[10,57,68],[],[5,9,30],[4,8,82],[9,6,85]," +
                "[8,37,75],[11,15,74],[12,70,77],[5,4,85],[1,7,85],[],[],[10,11,85],[4,8,87],[4,1,88],[10,6,88]," +
                "[4,1,88],[4,8,88],[],[],[],[8,3,92],[5,57,86],[1,55,90],[12,61,73],[],[4,3,92],[2,92,92],[12,5,95]," +
                "[2,91,91],[8,37,39],[7,9,95],[],[9,72,77],[6,5,95],[2,5,95],[],[3,2,95],[12,73,94],[3,9,98]," +
                "[3,1,98],[6,86,97],[2,74,81],[4,12,101],[4,53,83],[],[6,5,101],[4,9,101],[1,7,103],[5,21,25]," +
                "[1,11,103],[4,3,103],[],[10,62,99],[1,11,103],[2,9,108],[7,51,95],[5,1,108],[3,75,85]]").Array2();
    var router = new Router(1000);
    for (var i = 0; i < commands.Length; i++)
    {
      var c = commands[i];
      var p = args[i];
      if (c == "addPacket")
      {
        var (s, d, t) = (p[0], p[1], p[2]);
        router.AddPacket(s, d, t);
      }
      else if (c == "getCount")
      {
        var (d, s, e) = (p[0], p[1], p[2]);
        router.GetCount(d, s, e);
      }
      else if (c == "forwardPacket")
      {
        router.ForwardPacket();
      }
    }
  }
}
