namespace LeetCode.Graphs._947._Most_Stones_Removed_with_Same_Row_or_Column;

public class Solution
{
  public int RemoveStones(int[][] stones)
  {
    Dictionary<int, int> firstStoneInRow = new();
    Dictionary<int, int> firstStoneInCol = new();
    var uf = new UnionFind(stones.Length + 1);
    for (var i = 0; i < stones.Length; i++)
    {
      if (!firstStoneInRow.TryAdd(stones[i][0], i))
        uf.Union(firstStoneInRow[stones[i][0]], i);
      if (!firstStoneInCol.TryAdd(stones[i][1], i))
        uf.Union(firstStoneInCol[stones[i][1]], i);
    }
    return stones.Length - uf.GetCount() + 1;
  }

  private class UnionFind
  {
    private readonly int[] parent;
    private readonly int[] size;
    private int count;

    public UnionFind(int n)
    {
      parent = new int[n];
      size = new int[n];
      for (var i = 0; i < n; i++)
        MakeSet(i);
    }

    public int GetCount() => count;

    public void Union(int x, int y)
    {
      x = Find(x);
      y = Find(y);
      if (x != y)
      {
        if (size[x] < size[y])
          (x, y) = (y, x);
        parent[y] = x; // Always add a smaller set to a larger set.
        size[x] += size[y];
        count--;
      }
    }

    private void MakeSet(int x)
    {
      parent[x] = x;
      size[x] = 1;
      count++;
    }

    private int Find(int x)
    {
      while (parent[x] != x)
      {
        parent[x] = parent[parent[x]];
        x = parent[x];
      }
      return x;
    }
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().RemoveStones([[0, 0], [0, 1], [1, 0], [1, 2], [2, 1], [2, 2]]).Should().Be(5);
  }

  [Test]
  public void Test2()
  {
    new Solution().RemoveStones([[0, 0], [0, 2], [1, 1], [2, 0], [2, 2]]).Should().Be(3);
  }

  [Test]
  public void Test3()
  {
    new Solution().RemoveStones([[0, 0]]).Should().Be(0);
  }

  [Test]
  public void Test4()
  {
    new Solution().RemoveStones([[0, 1], [1, 0]]).Should().Be(0);
  }

  [Test]
  public void Test5()
  {
    new Solution().RemoveStones([[1, 2], [1, 3], [3, 3], [3, 1], [2, 1], [1, 0]]).Should().Be(5);
  }
}
