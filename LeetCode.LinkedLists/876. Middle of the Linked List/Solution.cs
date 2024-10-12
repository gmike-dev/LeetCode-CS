using LeetCode.Common;

namespace LeetCode.LinkedLists._876._Middle_of_the_Linked_List;

public class Solution
{
  public ListNode MiddleNode(ListNode head)
  {
    var slow = head;
    var fast = head;
    while (fast?.next != null)
    {
      slow = slow.next;
      fast = fast.next.next;
    }
    return slow;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var expected = new ListNode(3, new ListNode(4, new ListNode(5)));
    var list = new ListNode(1, new ListNode(2, expected));
    new Solution().MiddleNode(list).Should().BeEquivalentTo(expected);
  }

  [Test]
  public void Test2()
  {
    var expected = new ListNode(4, new ListNode(5, new ListNode(6)));
    var list = new ListNode(1, new ListNode(2, new ListNode(3, expected)));
    new Solution().MiddleNode(list).Should().BeEquivalentTo(expected);
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1);
    new Solution().MiddleNode(list).Should().BeEquivalentTo(list);
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1, new ListNode(2));
    new Solution().MiddleNode(list).Should().BeEquivalentTo(new ListNode(2));
  }

  [Test]
  public void Test5()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    new Solution().MiddleNode(list).Should().BeEquivalentTo(new ListNode(2, new ListNode(3)));
  }
}
