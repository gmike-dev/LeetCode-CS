using LeetCode.Common;

namespace LeetCode.LinkedLists._2._Add_Two_Numbers;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().AddTwoNumbers(
        new ListNode(2, new ListNode(4, new ListNode(3))),
        new ListNode(5, new ListNode(6, new ListNode(4)))).Should()
      .BeEquivalentTo(
        new ListNode(7, new ListNode(0, new ListNode(8))));
  }

  [Test]
  public void Test2()
  {
    new Solution().AddTwoNumbers(new ListNode(), new ListNode()).Should().BeEquivalentTo(new ListNode());
  }

  [Test]
  public void Test3()
  {
    new Solution().AddTwoNumbers(
        new ListNode(9, new ListNode(9, new ListNode(9))),
        new ListNode(9, new ListNode(9))).Should()
      .BeEquivalentTo(
        new ListNode(8, new ListNode(9, new ListNode(0, new ListNode(1)))));
  }
}
