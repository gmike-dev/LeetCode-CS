namespace LeetCode.__Design._381._Insert_Delete_GetRandom_O_1____Duplicates_allowed.LocalIndexes;

/// <summary>
/// https://leetcode.com/problems/Insert-delete-GetRandom-o1-duplicates-allowed
/// </summary>
public class RandomizedCollection
{
    private readonly Dictionary<int, List<int>> indexes = new();
    private readonly Dictionary<(int, int), int> localIndex = new();
    private readonly List<int> items = new();

    public bool Insert(int val)
    {
        items.Add(val);
        int global = items.Count - 1;
        if (indexes.TryGetValue(val, out var ind))
        {
            ind.Add(global);
            localIndex.Add((val, global), ind.Count - 1);
            return false;
        }
        indexes.Add(val, [global]);
        localIndex.Add((val, global), 0);
        return true;
    }

    public bool Remove(int val)
    {
        if (!indexes.TryGetValue(val, out var ind))
        {
            return false;
        }
        int valGlobalIndex = ind[^1];
        localIndex.Remove((val, valGlobalIndex));
        if (valGlobalIndex != items.Count - 1)
        {
            int lastItem = items[^1];
            int lastItemLocalIndex = localIndex[(lastItem, items.Count - 1)];
            items[valGlobalIndex] = lastItem;
            indexes[lastItem][lastItemLocalIndex] = valGlobalIndex;
            localIndex.Remove((lastItem, items.Count - 1));
            localIndex.Add((lastItem, valGlobalIndex), lastItemLocalIndex);
        }
        ind.RemoveAt(ind.Count - 1);
        items.RemoveAt(items.Count - 1);
        if (ind.Count == 0)
        {
            indexes.Remove(val);
        }
        return true;
    }

    public int GetRandom()
    {
        return items[Random.Shared.Next(0, items.Count)];
    }
}

[TestFixture]
public class SolutionTests
{
    [Test]
    public void Test1()
    {
        RandomizedCollection randomizedCollection = new();
        randomizedCollection.Insert(1).Should().BeTrue(); // return true since the collection does not contain 1.
        // Inserts 1 into the collection.
        randomizedCollection.Insert(1).Should().BeFalse(); // return false since the collection contains 1.
        // Inserts another 1 into the collection. Collection now contains [1,1].
        randomizedCollection.Insert(2).Should().BeTrue(); // return true since the collection does not contain 2.
        // Inserts 2 into the collection. Collection now contains [1,1,2].
        randomizedCollection.GetRandom().Should().BeInRange(1, 2); // GetRandom should:
        // - return 1 with probability 2/3, or
        // - return 2 with probability 1/3.
        randomizedCollection.Remove(1).Should().BeTrue(); // return true since the collection contains 1.
        // Removes 1 from the collection. Collection now contains [1,2].
        randomizedCollection.GetRandom().Should()
            .BeInRange(1, 2); // GetRandom should return 1 or 2, both equally likely.
    }

    [Test]
    public void Test2()
    {
        RandomizedCollection randomizedCollection = new();

        randomizedCollection.Insert(1); // 1-й insert
        randomizedCollection.Insert(1); // 2-й insert
        randomizedCollection.Insert(2); // 3-й insert
        randomizedCollection.Insert(2); // 4-й insert
        randomizedCollection.Insert(2); // 5-й insert

        randomizedCollection.Remove(1); // 1-й remove
        randomizedCollection.Remove(1); // 2-й remove
        randomizedCollection.Remove(2); // 3-й remove

        randomizedCollection.Insert(1); // 6-й insert

        randomizedCollection.Remove(2); // 4-й remove

        randomizedCollection.GetRandom(); // 1-й getRandom
        randomizedCollection.GetRandom(); // 2-й getRandom
        randomizedCollection.GetRandom(); // 3-й getRandom
        randomizedCollection.GetRandom(); // 4-й getRandom
        randomizedCollection.GetRandom(); // 5-й getRandom
        randomizedCollection.GetRandom(); // 6-й getRandom
        randomizedCollection.GetRandom(); // 7-й getRandom
        randomizedCollection.GetRandom(); // 8-й getRandom
        randomizedCollection.GetRandom(); // 9-й getRandom
        randomizedCollection.GetRandom(); // 10-й getRandom
    }

    [Test]
    public void Test3()
    {
        RandomizedCollection randomizedCollection = new();

        randomizedCollection.Insert(1); // 1-й insert
        randomizedCollection.Remove(1); // 1-й remove
        randomizedCollection.Insert(1); // 2-й insert
    }
}
