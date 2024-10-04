namespace LeetCode._2491._Divide_Players_Into_Teams_of_Equal_Skill;

public class CountingSolution
{
  public long DividePlayers(int[] skill)
  {
    var count = new int[1001];
    var min = int.MaxValue;
    var max = 0;
    foreach (var s in skill)
    {
      min = Math.Min(min, s);
      max = Math.Max(max, s);
      count[s]++;
    }
    var sum = min + max;
    long p = 0;
    for (int l = min, r = max; l <= r;)
    {
      if (count[l] == 0)
        l++;
      else if (count[r] == 0)
        r--;
      else
      {
        if (l + r != sum || count[l] != count[r])
          return -1;
        var c = l == r ? count[l] / 2 : count[l];
        p += (long)c * l * r;
        l++;
        r--;
      }
    }
    return p;
  }
}

[TestFixture]
public class CountingSolutionTests
{
  [TestCase(new[] { 3, 2, 5, 1, 3, 4 }, 22)]
  [TestCase(new[] { 3, 4 }, 12)]
  [TestCase(new[] { 1, 1, 2, 3 }, -1)]
  [TestCase(new[] { 5, 1, 3, 6 }, -1)]
  [TestCase(new[] { 5, 1, 1, 2, 1, 4 }, -1)]
  public void Test(int[] skill, long result)
  {
    new CountingSolution().DividePlayers(skill).Should().Be(result);
  }
}
