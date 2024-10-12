using LeetCode.Common;

namespace LeetCode.LinkedLists._725._Split_Linked_List_in_Parts;

public class Solution
{
  public ListNode[] SplitListToParts(ListNode head, int k)
  {
    var length = 0;
    for (var node = head; node != null; node = node.next)
      length++;

    var result = new ListNode[k];
    var curr = head;
    ListNode prev = null;
    for (var i = 0; i < k; i++)
    {
      result[i] = curr;
      var partSize = (length + k - i - 1) / (k - i);
      for (var j = 0; j < partSize; j++)
      {
        prev = curr;
        curr = curr.next;
      }
      if (prev != null)
        prev.next = null;
      length -= partSize;
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,2,3]", 5, new[] { "[1]", "[2]", "[3]", "[]", "[]" })]
  [TestCase("[1,2,3,4,5,6,7,8,9,10]", 3, new[] { "[1,2,3,4]", "[5,6,7]", "[8,9,10]" })]
  [TestCase("[]", 3, new[] { "[]", "[]", "[]" })]
  [TestCase("[1,2,3]", 1, new[] { "[1,2,3]" })]
  [TestCase("[1,2,3]", 3, new[] { "[1]", "[2]", "[3]" })]
  public void Test(string list, int k, string[] expected)
  {
    var result = new Solution().SplitListToParts(ListNode.FromString(list), k);
    result.Select(ListNode.ToString).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
