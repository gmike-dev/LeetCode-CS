using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._341._Flatten_Nested_List_Iterator;

[TestFixture]
public class NestedIteratorUsingStackTests
{
  [Test]
  public void Test1()
  {
    var nestedList = new NestedInteger[]
    {
      new(new NestedInteger[] { new(1), new(1) }),
      new(2),
      new(new NestedInteger[] { new(1), new(1) })
    };
    var iterator = new NestedIteratorUsingStack(nestedList);
    var actual = new List<int>();
    while (iterator.HasNext())
      actual.Add(iterator.Next());
    actual.Should().BeEquivalentTo(new[] { 1, 1, 2, 1, 1 }, o => o.WithStrictOrdering());
  }

  [Test]
  public void Test2()
  {
    var nestedList = new NestedInteger[]
    {
      new(1),
      new(new NestedInteger[]
      {
        new(4),
        new(new NestedInteger[] { new(6) })
      })
    };
    var iterator = new NestedIteratorUsingStack(nestedList);
    var actual = new List<int>();
    while (iterator.HasNext())
      actual.Add(iterator.Next());
    actual.Should().BeEquivalentTo(new[] { 1, 4, 6 }, o => o.WithStrictOrdering());
  }
}