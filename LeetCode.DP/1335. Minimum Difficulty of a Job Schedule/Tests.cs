namespace LeetCode.DP._1335._Minimum_Difficulty_of_a_Job_Schedule;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 6, 5, 4, 3, 2, 1 }, 2, 7)]
  [TestCase(new[] { 9, 9, 9 }, 4, -1)]
  [TestCase(new[] { 1, 1, 1 }, 3, 3)]
  [TestCase(new[] { 7, 1, 7, 1, 7, 1 }, 3, 15)]
  [TestCase(new[] { 11, 111, 22, 222, 33, 333, 44, 444 }, 6, 843)]
  public void Test(int[] jobDifficulty, int d, int expected)
  {
    new RecursiveSolution().MinDifficulty(jobDifficulty, d).Should().Be(expected);
    new DpSolution().MinDifficulty(jobDifficulty, d).Should().Be(expected);
  }
}
