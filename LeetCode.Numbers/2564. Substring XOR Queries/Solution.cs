namespace LeetCode.Numbers._2564._Substring_XOR_Queries;

public class Solution
{
  public int[][] SubstringXorQueries(string s, int[][] queries)
  {
    var d = new Dictionary<int, (int left, int right)>();
    for (var i = 0; i < s.Length; i++)
    {
      if (s[i] == '0')
      {
        d.TryAdd(0, (i, i));
        continue;
      }
      var xor = 0;
      for (var j = i; j < s.Length && j - i < 30; j++)
      {
        xor = (xor << 1) | (s[j] - '0');
        d.TryAdd(xor, (i, j));
      }
    }
    var result = new int[queries.Length][];
    for (var i = 0; i < queries.Length; i++)
    {
      if (d.TryGetValue(queries[i][0] ^ queries[i][1], out var item))
        result[i] = [item.left, item.right];
      else
        result[i] = [-1, -1];
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().SubstringXorQueries("101101", [[0, 5], [1, 2]])
      .Should()
      .BeEquivalentTo((int[][]) [[0, 2], [2, 3]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    new Solution().SubstringXorQueries("0101", [[12, 8]])
      .Should()
      .BeEquivalentTo((int[][]) [[-1, -1]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test3()
  {
    new Solution().SubstringXorQueries("1", [[4, 5]])
      .Should()
      .BeEquivalentTo((int[][]) [[0, 0]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test4()
  {
    new Solution().SubstringXorQueries("111010110",
      [
        [4, 2], [3, 3], [6, 4], [9, 9], [10, 28], [0, 470], [5, 83], [10, 28], [8, 15], [6, 464], [0, 3], [5, 8],
        [7, 7], [8, 8], [6, 208], [9, 15], [2, 2], [9, 95]
      ])
      .Should()
      .BeEquivalentTo(
        (int[][])
        [
          [1, 3], [3, 3], [2, 3], [3, 3], [4, 8], [0, 8], [2, 8], [4, 8], [0, 2], [0, 8], [0, 1], [1, 4], [3, 3],
          [3, 3], [1, 8], [1, 3], [3, 3], [2, 8]
        ], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test5()
  {
    new Solution().SubstringXorQueries("0000001111101001010",
        [[0, 3914], [2, 4], [2, 2], [3, 8009], [4, 3918], [7, 26]])
      .Should()
      .BeEquivalentTo((int[][]) [[7, 18], [9, 11], [0, 0], [6, 18], [7, 18], [8, 12]], o => o.WithStrictOrdering());
  }

  [Test]
  public void Test6()
  {
    new Solution().SubstringXorQueries("111011100110101100101000000000",
        [[0, 1000000000]])
      .Should()
      .BeEquivalentTo((int[][]) [[0, 29]], o => o.WithStrictOrdering());
  }
}
