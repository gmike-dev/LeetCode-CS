namespace LeetCode.Graphs._1615._Maximal_Network_Rank;

public class Solution
{
  public int MaximalNetworkRank(int n, int[][] roads)
  {
    var g = new int[n][];
    for (var i = 0; i < n; i++)
      g[i] = new int[n];

    foreach (var road in roads)
    {
      g[road[0]][road[1]] = 1;
      g[road[1]][road[0]] = 1;
    }

    var maxRank = 0;
    for (var i = 0; i < n - 1; i++)
    for (var j = i + 1; j < n; j++)
    {
      var rank = 0;
      for (var k = 0; k < n; k++)
        rank += g[i][k] + g[j][k];
      rank -= g[i][j];
      maxRank = Math.Max(maxRank, rank);
    }

    return maxRank;
  }
}
