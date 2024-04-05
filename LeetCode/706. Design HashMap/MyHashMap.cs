namespace LeetCode._706._Design_HashMap;

public class MyHashMap
{
  private const int mod = 10000;
  private readonly List<(int key, int value)>[] values = new List<(int, int)>[mod];

  public void Put(int key, int value)
  {
    var hash = key % mod;
    if (values[hash] == null)
      values[hash] = new List<(int, int)>();
    for (var i = 0; i < values[hash].Count; i++)
    {
      if (values[hash][i].key == key)
      {
        values[hash][i] = (key, value);
        return;
      }
    }
    values[hash].Add((key, value));
  }

  public int Get(int key)
  {
    var hash = key % mod;
    var items = values[hash];
    if (items == null)
      return -1;
    for (var i = 0; i < items.Count; i++)
    {
      if (items[i].key == key)
        return items[i].value;
    }
    return -1;
  }

  public void Remove(int key)
  {
    var hash = key % mod;
    var items = values[hash];
    if (items == null)
      return;
    for (var i = 0; i < items.Count; i++)
    {
      if (items[i].key == key)
      {
        items.RemoveAt(i);
        break;
      }
    }
    if (items.Count == 0)
      values[hash] = null;
  }
}
