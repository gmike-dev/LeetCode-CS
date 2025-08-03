namespace LeetCode.SlidingWindow._2106._Maximum_Fruits_Harvested_After_at_Most_K_Steps;

public class Solution
{
  public int MaxTotalFruits(int[][] fruits, int startPos, int k)
  {
    var n = fruits.Length;
    var s = new int[200002];
    for (var i = 0; i < n; i++)
      s[fruits[i][0]] = fruits[i][1];
    for (var i = 1; i < s.Length; i++)
      s[i] += s[i - 1];
    var result = 0;
    for (var right = 0; right <= k; right++)
    {
      if (startPos + right >= s.Length)
        break;
      var count = s[startPos + right];
      if (startPos > 0)
        count -= s[startPos - 1];
      if (k > 2 * right)
      {
        var left = Math.Min(startPos, k - 2 * right);
        if (left > 0)
        {
          count += s[startPos - 1];
          if (startPos - left > 0)
            count -= s[startPos - left - 1];
        }
      }
      result = Math.Max(result, count);
    }
    for (var left = 0; left <= k; left++)
    {
      if (startPos - left < 0)
        break;
      var count = s[startPos];
      if (startPos - left > 0)
        count -= s[startPos - left - 1];
      if (k > 2 * left)
      {
        var right = Math.Min(s.Length - startPos - 1, k - 2 * left);
        if (right > 0)
          count += s[startPos + right] - s[startPos];
      }
      result = Math.Max(result, count);
    }
    return result;
  }
}

[TestFixture]
public class SolutionTests
{
  [Test]
  public void Test1()
  {
    new Solution().MaxTotalFruits([[2, 8], [6, 3], [8, 6]], 5, 4).Should().Be(9);
  }

  [Test]
  public void Test2()
  {
    new Solution().MaxTotalFruits([[0, 9], [4, 1], [5, 7], [6, 2], [7, 4], [10, 9]], 5, 4).Should().Be(14);
  }

  [Test]
  public void Test3()
  {
    new Solution().MaxTotalFruits([[0, 3], [6, 4], [8, 5]], 3, 2).Should().Be(0);
  }

  [Test]
  public void Test4()
  {
    new Solution().MaxTotalFruits([[200000, 10000]], 200000, 200000).Should().Be(10000);
  }

  [Test]
  public void Test5()
  {
    new Solution().MaxTotalFruits([[200000, 10000]], 200000, 0).Should().Be(10000);
  }

  [Test]
  public void Test6()
  {
    new Solution().MaxTotalFruits([[200000, 10000]], 0, 200000).Should().Be(10000);
  }
}
