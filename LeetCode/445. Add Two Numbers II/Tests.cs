using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._445._Add_Two_Numbers_II;

public class Tests
{
  [Test]
  public void Test1()
  {
    var sln = new Solution();
    var num1 = new ListNode(7,
      new ListNode(2,
        new ListNode(4,
          new ListNode(3))));
    var num2 = new ListNode(5,
      new ListNode(6,
        new ListNode(4)));
    var result = sln.AddTwoNumbers(num1, num2);
    result.ToString().Should().Be("7807");
  }
  
  [Test]
  public void Test2()
  {
    var sln = new Solution();
    var num1 = new ListNode(5);
    var num2 = new ListNode(5);
    var result = sln.AddTwoNumbers(num1, num2);
    result.ToString().Should().Be("10");
  }
}
