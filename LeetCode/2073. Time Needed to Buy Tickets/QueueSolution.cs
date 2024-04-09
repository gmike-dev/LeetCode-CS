namespace LeetCode._2073._Time_Needed_to_Buy_Tickets;

public class QueueSolution
{
  public int TimeRequiredToBuy(int[] tickets, int k)
  {
    var q = new Queue<int>();
    for (var i = 0; i < tickets.Length; i++)
      q.Enqueue(i);
    var time = 0;
    while (tickets[k] != 0)
    {
      var i = q.Dequeue();
      if (--tickets[i] > 0)
        q.Enqueue(i);
      time++;
    }
    return time;
  }
}

[TestFixture]
public class QueueSolutionTests
{
  [TestCase(new[] { 2, 3, 2 }, 2, 6)]
  [TestCase(new[] { 5, 1, 1, 1 }, 0, 8)]
  public void Test(int[] tickets, int k, int expected)
  {
    new QueueSolution().TimeRequiredToBuy(tickets, k).Should().Be(expected);
  }
}
