using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._143._Reorder_List;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
    new Solution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(3)))));
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    new Solution().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(2, new ListNode(4, new ListNode(3))))));
  }
}