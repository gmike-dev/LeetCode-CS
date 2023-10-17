using FluentAssertions;
using NUnit.Framework;

namespace LeetCode._706._Design_HashMap;

[TestFixture]
public class MyHashMapTests
{
  [Test]
  public void Test1()
  {
    var map = new MyHashMap();
    map.Get(10).Should().Be(-1);
    map.Get(0).Should().Be(-1);
    map.Put(1, 11);
    map.Get(1).Should().Be(11);
    map.Remove(1);
    map.Get(1).Should().Be(-1);
    map.Put(1, 11);
    map.Put(1, 10);
    map.Get(1).Should().Be(10);
    map.Remove(1);
    map.Get(1).Should().Be(-1);
  }
}