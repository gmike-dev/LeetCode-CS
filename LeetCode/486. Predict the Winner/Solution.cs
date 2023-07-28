using System;
using System.Linq;

namespace LeetCode._486._Predict_the_Winner;

public class Solution
{
  public bool PredictTheWinner(int[] nums)
  {
    var firstPlayerPoints = CalculatePoints(nums, 0, nums.Length - 1, true);
    return 2 * firstPlayerPoints >= nums.Sum();
  }

  private int CalculatePoints(int[] nums, int l, int r, bool firstPlayerTurn)
  {
    if (l == r)
      return firstPlayerTurn ? nums[l] : 0;

    if (firstPlayerTurn)
      return Math.Max(
        nums[l] + CalculatePoints(nums, l + 1, r, false),
        nums[r] + CalculatePoints(nums, l, r - 1, false));
    
    return Math.Min(
      CalculatePoints(nums, l + 1, r, true),
      CalculatePoints(nums, l, r - 1, true));
  }
}