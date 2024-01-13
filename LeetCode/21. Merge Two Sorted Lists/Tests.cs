using FluentAssertions;
using NUnit.Framework;

namespace LeetCode.MergeTwoSortedLists;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
    var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
    sln.MergeTwoLists(list1, list2).ToString().Should().Be("1,1,2,3,4,4");
  }
}