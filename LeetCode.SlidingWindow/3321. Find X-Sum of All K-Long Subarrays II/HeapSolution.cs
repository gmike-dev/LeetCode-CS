using System.IO;
using LeetCode.Common;

namespace LeetCode.SlidingWindow._3321._Find_X_Sum_of_All_K_Long_Subarrays_II;

public class HeapSolution
{
    public long[] FindXSum(int[] nums, int k, int x)
    {
        var n = nums.Length;
        var minHeap = new IndexedMaxHeap<int, (int freq, int val)>((x, y) => y.CompareTo(x));
        var maxHeap = new IndexedMaxHeap<int, (int freq, int val)>((x, y) => x.CompareTo(y));
        var sum = 0L;
        var answer = new long[n - k + 1];
        for (var i = 0; i < n; i++)
        {
            AddValue(nums[i]);
            if (i - k + 1 >= 0)
            {
                answer[i - k + 1] = sum;
                RemoveValue(nums[i - k + 1]);
            }
        }
        return answer;

        void AddValue(int value)
        {
            if (minHeap.TryGetValue(value, out var item))
            {
                item.freq++;
                minHeap.ChangeValue(value, item);
                sum += value;
            }
            else
            {
                if (maxHeap.TryGetValue(value, out item))
                {
                    item.freq++;
                    maxHeap.ChangeValue(value, item);
                }
                else
                {
                    maxHeap.Push(value, (1, value));
                }

                if (minHeap.Count < x)
                {
                    var topMax = maxHeap.Pop();
                    minHeap.Push(topMax.val, topMax);
                    sum += (long)topMax.val * topMax.freq;
                }
                else
                {
                    BalanceHeaps();
                }
            }
        }

        void RemoveValue(int prev)
        {
            if (minHeap.TryGetValue(prev, out var item))
            {
                item.freq--;
                sum -= prev;
                if (item.freq == 0)
                {
                    minHeap.Remove(prev);
                    if (maxHeap.Count > 0)
                    {
                        var topMax = maxHeap.Pop();
                        minHeap.Push(topMax.val, topMax);
                        sum += topMax.val;
                    }
                }
                else
                {
                    minHeap.ChangeValue(prev, item);
                    if (maxHeap.Count > 0)
                    {
                        BalanceHeaps();
                    }
                }
            }
            else
            {
                maxHeap.TryGetValue(prev, out item);
                item.freq--;
                if (item.freq == 0)
                    maxHeap.Remove(prev);
                else
                    maxHeap.ChangeValue(prev, item);
            }
        }

        void BalanceHeaps()
        {
            var topMin = minHeap.Top();
            var topMax = maxHeap.Top();
            if (topMax.CompareTo(topMin) > 0)
            {
                minHeap.PushPop(topMax.val, topMax);
                maxHeap.PushPop(topMin.val, topMin);
                sum -= (long)topMin.val * topMin.freq;
                sum += (long)topMax.val * topMax.freq;
            }
        }
    }
}

public class IndexedMaxHeap<TKey, TValue>(Comparison<TValue> comparer)
{
    private class HeapItem(TKey key, TValue value, int index)
    {
        public readonly TKey Key = key;
        public TValue Value = value;
        public int Index = index;
    }

    private readonly Dictionary<TKey, HeapItem> items = [];
    private readonly List<HeapItem> heap = [];

    public int Count => heap.Count;

    public bool Contains(TKey key) => items.ContainsKey(key);

    public bool TryGetValue(TKey key, out TValue value)
    {
        if (items.TryGetValue(key, out var item))
        {
            value = item.Value;
            return true;
        }
        value = default;
        return false;
    }

    public void Push(TKey key, TValue value)
    {
        var item = new HeapItem(key, value, heap.Count);
        items.Add(key, item);
        heap.Add(item);
        UpHeap(item.Index);
    }

    public bool Remove(TKey key)
    {
        if (!items.Remove(key, out var removedItem))
            return false;
        var index = removedItem.Index;
        var last = heap.Count - 1;
        if (index == last)
        {
            heap.RemoveAt(last);
        }
        else
        {
            Swap(index, last);
            heap.RemoveAt(last);
            UpHeap(index);
            DownHeap(index);
        }
        return true;
    }

    private void Swap(int i, int j)
    {
        (heap[i], heap[j]) = (heap[j], heap[i]);
        heap[i].Index = i;
        heap[j].Index = j;
    }

    public TValue Pop()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");
        var top = heap[0];
        var last = heap.Count - 1;
        if (last > 0)
        {
            heap[0] = heap[last];
            heap[0].Index = 0;
            DownHeap(0);
        }
        heap.RemoveAt(last);
        items.Remove(top.Key);
        return top.Value;
    }

    public TValue Top()
    {
        if (heap.Count == 0)
            throw new InvalidOperationException("Heap is empty");
        return heap[0].Value;
    }

    public TValue PushPop(TKey key, TValue value)
    {
        if (heap.Count == 0)
            return value;
        var top = heap[0];
        items.Remove(top.Key);
        var item = new HeapItem(key, value, 0);
        items.Add(key, item);
        heap[0] = item;
        DownHeap(0);
        return top.Value;
    }

    public void ChangeValue(TKey key, TValue newValue)
    {
        var item = items[key];
        var oldValue = item.Value;
        item.Value = newValue;
        switch (comparer(newValue, oldValue))
        {
            case > 0:
                UpHeap(item.Index);
                break;
            case < 0:
                DownHeap(item.Index);
                break;
        }
    }

    private void UpHeap(int i)
    {
        while (i > 0)
        {
            var p = (i - 1) / 2;
            if (comparer(heap[p].Value, heap[i].Value) >= 0)
                break;
            Swap(p, i);
            i = p;
        }
    }

    private void DownHeap(int i)
    {
        while (true)
        {
            var l = 2 * i + 1;
            if (l >= heap.Count)
                break;
            var r = l + 1;
            var largest = l;
            if (r < heap.Count && comparer(heap[r].Value, heap[largest].Value) > 0)
                largest = r;
            if (comparer(heap[largest].Value, heap[i].Value) <= 0)
                break;
            Swap(largest, i);
            i = largest;
        }
    }
}

[TestFixture]
public class IndexedHeapTests
{
    [Test]
    public void Test1()
    {
        var h = new IndexedMaxHeap<int, int>((x, y) => x.CompareTo(y));
        h.Push(1, 1);
        h.Push(2, 2);
        h.Push(3, 3);
        h.Push(4, 4);
        h.Push(5, 5);
        h.Top().Should().Be(5);
        h.Count.Should().Be(5);
        h.Pop().Should().Be(5);
        h.Count.Should().Be(4);
        h.PushPop(10, 10).Should().Be(4);
        h.Top().Should().Be(10);
        h.Pop().Should().Be(10);
        h.Top().Should().Be(3);
        h.Count.Should().Be(3);
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
