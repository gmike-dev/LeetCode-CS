using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._1171._Remove_Zero_Sum_Consecutive_Nodes;

public class Solution1
{
  public ListNode RemoveZeroSumSublists(ListNode head)
  {
    var fakeRoot = new ListNode(0, head);
    var prefix = new Dictionary<int, ListNode> { [0] = fakeRoot };
    var prefixSum = 0;
    for (var node = head; node != null; node = node.next)
    {
      prefixSum += node.val;
      if (prefix.TryGetValue(prefixSum, out var first))
      {
        var s = prefixSum;
        for (var n = first.next; n != node; n = n.next)
        {
          s += n.val;
          prefix.Remove(s);
        }
        first.next = node.next;
      }
      else
      {
        prefix[prefixSum] = node;
      }
    }
    return fakeRoot.next;
  }
}

[TestFixture]
public class Solution1Tests
{
  [Test]
  public void Test1()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(-3, new ListNode(3, new ListNode(1))))))
      .Should().BeEquivalentTo(new ListNode(3, new ListNode(1)));
  }

  [Test]
  public void Test2()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(4))))))
      .Should().BeEquivalentTo(new ListNode(1, new ListNode(2, new ListNode(4))));
  }

  [Test]
  public void Test3()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(-3, new ListNode(-2))))))
      .Should().BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test4()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(1, new ListNode(-1)))
      .Should().BeNull();
  }

  [Test]
  public void Test5()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(-1, new ListNode(1)))
      .Should().BeNull();
  }

  [Test]
  public void Test6()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(-1, new ListNode(1, new ListNode(2))))
      .Should().BeEquivalentTo(new ListNode(2));
  }

  [Test]
  public void Test7()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(1,
        new ListNode(3,
          new ListNode(2,
            new ListNode(-3, new ListNode(-2, new ListNode(5, new ListNode(5, new ListNode(-5, new ListNode(1))))))))))
      .Should().BeEquivalentTo(new ListNode(1, new ListNode(5, new ListNode(1))));
  }

  [Test]
  public void Test8()
  {
    new Solution1()
      .RemoveZeroSumSublists(new ListNode(0, new ListNode(0)))
      .Should().BeNull();
  }
}
