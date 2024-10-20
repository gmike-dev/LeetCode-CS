namespace LeetCode.Graphs._3311._Construct_2D_Grid_Matching_Graph_Layout;

public class Solution
{
  public int[][] ConstructGridLayout(int n, int[][] edges)
  {
    var g = new List<int>[n];
    for (var i = 0; i < n; i++)
      g[i] = [];
    foreach (var e in edges)
    {
      g[e[0]].Add(e[1]);
      g[e[1]].Add(e[0]);
    }

    var oneConnected = Enumerable.Range(0, n).Where(x => g[x].Count == 1).ToArray();
    if (oneConnected.Length == 2) // Simple 1-row matrix
      return [ShortestPathToCorners(oneConnected[0], 1, 1)[0]];

    // Calculate the angles and size of the matrix
    // A...B
    // .....
    // D...C
    var a = Enumerable.Range(0, n).First(x => g[x].Count == 2);
    var paths = ShortestPathToCorners(a, 3, 2);
    var ab = paths[0];
    var ad = paths[1];

    var w = ab.Length;
    var h = ad.Length;
    var matrix = new int[h][];
    for (var i = 0; i < h; i++)
      matrix[i] = new int[w];

    // Build the first row and the first column
    for (var i = 0; i < w; i++)
      matrix[0][i] = ab[i];
    for (var i = 0; i < h; i++)
      matrix[i][0] = ad[i];

    // Complete the matrix
    for (var i = 0; i < n; i++)
      g[i].Sort();
    for (var i = 1; i < h; i++)
    {
      for (var j = 1; j < w; j++)
        matrix[i][j] = FindElement(i, j);
    }

    return matrix;

    int FindElement(int i, int j)
    {
      var a = g[matrix[i - 1][j]];
      var b = g[matrix[i][j - 1]];
      for (int l = 0, r = 0; l < a.Count && r < b.Count;)
      {
        if (a[l] < b[r])
          l++;
        else if (a[l] > b[r])
          r++;
        else
        {
          if (a[l] != matrix[i - 1][j - 1])
            return a[l];
          l++;
          r++;
        }
      }
      return -1;
    }

    int[][] ShortestPathToCorners(int from, int pathCount, int targetDegree)
    {
      var result = new int[pathCount][];
      var found = 0;
      var visited = new bool[n];
      var prev = new int[n];
      prev[from] = -1;
      var q = new Queue<int>();
      q.Enqueue(from);
      visited[from] = true;
      while (q.Count > 0)
      {
        var v = q.Dequeue();
        foreach (var next in g[v])
        {
          if (visited[next])
            continue;
          visited[next] = true;
          prev[next] = v;
          if (g[next].Count == targetDegree)
          {
            result[found++] = BuildPath(prev, next);
            if (found == pathCount)
              return result;
          }
          q.Enqueue(next);
        }
      }
      return result;
    }
  }


  int[] BuildPath(int[] prev, int v)
  {
    var path = new Stack<int>();
    while (prev[v] != -1)
    {
      path.Push(v);
      v = prev[v];
    }
    path.Push(v);
    return path.ToArray();
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test2()
  {
    int[][] expected =
    [
      [0, 1, 3, 2, 4]
    ];
    new Solution().ConstructGridLayout(5, [[0, 1], [1, 3], [2, 3], [2, 4]])
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    int[][] expected =
    [
      [0, 1]
    ];
    new Solution().ConstructGridLayout(2, [[0, 1]])
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    int[][] expected =
    [
      [1, 0, 5],
      [7, 4, 2],
      [8, 6, 3]
    ];
    new Solution().ConstructGridLayout(9,
        [[0, 1], [0, 4], [0, 5], [1, 7], [2, 3], [2, 4], [2, 5], [3, 6], [4, 6], [4, 7], [6, 8], [7, 8]])
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  [Repeat(1000)]
  public void Test5()
  {
    int[][] expected =
    [
      [1, 3],
      [0, 4],
      [2, 5]
    ];
    new Solution().ConstructGridLayout(9,
        [[0, 1], [0, 2], [0, 4], [1, 3], [2, 5], [3, 4], [4, 5]])
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test6()
  {
    int[][] expected =
    [
      [0, 1],
      [3, 2],
      [5, 4],
    ];
    new Solution().ConstructGridLayout(9,
        [[0, 1], [0, 3], [1, 2], [2, 3], [2, 4], [3, 5], [4, 5]])
      .Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
