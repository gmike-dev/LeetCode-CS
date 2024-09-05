namespace LeetCode.__Strings._2213._Longest_Substring_of_One_Repeating_Character;

public class SegmentTreeOnArraySolution
{
  private class ArraySegmentTree
  {
    private readonly char[] s;
    private readonly int[] prefixLength;
    private readonly int[] suffixLength;
    private readonly int[] longestContinues;
    private readonly int n;

    public int GetLongestContinuousSegment()
    {
      return longestContinues[1];
    }

    public void ReplaceChar(int pos, char value)
    {
      ReplaceChar(1, 0, n - 1, pos, value);
    }

    private void ReplaceChar(int v, int tl, int tr, int pos, char value)
    {
      if (tl == tr)
      {
        s[tl] = value;
      }
      else
      {
        var tm = tl + (tr - tl) / 2;
        if (pos <= tm)
          ReplaceChar(v * 2, tl, tm, pos, value);
        else
          ReplaceChar(v * 2 + 1, tm + 1, tr, pos, value);
        UpdateLength(v, tl, tr, tm);
      }
    }

    private void Build(int v, int tl, int tr)
    {
      if (tl < tr)
      {
        var tm = tl + (tr - tl) / 2;
        if (tl < tm)
          Build(v * 2, tl, tm);
        if (tm + 1 < tr)
          Build(v * 2 + 1, tm + 1, tr);
        UpdateLength(v, tl, tr, tm);
      }
    }

    private void UpdateLength(int v, int tl, int tr, int tm)
    {
      var vl = 2 * v;
      var vr = 2 * v + 1;
      longestContinues[v] = int.Max(longestContinues[vl], longestContinues[vr]);
      prefixLength[v] = prefixLength[vl];
      suffixLength[v] = suffixLength[vr];
      if (s[tm] == s[tm + 1])
      {
        longestContinues[v] = int.Max(longestContinues[v], suffixLength[vl] + prefixLength[vr]);
        if (suffixLength[vl] == tm - tl + 1)
          prefixLength[v] += prefixLength[vr];
        if (prefixLength[vr] == tr - tm)
          suffixLength[v] += suffixLength[vl];
      }
    }

    public ArraySegmentTree(char[] data)
    {
      s = data;
      n = s.Length;
      prefixLength = new int[4 * n];
      suffixLength = new int[4 * n];
      longestContinues = new int[4 * n];
      Array.Fill(prefixLength, 1);
      Array.Fill(suffixLength, 1);
      Array.Fill(longestContinues, 1);
      Build(1, 0, n - 1);
    }
  }


  public int[] LongestRepeating(string s, string queryCharacters, int[] queryIndices)
  {
    var t = new ArraySegmentTree(s.ToCharArray());
    var result = new int[queryIndices.Length];
    for (var i = 0; i < queryIndices.Length; i++)
    {
      t.ReplaceChar(queryIndices[i], queryCharacters[i]);
      result[i] = t.GetLongestContinuousSegment();
    }
    return result;
  }
}

[TestFixture]
public class SegmentTreeOnArraySolutionTests
{
  [TestCase("babacc", "bcb", new[] { 1, 3, 3 }, new[] { 3, 3, 4 })]
  [TestCase("abyzz", "aa", new[] { 2, 1 }, new[] { 2, 3 })]
  public void Test(string s, string queryCharacters, int[] queryIndices, int[] expected)
  {
    new SegmentTreeOnArraySolution().LongestRepeating(s, queryCharacters, queryIndices).Should()
      .BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
