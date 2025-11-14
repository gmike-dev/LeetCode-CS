using System.IO;
using LeetCode.Common;

namespace LeetCode.SlidingWindow._3321._Find_X_Sum_of_All_K_Long_Subarrays_II;

public class HeapSolution
{
  private class Item(int freq, int val)
  {
    public int freq = freq;
    public int val = val;
    public int heapIndex;

    public int CompareTo(Item other)
    {
      var cmp = freq - other.freq;
      if (cmp != 0)
        return cmp;
      return val - other.val;
    }
  }

  private static int MaxHeapComparer(Item x, Item y) => x.CompareTo(y);

  private static int MinHeapComparer(Item x, Item y) => y.CompareTo(x);

  public long[] FindXSum(int[] nums, int k, int x)
  {
    var n = nums.Length;
    var minHeap = new Item[n];
    var maxHeap = new Item[n];
    var minHeapSize = 0;
    var maxHeapSize = 0;
    var minHeapItems = new Dictionary<int, Item>();
    var maxHeapItems = new Dictionary<int, Item>();
    var sum = 0L;
    var answer = new long[n - k + 1];
    for (var i = 0; i < n; i++)
    {
      var current = nums[i];
      if (minHeapItems.TryGetValue(current, out var item))
      {
        item.freq++;
        DownHeap(minHeap, item.heapIndex, minHeapSize, MinHeapComparer);
        sum += current;
      }
      else
      {
        if (maxHeapItems.TryGetValue(current, out item))
        {
          item.freq++;
          UpHeap(maxHeap, item.heapIndex, MaxHeapComparer);
        }
        else
        {
          item = new Item(1, current);
          PushHeap(maxHeap, item, ref maxHeapSize, MaxHeapComparer);
          maxHeapItems[current] = item;
        }

        if (minHeapSize < x)
        {
          var topMax = PopHeap(maxHeap, ref maxHeapSize, MaxHeapComparer);
          PushHeap(minHeap, topMax, ref minHeapSize, MinHeapComparer);
          maxHeapItems.Remove(topMax.val);
          minHeapItems.Add(topMax.val, topMax);
          sum += (long)topMax.val * topMax.freq;
        }
        else
        {
          var topMin = minHeap[0];
          var topMax = maxHeap[0];
          if (topMax.CompareTo(topMin) > 0)
          {
            minHeap[0] = topMax;
            topMax.heapIndex = 0;
            DownHeap(minHeap, 0, minHeapSize, MinHeapComparer);
            maxHeap[0] = topMin;
            topMin.heapIndex = 0;
            DownHeap(maxHeap, 0, maxHeapSize, MaxHeapComparer);
            minHeapItems.Remove(topMin.val);
            minHeapItems.Add(topMax.val, topMax);
            maxHeapItems.Remove(topMax.val);
            maxHeapItems.Add(topMin.val, topMin);
            sum -= (long)topMin.val * topMin.freq;
            sum += (long)topMax.val * topMax.freq;
          }
        }
      }

      if (i < k - 1)
        continue;

      answer[i - k + 1] = sum;

      var prev = nums[i - k + 1];
      if (minHeapItems.TryGetValue(prev, out item))
      {
        item.freq--;
        UpHeap(minHeap, item.heapIndex, MinHeapComparer);
        sum -= prev;
        if (maxHeapSize > 0)
        {
          var topMin = minHeap[0];
          var topMax = maxHeap[0];
          if (topMax.CompareTo(topMin) > 0)
          {
            minHeap[0] = topMax;
            topMax.heapIndex = 0;
            DownHeap(minHeap, 0, minHeapSize, MinHeapComparer);
            maxHeap[0] = topMin;
            topMin.heapIndex = 0;
            DownHeap(maxHeap, 0, maxHeapSize, MaxHeapComparer);
            minHeapItems.Remove(topMin.val);
            minHeapItems.Add(topMax.val, topMax);
            maxHeapItems.Remove(topMax.val);
            maxHeapItems.Add(topMin.val, topMin);
            sum -= (long)topMin.val * topMin.freq;
            sum += (long)topMax.val * topMax.freq;
          }
        }
        else if (item.freq == 0)
        {
          var topMin = PopHeap(minHeap, ref minHeapSize, MinHeapComparer);
          PushHeap(maxHeap, topMin, ref maxHeapSize, MaxHeapComparer);
          minHeapItems.Remove(topMin.val);
          maxHeapItems.Add(topMin.val, topMin);
        }
      }
      else
      {
        item = maxHeapItems[prev];
        item.freq--;
        DownHeap(maxHeap, item.heapIndex, maxHeapSize, MaxHeapComparer);
        // if (item.freq == 0)
        // {
        //   maxHeapItems.Remove(item.val);
        //   // maxHeapSize--;
        // }
      }
    }
    return answer;
  }

  private static Item PopHeap(Item[] a, ref int n, Comparison<Item> comparer)
  {
    if (n <= 0)
      throw new InvalidOperationException();
    var top = a[0];
    if (n > 1)
    {
      a[0] = a[n - 1];
      a[0].heapIndex = 0;
      DownHeap(a, 0, n - 1, comparer);
    }
    n--;
    return top;
  }

  private static void PushHeap(Item[] a, Item item, ref int n, Comparison<Item> comparer)
  {
    a[n] = item;
    item.heapIndex = n;
    n++;
    UpHeap(a, item.heapIndex, comparer);
  }

  private static void UpHeap(Item[] a, int i, Comparison<Item> comparer)
  {
    while (i > 0)
    {
      var p = (i - 1) / 2;
      if (comparer(a[p], a[i]) >= 0)
        break;
      (a[p], a[i]) = (a[i], a[p]);
      a[i].heapIndex = i;
      a[p].heapIndex = p;
      i = p;
    }
  }

  private static void DownHeap(Item[] a, int i, int n, Comparison<Item> comparer)
  {
    while (true)
    {
      var largest = i;
      var l = (i << 1) + 1; /* 2*id + 1 */
      var r = (i + 1) << 1; /* 2*id + 2 */
      if (l < n && comparer(a[l], a[largest]) > 0)
        largest = l;
      if (r < n && comparer(a[r], a[largest]) > 0)
        largest = r;
      if (largest == i)
        break;
      (a[largest], a[i]) = (a[i], a[largest]);
      a[i].heapIndex = i;
      a[largest].heapIndex = largest;
      i = largest;
    }
  }
}

[TestFixture]
public class HeapSolutionTests
{
  [TestCase("[1,1,2,2,3,4,2,3]", 6, 2, "[6,10,12]")]
  [TestCase("[3,8,7,8,7,5]", 2, 2, "[11,15,15,15,12]")]
  [TestCase("[4,4,4,10]", 2, 1, "[8,8,10]")]
  public void Test(string nums, int k, int x, string expected)
  {
    var actual = new HeapSolution().FindXSum(nums.Array(), k, x);
    actual.String().Should().BeEquivalentTo(expected);
  }

  [Test]
  public void TestLarge()
  {
    var source = Path.Join(TestContext.CurrentContext.WorkDirectory, "3321. Find X-Sum of All K-Long Subarrays II",
      "TestCases.txt");
    using var sr = new StreamReader(source);
    while (!sr.EndOfStream)
    {
      var rains = sr.ReadLine();
      var k = int.Parse(sr.ReadLine());
      var x = int.Parse(sr.ReadLine());
      var expected = sr.ReadLine();
      var actual = new HeapSolution().FindXSum(rains.Array(), k, x);
      actual.String().Should().BeEquivalentTo(expected);
    }
  }
}
