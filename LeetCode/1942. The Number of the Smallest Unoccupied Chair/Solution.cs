namespace LeetCode._1942._The_Number_of_the_Smallest_Unoccupied_Chair;

public class Solution
{
  public int SmallestChair(int[][] times, int targetFriend)
  {
    var occupiedChairs = new PriorityQueue<int, int>();
    var freeChairs = new PriorityQueue<int, int>();
    var nextChair = 0;
    foreach (var (arrival, leaving, friend) in times.Select((t, i) => (t[0], t[1], i)).OrderBy(x => x))
    {
      while (occupiedChairs.TryPeek(out var chair, out var time) && time <= arrival)
      {
        occupiedChairs.Dequeue();
        freeChairs.Enqueue(chair, chair);
      }
      var friendChair = freeChairs.Count != 0 ? freeChairs.Dequeue() : nextChair++;
      if (friend == targetFriend)
        return friendChair;
      occupiedChairs.Enqueue(friendChair, leaving);
    }
    return -1;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().SmallestChair([[1, 4], [2, 3], [4, 6]], 1).Should().Be(1);
  }

  [Test]
  public void Test2()
  {
    new Solution().SmallestChair([[3, 10], [1, 5], [2, 6]], 0).Should().Be(2);
  }

  [Test]
  public void Test3()
  {
    new Solution()
      .SmallestChair(
      [
        [4, 5], [12, 13], [5, 6], [1, 2], [8, 9], [9, 10], [6, 7], [3, 4], [7, 8], [13, 14], [15, 16], [14, 15],
        [10, 11], [11, 12], [2, 3], [16, 17]
      ], 15).Should().Be(0);
  }
}
