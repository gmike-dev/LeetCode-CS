namespace LeetCode.Numbers._13._Roman_to_Integer;

public class Solution
{
  public int RomanToInt(string s)
  {
    var n = 0;
    var pp = 0;
    for (var i = s.Length - 1; i >= 0; i--)
    {
      var p = s[i] switch
      {
        'I' => 1,
        'V' => 5,
        'X' => 10,
        'L' => 50,
        'C' => 100,
        'D' => 500,
        'M' => 1000,
        _ => throw new ArgumentException()
      };
      if (p >= pp)
        n += p;
      else
        n -= p;
      pp = p;
    }
    return n;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    sln.RomanToInt("III").Should().Be(3);
    sln.RomanToInt("LVIII").Should().Be(58);
    sln.RomanToInt("MCMXCIV").Should().Be(1994);
  }
}
