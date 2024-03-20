using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.__LinkedLists._1669._Merge_In_Between_Linked_Lists;

public class Solution
{
  public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
  {
    var fakeRoot1 = new ListNode(0, list1);
    var prevA = fakeRoot1;
    for (var i = 0; i < a; i++)
      prevA = prevA.next;
    var nextB = prevA.next;
    for (var i = a; i <= b; i++)
      nextB = nextB.next;

    prevA.next = list2;
    GetLastNode(list2).next = nextB;

    return fakeRoot1.next;
  }

  private static ListNode GetLastNode(ListNode list)
  {
    var node = list;
    while (node.next != null)
      node = node.next;
    return node;
  }
}

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var list1 = new ListNode(10,
      new ListNode(1,
        new ListNode(13,
          new ListNode(6,
            new ListNode(9,
              new ListNode(5))))));
    var list2 = new ListNode(1000000,
      new ListNode(1000001,
        new ListNode(1000002)));
    var result = new Solution().MergeInBetween(list1, 3, 4, list2);
    result.Should().BeEquivalentTo(
      new ListNode(10,
        new ListNode(1,
          new ListNode(13,
            new ListNode(1000000,
              new ListNode(1000001,
                new ListNode(1000002,
                  new ListNode(5))))))));
  }

  [Test]
  public void Test2()
  {
    var list1 = new ListNode(0,
      new ListNode(1,
        new ListNode(2,
          new ListNode(3,
            new ListNode(4,
              new ListNode(5,
                new ListNode(6)))))));
    var list2 = new ListNode(1000000,
      new ListNode(1000001,
        new ListNode(1000002,
          new ListNode(1000003,
            new ListNode(1000004)))));
    var result = new Solution().MergeInBetween(list1, 2, 5, list2);
    result.Should().BeEquivalentTo(new ListNode(0,
      new ListNode(1,
        new ListNode(1000000,
          new ListNode(1000001,
            new ListNode(1000002,
              new ListNode(1000003,
                new ListNode(1000004,
                  new ListNode(6)))))))));
  }

  [Test]
  public void Test3()
  {
    var list1 = new ListNode(0);
    var list2 = new ListNode(1);
    new Solution().MergeInBetween(list1, 0, 0, list2).Should().BeEquivalentTo(new ListNode(1));
  }

  [Test]
  public void Test4()
  {
    var list1 = new ListNode(0, new ListNode(1));
    var list2 = new ListNode(2, new ListNode(3));
    new Solution().MergeInBetween(list1, 0, 1, list2).Should().BeEquivalentTo(new ListNode(2, new ListNode(3)));
  }

  [Test]
  public void Test5()
  {
    var list1 = new ListNode(0, new ListNode(1));
    var list2 = new ListNode(2, new ListNode(3));
    new Solution().MergeInBetween(list1, 1, 1, list2).Should()
      .BeEquivalentTo(new ListNode(0, new ListNode(2, new ListNode(3))));
  }
}
