namespace LeetCode._2742._Painting_the_Walls;

public class DpWithMemoizationSolution
{
  private int[] cost;
  private int[] time;
  private int[,] cache;

  public int PaintWalls(int[] cost, int[] time)
  {
    this.cost = cost;
    this.time = time;
    var n = cost.Length;
    cache = new int[n, n + 1];
    return Dp(0, cost.Length);
  }

  private int Dp(int i, int remain)
  {
    if (remain <= 0)
      return 0;
    if (i == cost.Length)
      return (int)1e9;
    if (cache[i, remain] != 0)
      return cache[i, remain];
    return cache[i, remain] = Math.Min(
      cost[i] + Dp(i + 1, remain - time[i] - 1),
      Dp(i + 1, remain));
  }
}
