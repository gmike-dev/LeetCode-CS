using LeetCode.Common;

namespace LeetCode.LinkedLists._21._Merge_Two_Sorted_Lists;

public class Solution
{
  public ListNode MergeTwoLists(ListNode list1, ListNode list2)
  {
    var result = new ListNode(-1);
    var lastNode = result;
    while (list1 != null && list2 != null)
    {
      if (list1.val < list2.val)
      {
        lastNode.next = new ListNode(list1.val);
        list1 = list1.next;
      }
      else
      {
        lastNode.next = new ListNode(list2.val);
        list2 = list2.next;
      }
      lastNode = lastNode.next;
    }
    while (list1 != null)
    {
      lastNode.next = new ListNode(list1.val);
      lastNode = lastNode.next;
      list1 = list1.next;
    }
    while (list2 != null)
    {
      lastNode.next = new ListNode(list2.val);
      lastNode = lastNode.next;
      list2 = list2.next;
    }
    return result.next;
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[1,2,4]", "[1,3,4]", "[1,1,2,3,4,4]")]
  [TestCase("[]", "[]", "[]")]
  [TestCase("[]", "[0]", "[0]")]
  public void Test1(string list1, string list2, string expected)
  {
    var actual = new Solution().MergeTwoLists(ListNode.FromString(list1), ListNode.FromString(list2));
    ListNode.ToString(actual).Should().Be(expected);
  }
}
