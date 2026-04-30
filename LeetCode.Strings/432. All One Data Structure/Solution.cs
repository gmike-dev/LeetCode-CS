namespace LeetCode.Strings._432._All_One_Data_Structure;

/// <summary>
/// https://leetcode.com/problems/all-oone-data-structure/
/// </summary>
public class AllOne
{
  private readonly Dictionary<string, int> counter = new();
  private readonly Dictionary<int, LinkedListNode<LinkedList<string>>> freq = new();
  private readonly LinkedList<LinkedList<string>> freqList = new();
  private readonly Dictionary<string, LinkedListNode<string>> dict = new();

  public void Inc(string key)
  {
    if (counter.TryGetValue(key, out int oldFreq))
    {
      int newFreq = oldFreq + 1;
      counter[key] = newFreq;
      var oldFreqBatch = freq[oldFreq];
      var node = dict[key];
      oldFreqBatch.Value.Remove(node);
      if (freq.TryGetValue(newFreq, out var newFreqBatch))
      {
        newFreqBatch.Value.AddLast(node);
      }
      else
      {
        var batch = new LinkedList<string>();
        batch.AddLast(node);
        freq[newFreq] = freqList.AddAfter(oldFreqBatch, batch);
      }
      if (oldFreqBatch.Value.Count == 0)
      {
        freqList.Remove(oldFreqBatch);
        freq.Remove(oldFreq);
      }
    }
    else
    {
      if (freq.TryGetValue(1, out var freqBatch))
      {
        dict[key] = freqBatch.Value.AddLast(key);
      }
      else
      {
        var batch = new LinkedList<string>();
        dict[key] = batch.AddFirst(key);
        freq[1] = freqList.AddFirst(batch);
      }
      counter[key] = 1;
    }
  }

  public void Dec(string key)
  {
    int oldFreq = counter[key];
    if (oldFreq > 1)
    {
      int newFreq = oldFreq - 1;
      counter[key] = newFreq;
      var oldFreqBatch = freq[oldFreq];
      var node = dict[key];
      oldFreqBatch.Value.Remove(node);
      if (freq.TryGetValue(newFreq, out var newFreqBatch))
      {
        newFreqBatch.Value.AddLast(node);
      }
      else
      {
        var batch = new LinkedList<string>();
        batch.AddLast(node);
        newFreqBatch = freqList.AddBefore(oldFreqBatch, batch);
        freq[newFreq] = newFreqBatch;
      }
      if (oldFreqBatch.Value.Count == 0)
      {
        freqList.Remove(oldFreqBatch);
        freq.Remove(oldFreq);
      }
    }
    else
    {
      var node = dict[key];
      var freqBatch = freq[1];
      freqBatch.Value.Remove(node);
      if (freqBatch.Value.Count == 0)
      {
        freqList.Remove(freqBatch);
        freq.Remove(1);
      }
      counter.Remove(key);
      dict.Remove(key);
    }
  }

  public string GetMaxKey()
  {
    return freqList.Count == 0 ? "" : freqList.Last.Value.First.Value;
  }

  public string GetMinKey()
  {
    return freqList.Count == 0 ? "" : freqList.First.Value.First.Value;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    var allOne = new AllOne();
    allOne.Inc("hello");
    allOne.Inc("hello");
    allOne.GetMaxKey().Should().Be("hello"); // return "hello"
    allOne.GetMinKey().Should().Be("hello"); // return "hello"
    allOne.Inc("leet");
    allOne.GetMaxKey().Should().Be("hello"); // return "hello"
    allOne.GetMinKey().Should().Be("leet"); // return "leet"
  }

  [Test]
  public void Test2()
  {
    var allOne = new AllOne();
    allOne.Inc("a");
    allOne.Inc("b");
    allOne.Inc("b");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Dec("b");
    allOne.Dec("b");
    allOne.GetMinKey().Should().Be("a");
    allOne.GetMaxKey().Should().Be("c");
    allOne.Dec("a");
    allOne.GetMaxKey().Should().Be("c");
    allOne.GetMinKey().Should().Be("c");
  }

  [Test]
  public void Test3()
  {
    var allOne = new AllOne();
    allOne.Inc("helloji");
    allOne.Inc("helloji");
    allOne.GetMaxKey().Should().Be("helloji");
    allOne.GetMinKey().Should().Be("helloji");
    allOne.Inc("hello");
    allOne.GetMaxKey().Should().Be("helloji");
    allOne.GetMinKey().Should().Be("hello");
  }

  [Test]
  public void Test4()
  {
    var allOne = new AllOne();
    allOne.Inc("a");
    allOne.Inc("b");
    allOne.Inc("b");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Inc("c");
    allOne.Dec("b");
    allOne.Dec("b");
    allOne.GetMinKey().Should().Be("a");
    allOne.Dec("a");
    allOne.GetMinKey().Should().Be("c");
  }
}
