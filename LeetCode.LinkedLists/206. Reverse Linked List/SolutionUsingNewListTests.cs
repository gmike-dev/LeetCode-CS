using LeetCode.Common;

namespace LeetCode.LinkedLists._206._Reverse_Linked_List;

[TestFixture]
public class SolutionUsingNewListTests
{
  [Test]
  public void Test1()
  {
    new SolutionUsingNewList().ReverseList(
        new ListNode(1,
          new ListNode(2,
            new ListNode(3,
              new ListNode(4,
                new ListNode(5))))))
      .Should().BeEquivalentTo(
        new ListNode(5,
          new ListNode(4,
            new ListNode(3,
              new ListNode(2,
                new ListNode(1))))));
  }

  [Test]
  public void Test2()
  {
    new SolutionUsingNewList().ReverseList(new ListNode(1, new ListNode(2)))
      .Should().BeEquivalentTo(new ListNode(2, new ListNode(1)));
  }

  [Test]
  public void Test3()
  {
    new SolutionUsingNewList().ReverseList(null).Should().BeNull();
  }
}
