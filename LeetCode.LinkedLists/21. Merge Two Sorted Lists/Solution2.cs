using LeetCode.Common;

namespace LeetCode.LinkedLists._21._Merge_Two_Sorted_Lists;

public class Solution2
{
  public ListNode MergeTwoLists(ListNode list1, ListNode list2)
  {
    var fakeRoot = new ListNode();
    for (var node = fakeRoot; list1 != null || list2 != null; node = node.next)
    {
      if (list1 == null || list2 != null && list2.val < list1.val)
      {
        node.next = new ListNode(list2.val);
        list2 = list2.next;
      }
      else
      {
        node.next = new ListNode(list1.val);
        list1 = list1.next;
      }
    }
    return fakeRoot.next;
  }
}

[TestFixture]
public class Solution2Tests
{
  [TestCase("[1,2,4]", "[1,3,4]", "[1,1,2,3,4,4]")]
  [TestCase("[]", "[]", "[]")]
  [TestCase("[]", "[0]", "[0]")]
  public void Test1(string list1, string list2, string expected)
  {
    var actual = new Solution2().MergeTwoLists(ListNode.FromString(list1), ListNode.FromString(list2));
    ListNode.ToString(actual).Should().Be(expected);
  }
}
