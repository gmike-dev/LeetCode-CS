namespace LeetCode._146._LRU_Cache;

public class LRUCache(int capacity)
{
  private class CacheItem(int key, int value)
  {
    public readonly int Key = key;
    public int Value = value;
  }

  private readonly LinkedList<CacheItem> list = [];
  private readonly Dictionary<int, LinkedListNode<CacheItem>> dict = new(capacity);

  public int Get(int key)
  {
    if (!dict.TryGetValue(key, out var node))
      return -1;

    list.Remove(node);
    list.AddFirst(node);
    return node.Value.Value;
  }

  public void Put(int key, int value)
  {
    if (dict.TryGetValue(key, out var node))
    {
      node.Value.Value = value;
      list.Remove(node);
      list.AddFirst(node);
      return;
    }
    if (list.Count == capacity)
    {
      dict.Remove(list.Last.Value.Key);
      list.RemoveLast();
    }
    dict[key] = list.AddFirst(new CacheItem(key, value));
  }
}

public class LRUCacheTests
{
  [Test]
  public void Test1()
  {
    LRUCache lruCache = new(2);
    lruCache.Put(1, 1); // cache is {1=1}
    lruCache.Put(2, 2); // cache is {1=1, 2=2}
    lruCache.Get(1).Should().Be(1);
    lruCache.Put(3, 3); // LRU key was 2, evicts key 2, cache is {1=1, 3=3}
    lruCache.Get(2).Should().Be(-1); // returns -1 (not found)
    lruCache.Put(4, 4); // LRU key was 1, evicts key 1, cache is {4=4, 3=3}
    lruCache.Get(1).Should().Be(-1); // return -1 (not found)
    lruCache.Get(3).Should().Be(3); // return 3
    lruCache.Get(4).Should().Be(4); // return 4
  }
}
