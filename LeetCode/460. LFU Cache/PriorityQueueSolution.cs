namespace LeetCode._460._LFU_Cache.PriorityQueue;

public class LFUCache(int capacity)
{
  private static int currentTime = 1;
  private readonly Dictionary<int, (int value, int freq)> dict = new();
  private readonly PriorityQueue<int, (int freq, int time)> queue = new();
  private readonly Dictionary<int, int> time = new();

  public int Get(int key)
  {
    if (!dict.TryGetValue(key, out var item))
      return -1;

    dict[key] = (item.value, item.freq + 1);
    queue.Enqueue(key, (item.freq + 1, currentTime));
    time[key] = currentTime;
    currentTime++;

    return item.value;
  }

  public void Put(int key, int value)
  {
    if (dict.TryGetValue(key, out var item))
    {
      dict[key] = (value, item.freq + 1);
      queue.Enqueue(key, (item.freq + 1, currentTime));
      time[key] = currentTime;
      currentTime++;
      return;
    }

    if (dict.Count >= capacity)
    {
      Evict();
    }

    dict[key] = (value, 1);
    queue.Enqueue(key, (1, currentTime));
    time[key] = currentTime;
    currentTime++;
  }

  private void Evict()
  {
    while (queue.TryDequeue(out int key, out var priority))
    {
      if (priority.time != time.GetValueOrDefault(key))
      {
        continue;
      }
      dict.Remove(key);
      time.Remove(key);
      break;
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
