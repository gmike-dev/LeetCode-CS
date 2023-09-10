namespace LeetCode._1359._Count_All_Valid_Pickup_and_Delivery_Options;

public class Solution
{
  public int CountOrders(int n)
  {
    var count = 1L;
    for (var i = 2; i <= n; i++)
      count = count * i * (2 * i - 1) % 1000000007;
    return (int)count;
  }
}