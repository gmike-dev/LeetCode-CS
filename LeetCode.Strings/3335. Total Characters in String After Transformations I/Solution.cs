namespace LeetCode.Strings._3335._Total_Characters_in_String_After_Transformations_I;

public class Solution
{
  public int LengthAfterTransformations(string s, int t)
  {
    const int mod = (int)1e9 + 7;
    var count = new int[26];
    foreach (var c in s)
      count[c - 'a']++;
    var z = 25; // position of 'z'
    for (var i = 0; i < t; i++)
    {
      var countZ = count[z];
      count[z] = 0;
      z = (z + 25) % 26; // shift array left
      var a = (z + 1) % 26; // new position of 'a'
      var b = (z + 2) % 26; // new position of 'b'
      count[a] = (count[a] + countZ) % mod;
      count[b] = (count[b] + countZ) % mod;
    }
    return count.Aggregate((x, y) => (x + y) % mod);
  }
}

[TestFixture]
public class Tests
{
  [TestCase("abcyy", 2, 7)]
  [TestCase("azbk", 1, 5)]
  [TestCase("zcw", 4, 5)]
  [TestCase("jqktcurgdvlibczdsvnsg", 7517, 79033769)]
  public void Test1(string s, int t, int expected)
  {
    new Solution().LengthAfterTransformations(s, t).Should().Be(expected);
  }
}
