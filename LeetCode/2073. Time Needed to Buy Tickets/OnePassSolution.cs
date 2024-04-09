namespace LeetCode._2073._Time_Needed_to_Buy_Tickets;

public class OnePassSolution
{
  public int TimeRequiredToBuy(int[] tickets, int k)
  {
    var time = 0;
    for (var i = 0; i < tickets.Length; i++)
    {
      if (i <= k)
        time += Math.Min(tickets[i], tickets[k]);
      else
        time += Math.Min(tickets[i], tickets[k] - 1);
    }
    return time;
  }
}

[TestFixture]
public class OnePassSolutionTests
{
  [TestCase(new[] { 2, 3, 2 }, 2, 6)]
  [TestCase(new[] { 5, 1, 1, 1 }, 0, 8)]
  public void Test(int[] tickets, int k, int expected)
  {
    new OnePassSolution().TimeRequiredToBuy(tickets, k).Should().Be(expected);
  }
}
