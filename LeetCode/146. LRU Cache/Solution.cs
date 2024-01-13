using System.Collections.Generic;

namespace LeetCode._146._LRU_Cache;

public class LRUCache
{
  private readonly struct CacheItem
  {
    public readonly int Key;
    public readonly int Value;

    public CacheItem(int key, int value)
    {
      Key = key;
      Value = value;
    }
  }
  
  private readonly int _capacity;
  private readonly LinkedList<CacheItem> _list = new();
  private readonly Dictionary<int, LinkedListNode<CacheItem>> _dict = new ();

  public LRUCache(int capacity)
  {
    _capacity = capacity;
  }

  public int Get(int key)
  {
    if (!_dict.TryGetValue(key, out var node))
      return -1;
    
    _list.Remove(node);
    _list.AddFirst(node);
    return node.Value.Value;
  }

  public void Put(int key, int value)
  {
    if (_dict.TryGetValue(key, out var node))
    {
      _list.Remove(node);
    }
    else if (_list.Count == _capacity)
    {
      _dict.Remove(_list.Last.Value.Key);
      _list.RemoveLast();
    }
    _dict[key] = _list.AddFirst(new CacheItem(key, value));
  }
}