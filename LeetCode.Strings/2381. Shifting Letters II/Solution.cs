namespace LeetCode.Strings._2381._Shifting_Letters_II;

public class Solution
{
  public string ShiftingLetters(string s, int[][] shifts)
  {
    var n = s.Length;
    Span<int> cnt = stackalloc int[n + 1];
    foreach (var shift in shifts)
    {
      var (start, end, direction) = (shift[0], shift[1], shift[2]);
      var d = 2 * direction - 1; // direction == 0 ? -1 : 1
      cnt[start] += d;
      cnt[end + 1] -= d;
    }
    Span<char> result = stackalloc char[n];
    var balance = 0;
    for (var i = 0; i < n; i++)
    {
      balance += cnt[i];
      result[i] = (char)('a' + (26 + s[i] - 'a' + balance % 26) % 26);
    }
    return new string(result);
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().ShiftingLetters("abc", [[0, 1, 0], [1, 2, 1], [0, 2, 1]]).Should().Be("ace");
  }

  [Test]
  public void Test2()
  {
    new Solution().ShiftingLetters("dztz", [[0, 0, 0], [1, 1, 1]]).Should().Be("catz");
  }

  [Test]
  public void Test3()
  {
    new Solution().ShiftingLetters("a", [
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
      [0, 0, 0],
    ]).Should().Be("y");
  }
}
