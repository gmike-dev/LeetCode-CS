namespace LeetCode._2073._Time_Needed_to_Buy_Tickets;

public class NoQueueSolution
{
  public int TimeRequiredToBuy(int[] tickets, int k)
  {
    var time = 0;
    while (tickets[k] != 0)
    {
      for (var i = 0; i < tickets.Length && tickets[k] != 0; i++)
      {
        if (tickets[i] > 0)
        {
          tickets[i]--;
          time++;
        }
      }
    }
    return time;
  }
}

[TestFixture]
public class NoQueueSolutionTests
{
  [TestCase(new[] { 2, 3, 2 }, 2, 6)]
  [TestCase(new[] { 5, 1, 1, 1 }, 0, 8)]
  public void Test(int[] tickets, int k, int expected)
  {
    new NoQueueSolution().TimeRequiredToBuy(tickets, k).Should().Be(expected);
  }
}
