namespace LeetCode.Numbers._401._Binary_Watch;

public class GosperHackSolution
{
  public IList<string> ReadBinaryWatch(int k)
  {
    if (k == 0)
    {
      return ["0:00"];
    }
    if (k > 8)
    {
      return [];
    }
    var result = new List<string>();
    var mask = (1 << k) - 1;
    const int limit = 1 << 10;
    while (mask < limit)
    {
      var h = (mask & 0x3C0) >> 6;
      var m = mask & 0x3F;
      if (h < 12 && m < 60)
      {
        result.Add($"{h}:{m:D2}");
      }
      mask = NextCombination(mask);
    }
    return result;
  }

  private static int NextCombination(int mask)
  {
    var c = mask & -mask;
    var r = mask + c;
    return (((r ^ mask) >> 2) / c) | r;
  }
}

[TestFixture]
public class GosperHackSolutionTests
{
  [TestCase(1, new[] { "0:01", "0:02", "0:04", "0:08", "0:16", "0:32", "1:00", "2:00", "4:00", "8:00" })]
  [TestCase(9, new string[] { })]
  [TestCase(0, new[] { "0:00" })]
  [TestCase(2,
    new[]
    {
      "0:03", "0:05", "0:06", "0:09", "0:10", "0:12", "0:17", "0:18", "0:20", "0:24", "0:33", "0:34", "0:36", "0:40",
      "0:48", "1:01", "1:02", "1:04", "1:08", "1:16", "1:32", "2:01", "2:02", "2:04", "2:08", "2:16", "2:32", "4:01",
      "4:02", "4:04", "4:08", "4:16", "4:32", "8:01", "8:02", "8:04", "8:08", "8:16", "8:32", "3:00", "5:00", "6:00",
      "9:00", "10:00"
    })]
  public void Test(int turnedOn, string[] expected)
  {
    new GosperHackSolution().ReadBinaryWatch(turnedOn).Should().BeEquivalentTo(expected);
  }
}
