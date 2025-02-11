namespace LeetCode.Strings._1910._Remove_All_Occurrences_of_a_Substring;

public class Solution
{
  public string RemoveOccurrences(string s, string part)
  {
    var ll = new LinkedList<char>();
    foreach (var c in s)
      ll.AddLast(c);

    for (var current = ll.First; current != null;)
    {
      var node = current;
      var success = true;
      foreach (var c in part)
      {
        if (node == null || node.Value != c)
        {
          success = false;
          break;
        }
        node = node.Next;
      }
      if (success)
      {
        node = node?.Previous ?? ll.Last;
        for (var i = 0; i < part.Length; i++)
        {
          var prev = node.Previous;
          ll.Remove(node);
          node = prev;
        }
        for (var i = 2; node != null && i < part.Length; i++)
          node = node.Previous;

        current = node ?? ll.First;
      }
      else
      {
        current = current.Next;
      }
    }

    var result = new StringBuilder(ll.Count);
    foreach (var c in ll)
      result.Append(c);
    return result.ToString();
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("daabcbaabcbc", "abc", "dab")]
  [TestCase("axxxxyyyyb", "xy", "ab")]
  [TestCase("xy", "xy", "")]
  [TestCase("xyxy", "xy", "")]
  [TestCase("xxyy", "xy", "")]
  [TestCase("xxxyy", "xy", "x")]
  [TestCase("xxyyy", "xy", "y")]
  [TestCase("x", "xy", "x")]
  [TestCase("", "xy", "")]
  public void Test(string s, string part, string expected)
  {
    new Solution().RemoveOccurrences(s, part).Should().Be(expected);
  }
}
