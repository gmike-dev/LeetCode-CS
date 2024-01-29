using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._232._Implement_Queue_using_Stacks;

[TestFixture]
public class Tests
{
  [Test]
  public void Test1()
  {
    var q = new MyQueue();
    q.Empty().Should().BeTrue();
    q.Push(1);
    q.Push(2);
    q.Empty().Should().BeFalse();
    q.Peek().Should().Be(1);
    q.Pop().Should().Be(1);
    q.Peek().Should().Be(2);
    q.Empty().Should().BeFalse();
    q.Push(3);
    q.Pop().Should().Be(2);
    q.Pop().Should().Be(3);
    q.Empty().Should().BeTrue();
  }
}