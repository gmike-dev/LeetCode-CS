using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._23._Merge_k_Sorted_Lists;

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
    new Solution().MergeKLists(lists).Should().BeEquivalentTo(
      new ListNode(1,
        new ListNode(1,
          new ListNode(2,
            new ListNode(3,
              new ListNode(4,
                new ListNode(4,
                  new ListNode(5,
                    new ListNode(6)))))))));
  }
}