using LeetCode.Common;

namespace LeetCode.Numbers._421._Maximum_XOR_of_Two_Numbers_in_an_Array;

public class TrieSolution
{
  private class Trie
  {
    public readonly Trie[] next = new Trie[2];
  }

  public int FindMaximumXOR(int[] nums)
  {
    Trie root = new();
    foreach (int num in nums)
    {
      Add(num);
    }
    int maxXor = 0;
    foreach (int num in nums)
    {
      int other = Find(num);
      maxXor = Math.Max(maxXor, num ^ other);
    }
    return maxXor;

    void Add(int x)
    {
      Trie node = root;
      for (int i = 31; i >= 0; i--)
      {
        int bit = (x >> i) & 1;
        node = node.next[bit] ??= new Trie();
      }
    }

    int Find(int x)
    {
      int y = 0;
      Trie node = root;
      for (int i = 31; i >= 0; i--)
      {
        int bit = (x >> i) & 1;
        if (node.next[1 - bit] != null)
        {
          y |= ((1 - bit) << i);
          node = node.next[1 - bit];
        }
        else
        {
          y |= (bit << i);
          node = node.next[bit];
        }
      }
      return y;
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[3,10,5,25,2,8]", 28)]
  [TestCase("[14,70,53,83,49,91,36,80,92,51,66,70]", 127)]
  public void Test(string nums, int expected)
  {
    new TrieSolution().FindMaximumXOR(nums.Array()).Should().Be(expected);
  }
}
