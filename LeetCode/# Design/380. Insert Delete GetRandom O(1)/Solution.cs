namespace LeetCode.__Design._380._Insert_Delete_GetRandom_O_1_;

/// <summary>
/// https://leetcode.com/problems/insert-delete-getrandom-o1
/// </summary>
public class RandomizedSet
{
  private readonly Dictionary<int, int> indexOf = new();
  private readonly List<int> items = new();
  private readonly Random random = new();

  public bool Insert(int val)
  {
    if (indexOf.ContainsKey(val))
    {
      return false;
    }
    indexOf[val] = items.Count;
    items.Add(val);
    return true;
  }

  public bool Remove(int val)
  {
    if (!indexOf.TryGetValue(val, out int index))
    {
      return false;
    }
    int lastIndex = items.Count - 1;
    if (index < lastIndex)
    {
      int lastItem = items[lastIndex];
      indexOf[lastItem] = index;
      items[index] = lastItem;
    }
    items.RemoveAt(lastIndex);
    indexOf.Remove(val);
    return true;
  }

  public int GetRandom()
  {
    return items[random.Next(0, items.Count)];
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test()
  {
    RandomizedSet randomizedSet = new();
    randomizedSet.Insert(1).Should().BeTrue(); // Inserts 1 to the set. Returns true as 1 was Inserted successfully.
    randomizedSet.Remove(2).Should().BeFalse(); // Returns false as 2 does not exist in the set.
    randomizedSet.Insert(2).Should().BeTrue(); // Inserts 2 to the set, returns true. Set now contains [1,2].
    randomizedSet.GetRandom().Should().BeInRange(1, 2); // getRandom() should return either 1 or 2 randomly.
    randomizedSet.Remove(1).Should().BeTrue(); // Removes 1 from the set, returns true. Set now contains [2].
    randomizedSet.Insert(2).Should().BeFalse(); // 2 was already in the set, so return false.
    randomizedSet.GetRandom().Should()
      .Be(2); // Since 2 is the only number in the set, getRandom() will always return 2.
  }
}
