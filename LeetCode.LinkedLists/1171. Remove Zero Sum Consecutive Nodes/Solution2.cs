using LeetCode.Common;

namespace LeetCode.LinkedLists._1171._Remove_Zero_Sum_Consecutive_Nodes;

public class Solution2
{
  public ListNode RemoveZeroSumSublists(ListNode head)
  {
    var fakeRoot = new ListNode(0, head);
    var prefix = new Dictionary<int, ListNode>();
    var prefixSum = 0;
    for (var node = fakeRoot; node != null; node = node.next)
    {
      prefixSum += node.val;
      prefix[prefixSum] = node;
    }
    prefixSum = 0;
    for (var node = fakeRoot; node != null; node = node.next)
    {
      prefixSum += node.val;
      node.next = prefix[prefixSum].next;
    }
    return fakeRoot.next;
  }
}

[TestFixture]
public class Solution2Tests
{
  [Test]
  public void Test1()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(-3, new ListNode(3, new ListNode(1))))))
      .Should().BeEquivalentTo(new ListNode(3, new ListNode(1)));
  }

  [Test]
  public void Test2()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(4))))))
      .Should().BeEquivalentTo(new ListNode(1, new ListNode(2, new ListNode(4))));
  }

  [Test]
  public void Test3()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(-2))))))
      .Should().BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test4()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(-1)))
      .Should().BeNull();
  }

  [Test]
  public void Test5()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(-1, new ListNode(1)))
      .Should().BeNull();
  }

  [Test]
  public void Test6()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(-1, new ListNode(1, new ListNode(2))))
      .Should().BeEquivalentTo(new ListNode(2));
  }

  [Test]
  public void Test7()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(1,
        new ListNode(3,
          new ListNode(2,
            new ListNode(-3, new ListNode(-2, new ListNode(5, new ListNode(5, new ListNode(-5, new ListNode(1))))))))))
      .Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(1))));
  }

  [Test]
  public void Test8()
  {
    new Solution2()
      .RemoveZeroSumSublists(new ListNode(0, new ListNode(0)))
      .Should().BeNull();
  }
}
