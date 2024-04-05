namespace LeetCode.__LinkedLists._206._Reverse_Linked_List;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    new Solution().ReverseList(
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
    new Solution().ReverseList(new ListNode(1, new ListNode(2)))
      .Should().BeEquivalentTo(new ListNode(2, new ListNode(1)));
  }

  [Test]
  public void Test3()
  {
    new Solution().ReverseList(null).Should().BeNull();
  }

}
