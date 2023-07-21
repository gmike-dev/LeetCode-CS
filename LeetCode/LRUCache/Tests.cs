using NUnit.Framework;

namespace LeetCode.LRUCache;

public class Tests
{
  [Test]
  public void Test1()
  {
    var lruCache = new LRUCache(2);
    lruCache.Put(1, 1); // cache is {1=1}
    lruCache.Put(2, 2); // cache is {1=1, 2=2}
    Assert.That(lruCache.Get(1), Is.EqualTo(1));    // return 1
    lruCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
    Assert.That(lruCache.Get(2), Is.EqualTo(-1));    // returns -1 (not found)
    lruCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
    Assert.That(lruCache.Get(1), Is.EqualTo(-1));    // return -1 (not found)
    Assert.That(lruCache.Get(3), Is.EqualTo(3));    // return 3
    Assert.That(lruCache.Get(4), Is.EqualTo(4));    // return 4
  }
}
