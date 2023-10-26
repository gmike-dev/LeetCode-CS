namespace LeetCode._342._Power_of_Four;

public class BitmaskSolution2
{
  public bool IsPowerOfFour(int n) => n > 0 && (n & (n - 1)) == 0 && (n & 0x55555555) != 0;
}