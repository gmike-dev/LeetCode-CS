using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__Strings._791._Custom_Sort_String;

public class SortSolution
{
  public string CustomSortString(string order, string s)
  {
    var p = new int[128];
    var k = 1;
    foreach (var c in order)
      p[c] = k++;
    return new string(s.OrderBy(c => p[c]).ToArray());
  }
}

[TestFixture]
public class SortSolutionTests
{
  [TestCase("cba", "abcd", "dcba")]
  [TestCase("bcafg", "abcd", "dbca")]
  public void Test(string order, string s, string expected)
  {
    new SortSolution().CustomSortString(order, s).Should().Be(expected);
  }
}
