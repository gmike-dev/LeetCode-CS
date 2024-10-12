namespace LeetCode.Strings._2213._Longest_Substring_of_One_Repeating_Character;

public class SegmentTreeSolution
{
  private class SegmentTreeNode
  {
    private readonly SegmentTreeNode leftNode;
    private readonly SegmentTreeNode rightNode;
    private readonly int left;
    private readonly int right;
    private readonly char[] s;
    private int prefixLength;
    private int suffixLength;
    private int longestContinues;

    private int Length => right - left + 1;

    public int GetLongestContinuesSegment() => longestContinues;

    public void ReplaceChar(int index, char value)
    {
      if (s[index] == value)
        return;

      if (left == right)
      {
        s[left] = value;
      }
      else
      {
        if (index <= leftNode.right)
          leftNode.ReplaceChar(index, value);
        else
          rightNode.ReplaceChar(index, value);
        UpdateLength();
      }
    }

    private void UpdateLength()
    {
      longestContinues = int.Max(leftNode.longestContinues, rightNode.longestContinues);
      prefixLength = leftNode.prefixLength;
      suffixLength = rightNode.suffixLength;
      if (s[leftNode.right] == s[rightNode.left])
      {
        longestContinues = int.Max(longestContinues, leftNode.suffixLength + rightNode.prefixLength);
        if (leftNode.suffixLength == leftNode.Length)
          prefixLength += rightNode.prefixLength;
        if (rightNode.prefixLength == rightNode.Length)
          suffixLength += leftNode.suffixLength;
      }
    }

    public SegmentTreeNode(char[] str, int l, int r)
    {
      s = str;
      left = l;
      right = r;
      if (left == right)
      {
        longestContinues = 1;
        prefixLength = 1;
        suffixLength = 1;
      }
      else
      {
        var m = left + (right - left) / 2;
        leftNode = new SegmentTreeNode(s, left, m);
        rightNode = new SegmentTreeNode(s, m + 1, right);
        UpdateLength();
      }
    }
  }

  public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
  {
    var t = new SegmentTreeNode(s.ToCharArray(), 0, s.Length - 1);
    var result = new int[queryIndices.Length];
    for (var i = 0; i < queryIndices.Length; i++)
    {
      t.ReplaceChar(queryIndices[i], queryCharacters[i]);
      result[i] = t.GetLongestContinuesSegment();
    }
    return result;
  }
}

[TestFixture]
public class SegmentTreeSolutionTests
{
  [TestCase("babacc", "bcb", new[] { 1, 3, 3 }, new[] { 3, 3, 4 })]
  [TestCase("abyzz", "aa", new[] { 2, 1 }, new[] { 2, 3 })]
  public void Test(string s, string queryCharacters, int[] queryIndices, int[] expected)
  {
    new SegmentTreeSolution().LongestRepeating(s, queryCharacters, queryIndices).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
