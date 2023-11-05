namespace LeetCode._1535._Find_the_Winner_of_an_Array_Game;

public class Solution
{
  public int GetWinner(int[] a, int k)
  {
    var n = a.Length;
    var x = a[0];
    var wins = 0;
    for (var i = 1; i < n && wins < k; i++)
    {
      if (x > a[i])
      {
        wins++;
      }
      else
      {
        x = a[i];
        wins = 1;
      }
    }
    return x;
  }
}