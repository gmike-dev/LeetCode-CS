namespace LeetCode._1043._Partition_Array_for_Maximum_Sum;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 1, 15, 7, 9, 2, 5, 10 }, 3, 84)]
  [TestCase(new[] { 1, 4, 1, 5, 7, 3, 6, 1, 9, 9, 3 }, 4, 83)]
  [TestCase(new[] { 1 }, 1, 1)]
  [TestCase(new[] { 20779,436849,274670,543359,569973,280711,252931,424084,361618,430777,136519,749292,933277,477067,502755,695743,413274,168693,368216,677201,198089,927218,633399,427645,317246,403380,908594,854847,157024,719715,336407,933488,599856,948361,765131,335089,522119,403981,866323,519161,109154,349141,764950,558613,692211 }, 26, 42389649)]
  public void Test(int[] arr, int k, int expected)
  {
    new RecursiveSolution().MaxSumAfterPartitioning(arr, k).Should().Be(expected);
    new DpSolution().MaxSumAfterPartitioning(arr, k).Should().Be(expected);
  }
}
