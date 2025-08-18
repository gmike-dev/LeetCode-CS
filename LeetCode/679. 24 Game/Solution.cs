using LeetCode.Common;

namespace LeetCode._679._24_Game;

public class Solution
{
  private static readonly Func<double, double, double>[] Operations = [
    (x, y) => x + y,
    (x, y) => x - y,
    (x, y) => x * y,
    (x, y) => y == 0.0 ? double.NaN : x / y
  ];

  public bool JudgePoint24(int[] cards)
  {
    return GetPermutations(cards).Any(CanGet24);
  }

  private static List<int[]> GetPermutations(int[] values)
  {
    var result = new List<int[]>();
    F(0);
    return result;

    void F(int start)
    {
      if (start == values.Length)
      {
        result.Add(values.ToArray());
        return;
      }
      for (var i = start; i < values.Length; i++)
      {
        (values[start], values[i]) = (values[i], values[start]);
        F(start + 1);
        (values[start], values[i]) = (values[i], values[start]);
      }
    }
  }

  private static bool CanGet24(int[] cards)
  {
    return F(0, cards.Length - 1).Any(x => Math.Abs(x - 24) < 1e-8);

    IEnumerable<double> F(int left, int right)
    {
      if (left == right)
      {
        yield return cards[left];
      }
      else
      {
        for (var i = left; i < right; i++)
        {
          var leftResults = F(left, i).ToHashSet();
          var rightResults = F(i + 1, right).ToHashSet();
          foreach (var op in Operations)
          {
            foreach (var leftRes in leftResults)
            {
              foreach (var rightRes in rightResults)
              {
                var res = op(leftRes, rightRes);
                if (!double.IsNaN(res))
                {
                  yield return res;
                }
              }
            }
          }
        }
      }
    }
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase("[4,1,8,7]", true)]
  [TestCase("[1,2,1,2]", false)]
  [TestCase("[3,3,8,8]", true)]
  public void Test(string cards, bool expected)
  {
    new Solution().JudgePoint24(cards.Array()).Should().Be(expected);
  }
}
