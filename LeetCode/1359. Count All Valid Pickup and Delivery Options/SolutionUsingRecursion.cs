namespace LeetCode._1359._Count_All_Valid_Pickup_and_Delivery_Options;

public class SolutionUsingRecursion
{
  public int CountOrders(int n)
  {
    return (int)Count(n);
  }

  private static long Count(int n)
  {
    if (n == 1)
      return 1;
    return n * (2 * n - 1) * Count(n - 1) % 1000000007;
  }
}