namespace LeetCode._2483._Minimum_Penalty_for_a_Shop;

public class Solution
{
  public int BestClosingTime(string customers)
  {
    var n = customers.Length;
    var openPenalty = 0;
    var closePenalty = 0;
    for (var i = 0; i < n; i++)
      if (customers[i] == 'Y')
        closePenalty++;
    var minPenalty = int.MaxValue;
    var bestTime = 0;
    for (var i = 0; i < n; i++)
    {
      var penalty = openPenalty + closePenalty;
      if (penalty < minPenalty)
      {
        minPenalty = penalty;
        bestTime = i;
      }
      if (customers[i] == 'N')
        openPenalty++;
      else
        closePenalty--;
    }
    if (openPenalty + closePenalty < minPenalty)
      bestTime = n;
    return bestTime;
  }
}