namespace LeetCode._621._Task_Scheduler;

public class MySolution
{
  public int LeastInterval(char[] tasks, int n)
  {
    Span<int> cnt = stackalloc int[128];
    foreach (var t in tasks)
      cnt[t]++;
    Span<int> next = stackalloc int[128];
    next[0] = int.MaxValue;
    var time = 0;
    for (var i = 0; i < tasks.Length; i++)
    {
      var task = 0;
      for (var t = 'A'; t <= 'Z'; t++)
      {
        if (cnt[t] > cnt[task] && next[t] <= time)
          task = t;
      }
      if (task == 0)
      {
        for (var t = 'A'; t <= 'Z'; t++)
        {
          if (cnt[t] != 0 && (next[t] < next[task] || next[t] == next[task] && cnt[t] > cnt[task]))
            task = t;
        }
        time = next[task];
      }
      cnt[task]--;
      next[task] = time + n + 1;
      time++;
    }
    return time;
  }
}

[TestFixture]
public class MySolutionTests
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
  }
}
