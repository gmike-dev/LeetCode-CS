namespace LeetCode.__LinkedLists._160._Intersection_of_Two_Linked_Lists;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var intersection = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) } };
    // 4,1,8,4,5
    var listA = new ListNode(8) { next = new ListNode(4) { next = new ListNode(5) { next = intersection } } };
    // 5,6,1,8,4,5
    var listB = new ListNode(5) { next = new ListNode(6) { next = new ListNode(1) { next = intersection } } };

    new Solution().GetIntersectionNode(listA, listB).Should().BeSameAs(intersection);
    new Solution().GetIntersectionNode2(listA, listB).Should().BeSameAs(intersection);
  }
}
