using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._148._Sort_List;

[TestFixture]
public class InsertionSortTests
{
  [Test]
  public void Test1()
  {
    // -1,5,3,4,0
    var list = new ListNode(-1, new ListNode(5, new ListNode(3, new ListNode(4, new ListNode(0)))));
    var result = new InsertionSortSolution().SortList(list);
    result.Should().BeEquivalentTo(
      // -1,0,3,4,5
      new ListNode(-1, new ListNode(0, new ListNode(3, new ListNode(4, new ListNode(5))))));
  }
  
  [Test]
  public void Test2()
  {
    // -1
    var list = new ListNode(-1);
    var result = new InsertionSortSolution().SortList(list);
    result.Should().BeEquivalentTo(
      // -1
      new ListNode(-1));
  }
  
  [Test]
  public void Test3()
  {
    var result = new InsertionSortSolution().SortList(null);
    result.Should().BeNull();
  }
  
  [Test]
  public void Test4()
  {
    // 4,2,1,3
    var list = new ListNode(4, new ListNode(2, new ListNode(1, new ListNode(3))));
    var result = new InsertionSortSolution().SortList(list);
    result.Should().BeEquivalentTo(
      // 1,2,3,4
      new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4)))));
  }
}