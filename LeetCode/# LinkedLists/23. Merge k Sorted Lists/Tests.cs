namespace LeetCode.__LinkedLists._23._Merge_k_Sorted_Lists;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var lists = new[]
    {
      new ListNode(1, new ListNode(4, new ListNode(5))),
      new ListNode(1, new ListNode(3, new ListNode(4))),
      new ListNode(2, new ListNode(6))
    };
    var expected = new ListNode(1,
      new ListNode(1,
        new ListNode(2,
          new ListNode(3,
            new ListNode(4,
              new ListNode(4,
                new ListNode(5,
                  new ListNode(6))))))));
    new Solution().MergeKLists(lists).Should().BeEquivalentTo(expected);
    new Solution().MergeKLists_UseLinkedList(lists).Should().BeEquivalentTo(expected);
  }

  [Test]
  public void Test2()
  {
    var lists = new ListNode[]
    {
      null, null, null
    };
    ListNode expected = null;
    new Solution().MergeKLists(lists).Should().BeEquivalentTo(expected);
    new Solution().MergeKLists_UseLinkedList(lists).Should().BeEquivalentTo(expected);
  }
}
