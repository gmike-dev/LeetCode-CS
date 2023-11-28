namespace LeetCode._2147._Number_of_Ways_to_Divide_a_Long_Corridor;

public class OnePassSolution
{
  public int NumberOfWays(string corridor)
  {
    const int mod = (int)1e9 + 7;
    var result = 1L;
    var prevSeat = 0;
    var seatCount = 0;
    for (var i = 0; i < corridor.Length; i++)
    {
      if (corridor[i] == 'S')
      {
        seatCount++;
        if (seatCount == 3)
        {
          result = result * (i - prevSeat) % mod;
          seatCount = 1;
        }
        prevSeat = i;
      }
    }
    if (seatCount != 2)
      return 0;
    return (int)result;
  }

}