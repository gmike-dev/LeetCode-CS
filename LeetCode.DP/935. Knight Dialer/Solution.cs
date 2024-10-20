namespace LeetCode.DP._935._Knight_Dialer;

public class Solution
{
  private readonly Dictionary<int, int[]> moves = new()
  {
    [0] = [4, 6],
    [1] = [6, 8],
    [2] = [7, 9],
    [3] = [4, 8],
    [4] = [0, 3, 9],
    [5] = [],
    [6] = [0, 1, 7],
    [7] = [2, 6],
    [8] = [1, 3],
    [9] = [2, 4]
  };

  public int KnightDialer(int n)
  {
    const int mod = (int)1e9 + 7;

    var prev = new int[10];
    var curr = new int[10];
    Array.Fill(prev, 1);
    for (var i = 1; i < n; i++)
    {
      for (var digit = 0; digit <= 9; digit++)
      {
        var s = 0;
        foreach (var move in moves[digit])
        {
          s = (s + prev[move]) % mod;
        }
        curr[digit] = s;
      }
      (prev, curr) = (curr, prev);
    }
    var result = 0;
    for (var digit = 0; digit <= 9; digit++)
    {
      result = (result + prev[digit]) % mod;
    }
    return result;
  }
}
