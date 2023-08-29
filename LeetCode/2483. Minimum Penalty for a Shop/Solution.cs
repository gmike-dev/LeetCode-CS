namespace LeetCode._2483._Minimum_Penalty_for_a_Shop;

public class Solution
{
  public int BestClosingTime(string customers)
  {
    var n = customers.Length;
    var sl = new int[n + 1];
    var sr = new int[n + 1];
    for (var i = 0; i < n; i++)
      sl[i + 1] += sl[i] + (customers[i] == 'N' ? 1 : 0);
    for (var i = n - 1; i >= 0; i--)
      sr[i] += sr[i + 1] + (customers[i] == 'Y' ? 1 : 0);
    var minPenalty = int.MaxValue;
    var bestTime = 0;
    for (var i = 0; i <= n; i++)
    {
      var penalty = sl[i] + sr[i];
      if (penalty < minPenalty)
      {
        minPenalty = penalty;
        bestTime = i;
      }
    }
    return bestTime;
  }
}