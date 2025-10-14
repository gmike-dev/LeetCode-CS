using System.IO;
using LeetCode.Common;

namespace LeetCode._1488._Avoid_Flood_in_The_City;

public class Solution
{
  public int[] AvoidFlood(int[] rains)
  {
    var n = rains.Length;
    var result = new int[n];
    var sunny = new List<int>();
    var rainy = new Dictionary<int, int>();
    for (var i = 0; i < n; i++)
    {
      var rain = rains[i];
      if (rain == 0)
      {
        sunny.Add(i);
        result[i] = 1;
      }
      else
      {
        result[i] = -1;
        if (rainy.TryGetValue(rain, out var day))
        {
          var pos = sunny.BinarySearch(day);
          if (pos < 0)
            pos = ~pos;
          if (pos == sunny.Count)
            return [];
          result[sunny[pos]] = rain;
          sunny.RemoveAt(pos);
        }
        rainy[rain] = i;
      }
    }

    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,2,3,4]", "[-1,-1,-1,-1]")]
  [TestCase("[1,2,0,0,2,1]", "[-1,-1,2,1,-1,-1]")]
  [TestCase("[1,2,0,1,2]", "[]")]
  [TestCase("[1,2,3,0,3,0,3,0,2]", "[-1,-1,-1,3,-1,3,-1,2,-1]")]
  [TestCase("[69,0,0,0,69]", "[-1,69,1,1,-1]")]
  [TestCase("[1,0,2,0,2,1]", "[-1,1,-1,2,-1,-1]")]
  [TestCase("[1,0,2,0]", "[-1,1,-1,1]")]
  public void Test(string rains, string expected)
  {
    new Solution().AvoidFlood(rains.Array()).Should().BeEquivalentTo(expected.Array(), o => o.WithStrictOrdering());
  }

  [Test]
  public void TestLarge()
  {
    var source = Path.Join(TestContext.CurrentContext.WorkDirectory, "1488. Avoid Flood in The City", "TestCases.txt");
    using var sr = new StreamReader(source);
    while (!sr.EndOfStream)
    {
      var rains = sr.ReadLine();
      var expected = sr.ReadLine();
      var actual = new Solution().AvoidFlood(rains.Array());
      actual.Should().BeEquivalentTo(expected.Array(), o => o.WithStrictOrdering());
    }
  }
}
