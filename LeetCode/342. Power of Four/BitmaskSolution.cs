using System.Numerics;

namespace LeetCode._342._Power_of_Four;

public class BitmaskSolution
{
  public bool IsPowerOfFour(int n)
  {
    return BitOperations.PopCount((uint)n) == 1 &&
           BitOperations.TrailingZeroCount((uint)n) % 2 == 0;
  }
}