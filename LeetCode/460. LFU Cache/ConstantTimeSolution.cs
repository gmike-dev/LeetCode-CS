namespace LeetCode._460._LFU_Cache.ConstantTime;

public class LFUCache(int capacity)
{
  private class CacheItem(int key, int value)
  {
    public int Key { get; } = key;
    public int Value { get; set; } = value;
  }

  private readonly LinkedList<LinkedList<CacheItem>> freqBucketList = [];
  private readonly Dictionary<int, LinkedListNode<LinkedList<CacheItem>>> freqBuckets = new();
  private readonly Dictionary<int, LinkedListNode<CacheItem>> cacheItems = new();
  private readonly Dictionary<int, int> frequency = new();

  public int Get(int key)
  {
    if (!cacheItems.TryGetValue(key, out var item))
      return -1;

    IncFrequency(item);
    return item.Value.Value;
  }

  public void Put(int key, int value)
  {
    if (cacheItems.TryGetValue(key, out var item))
    {
      item.Value.Value = value;
      IncFrequency(item);
      return;
    }

    if (cacheItems.Count >= capacity)
    {
      LinkedListNode<LinkedList<CacheItem>> leastFreqBucket = freqBucketList.First;
      LinkedListNode<CacheItem> leastUsedNode = leastFreqBucket.Value.Last;
      leastFreqBucket.Value.Remove(leastUsedNode);
      CacheItem leastUsedItem = leastUsedNode.Value;
      cacheItems.Remove(leastUsedItem.Key);
      int oldFreq = frequency[leastUsedItem.Key];
      frequency.Remove(leastUsedItem.Key);
      if (leastFreqBucket.Value.Count == 0)
      {
        freqBuckets.Remove(oldFreq);
        freqBucketList.Remove(leastFreqBucket);
      }
    }

    CacheItem newItem = new(key, value);
    if (freqBuckets.TryGetValue(1, out var listNode))
    {
      cacheItems[key] = listNode.Value.AddFirst(newItem);
    }
    else
    {
      LinkedList<CacheItem> newList = new();
      cacheItems[key] = newList.AddFirst(newItem);
      freqBuckets.Add(1, freqBucketList.AddFirst(newList));
    }

    frequency[key] = 1;
  }

  private void IncFrequency(LinkedListNode<CacheItem> item)
  {
    int key = item.Value.Key;
    int oldFreq = frequency[key];
    LinkedListNode<LinkedList<CacheItem>> oldFreqListNode = freqBuckets[oldFreq];
    oldFreqListNode.Value.Remove(item);
    int newFreq = oldFreq + 1;
    if (freqBuckets.TryGetValue(newFreq, out LinkedListNode<LinkedList<CacheItem>> newFreqListNode))
    {
      newFreqListNode.Value.AddFirst(item);
    }
    else
    {
      LinkedList<CacheItem> newList = new();
      newList.AddFirst(item);
      newFreqListNode = freqBucketList.AddAfter(oldFreqListNode, newList);
      freqBuckets[newFreq] = newFreqListNode;
    }
    frequency[key] = newFreq;

    if (oldFreqListNode.Value.Count == 0)
    {
      freqBuckets.Remove(oldFreq);
      freqBucketList.Remove(oldFreqListNode);
    }
  }
}

public class LFUCacheTests
{
  [Test]
  public void Test1()
  {
    // cnt(x) = the use counter for key x
    // cache=[] will show the last used order for tiebreakers (leftmost element is  most recent)
    LFUCache lfu = new(2);
    lfu.Put(1, 1); // cache=[1,_], cnt(1)=1
    lfu.Put(2, 2); // cache=[2,1], cnt(2)=1, cnt(1)=1
    lfu.Get(1).Should().Be(1); // return 1
    // cache=[1,2], cnt(2)=1, cnt(1)=2
    lfu.Put(3, 3); // 2 is the LFU key because cnt(2)=1 is the smallest, invalidate 2.
    // cache=[3,1], cnt(3)=1, cnt(1)=2
    lfu.Get(2).Should().Be(-1); // return -1 (not found)
    lfu.Get(3).Should().Be(3); // return 3
    // cache=[3,1], cnt(3)=2, cnt(1)=2
    lfu.Put(4, 4); // Both 1 and 3 have the same cnt, but 1 is LRU, invalidate 1.
    // cache=[4,3], cnt(4)=1, cnt(3)=2
    lfu.Get(1).Should().Be(-1); // return -1 (not found)
    lfu.Get(3).Should().Be(3); // return 3
    // cache=[3,4], cnt(4)=1, cnt(3)=3
    lfu.Get(4).Should().Be(4); // return 4
    // cache=[4,3], cnt(4)=2, cnt(3)=3
  }

  [Test]
  public void Test2()
  {
    LFUCache lfu = new(2);
    lfu.Put(3, 1);
    lfu.Put(2, 1);
    lfu.Put(2, 2);
    lfu.Put(4, 4);
    lfu.Get(2).Should().Be(2);
  }
}
