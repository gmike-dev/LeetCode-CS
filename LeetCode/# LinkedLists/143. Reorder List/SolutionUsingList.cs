namespace LeetCode.__LinkedLists._143._Reorder_List;

public class SolutionUsingList
{
  public void ReorderList(ListNode head)
  {
    if (head?.next == null)
      return;
    var list = new List<ListNode>();
    for (var node = head; node != null; node = node.next)
      list.Add(node);
    var l = 0;
    var r = list.Count - 1;
    while (l < r)
    {
      list[l++].next = list[r];
      if (l < r)
        list[r--].next = list[l];
    }
    list[l].next = null;
  }
}

[TestFixture]
public class SolutionUsingListTests
{
  [Test]
  public void Test1()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4))));
    new SolutionUsingList().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(4, new ListNode(2, new ListNode(3)))));
  }

  [Test]
  public void Test2()
  {
    var list = new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(5)))));
    new SolutionUsingList().ReorderList(list);
    list.Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(2, new ListNode(4, new ListNode(3))))));
  }
}
