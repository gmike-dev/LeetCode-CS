using LeetCode.Common;

namespace LeetCode.LinkedLists._86._Partition_List;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    // 1,4,3,2,5,2
    var head = new ListNode(1,
      new ListNode(4,
        new ListNode(3,
          new ListNode(2,
            new ListNode(5,
              new ListNode(2))))));
    var result = new Solution().Partition(head, 3);
    result.Should().BeEquivalentTo(
      new ListNode(1,
        new ListNode(2,
          new ListNode(2,
            new ListNode(4,
              new ListNode(3,
                new ListNode(5)))))));
  }
}
