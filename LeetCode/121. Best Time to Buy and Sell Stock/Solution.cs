using System;
using System.Linq;

namespace LeetCode._121._Best_Time_to_Buy_and_Sell_Stock;

public class Solution
{
  public int MaxProfit(int[] prices)
  {
    var maxPrice = prices[^1];
    var maxProfit = 0;
    foreach (var price in prices.Reverse().Skip(1))
    {
      maxProfit = Math.Max(maxProfit, maxPrice - price);
      maxPrice = Math.Max(maxPrice, price);
    }
    return maxProfit;
  }
}