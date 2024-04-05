namespace LeetCode._621._Task_Scheduler;

[TestFixture]
public class Tests
{
  [TestCase(new[] { 'A', 'A', 'A', 'B', 'B', 'B' }, 2, 8)]
  [TestCase(new[] { 'A', 'C', 'A', 'B', 'D', 'B' }, 1, 6)]
  [TestCase(new[] { 'A' }, 10, 1)]
  [TestCase(new[] { 'A', 'A' }, 10, 12)]
  [TestCase(new[] { 'A', 'A' }, 0, 2)]
  [TestCase(new[] { 'A', 'B' }, 10, 2)]
  [TestCase(new[] { 'A', 'B' }, 0, 2)]
  public void Test(char[] tasks, int n, int expected)
  {
    new MySolution().LeastInterval(tasks, n).Should().Be(expected);
    new Solution().LeastInterval(tasks, n).Should().Be(expected);
  }
}
