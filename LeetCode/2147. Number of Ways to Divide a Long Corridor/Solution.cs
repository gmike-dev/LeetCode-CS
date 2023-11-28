using System.Collections.Generic;

namespace LeetCode._2147._Number_of_Ways_to_Divide_a_Long_Corridor;

public class Solution
{
  public int NumberOfWays(string corridor)
  {
    var seats = new List<int>();
    for (var i = 0; i < corridor.Length; i++)
    {
      if (corridor[i] == 'S')
        seats.Add(i);
    }
    
    if (seats.Count == 0 || seats.Count % 2 != 0)
      return 0;

    const int mod = (int)1e9 + 7;
    var result = 1L;
    for (var i = 1; i < seats.Count - 2; i += 2)
      result = result * (seats[i + 1] - seats[i]) % mod;
    return (int)result;
  }
}