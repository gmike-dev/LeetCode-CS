using System.IO;

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
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "3508. Implement Router", "TestCases.txt");
        using var sr = new StreamReader(source);
        string[] commands = (sr.ReadLine() ?? throw new InvalidOperationException()).Split(",");
        int[][] args = (sr.ReadLine() ?? throw new InvalidOperationException()).Array2();
        var router = new Router(1000);
        for (int i = 0; i < commands.Length; i++)
        {
            string c = commands[i];
            int[] p = args[i];
            if (c == "addPacket")
            {
                (int s, int d, int t) = (p[0], p[1], p[2]);
                router.AddPacket(s, d, t);
            }
            else if (c == "getCount")
            {
                (int d, int s, int e) = (p[0], p[1], p[2]);
                router.GetCount(d, s, e);
            }
            else if (c == "forwardPacket")
            {
                router.ForwardPacket();
            }
        }
    }
}
