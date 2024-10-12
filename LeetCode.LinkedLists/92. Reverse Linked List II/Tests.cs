using LeetCode.Common;

namespace LeetCode.LinkedLists._92._Reverse_Linked_List_II;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    var result = new Solution().ReverseBetween(list, 2, 4);
    result.Should().BeEquivalentTo(
      new ListNode(1, new ListNode(4, new ListNode(3, new ListNode(2, new ListNode(5))))));
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(5);
    var result = new Solution().ReverseBetween(list, 1, 1);
    result.Should().BeEquivalentTo(new ListNode(5));
  }

  [Test]
  public void Test3()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    var result = new Solution().ReverseBetween(list, 1, 3);
    result.Should().BeEquivalentTo(new ListNode(3, new ListNode(2, new ListNode(1))));
  }

  [Test]
  public void Test4()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3)));
    var result = new Solution().ReverseBetween(list, 1, 2);
    result.Should().BeEquivalentTo(new ListNode(2, new ListNode(1, new ListNode(3))));
  }
}
