namespace LeetCode._2369._Check_if_There_is_a_Valid_Partition_For_The_Array;

public class SolutionUsingMemoization
{
  private bool?[] _cache;

  public bool ValidPartition(int[] nums)
  {
    _cache = new bool?[nums.Length + 1];
    _cache[0] = true;
    return ValidPartition(nums.AsSpan());
  }

  private bool ValidPartition(Span<int> nums)
  {
    if (_cache[nums.Length] != null)
      return _cache[nums.Length].Value;
    var result = nums.Length switch
    {
      < 2 => nums.IsEmpty,
      2 => nums[0] == nums[1],
      _ => nums[0] == nums[1] && ValidPartition(nums[2..]) ||
           (nums[0] == nums[1] && nums[1] == nums[2] || nums[0] + 1 == nums[1] && nums[1] + 1 == nums[2]) && ValidPartition(nums[3..])
    };
    _cache[nums.Length] = result;
    return result;
  }
}
