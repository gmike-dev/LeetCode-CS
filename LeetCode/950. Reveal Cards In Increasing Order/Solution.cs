namespace LeetCode._950._Reveal_Cards_In_Increasing_Order;

public class Solution
{
  public int[] DeckRevealedIncreasing(int[] deck)
  {
    var n = deck.Length;
    var q = new Queue<int>(Enumerable.Range(0, n));
    var result = new int[n];
    Array.Sort(deck);
    for (var i = 0; i < n; i++)
    {
      result[q.Dequeue()] = deck[i];
      if (q.Count > 0)
        q.Enqueue(q.Dequeue());
    }
    return result;
  }
}

[TestFixture]
public class Tests
{
  [TestCase(new[] { 17, 13, 11, 2, 3, 5, 7 }, new[] { 2, 13, 3, 11, 5, 17, 7 })]
  [TestCase(new[] { 1, 1000 }, new[] { 1, 1000 })]
  public void Test(int[] deck, int[] expected)
  {
    new Solution().DeckRevealedIncreasing(deck).Should().BeEquivalentTo(expected, o => o.WithStrictOrdering());
  }
}
