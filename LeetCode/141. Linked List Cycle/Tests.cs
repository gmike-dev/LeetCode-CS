using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._141._Linked_List_Cycle;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    var node4 = new ListNode(4);
    node1.next = node2;
    node2.next = node3;
    node3.next = node4;
    node4.next = node3;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test2()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    var node4 = new ListNode(4);
    node1.next = node2;
    node2.next = node3;
    node3.next = node4;
    node4.next = node2;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test3()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    var node4 = new ListNode(4);
    node1.next = node2;
    node2.next = node3;
    node3.next = node4;
    node4.next = node2;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test4()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    var node4 = new ListNode(4);
    node1.next = node2;
    node2.next = node3;
    node3.next = node4;
    new Solution().HasCycle(node1).Should().BeFalse();
  }
  
  [Test]
  public void Test5()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    node1.next = node2;
    node2.next = node1;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test6()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    node1.next = node2;
    new Solution().HasCycle(node1).Should().BeFalse();
  }
  
  [Test]
  public void Test7()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    node1.next = node2;
    node2.next = node3;
    node3.next = node2;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test8()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    node1.next = node2;
    node2.next = node3;
    node3.next = node1;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test9()
  {
    var node1 = new ListNode(1);
    var node2 = new ListNode(2);
    var node3 = new ListNode(3);
    node1.next = node2;
    node2.next = node3;
    new Solution().HasCycle(node1).Should().BeFalse();
  }
  
  [Test]
  public void Test10()
  {
    var node1 = new ListNode(1);
    new Solution().HasCycle(node1).Should().BeFalse();
  }
  
  [Test]
  public void Test11()
  {
    var node1 = new ListNode(1);
    node1.next = node1;
    new Solution().HasCycle(node1).Should().BeTrue();
  }
  
  [Test]
  public void Test12()
  {
    new Solution().HasCycle(null).Should().BeFalse();
  }
}