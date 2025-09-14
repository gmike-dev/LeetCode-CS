using LeetCode.Common;

namespace LeetCode.Graphs._1733._Minimum_Number_of_People_to_Teach;

public class Solution
{
  public int MinimumTeachings(int langCount, int[][] languages, int[][] friendships)
  {
    var userLang = languages.Select(l => l.ToHashSet()).ToArray();
    var friends = new HashSet<int>();
    foreach (var friendship in friendships)
    {
      var (u, v) = (friendship[0] - 1, friendship[1] - 1);
      if (!userLang[u].Overlaps(userLang[v]))
      {
        friends.Add(u);
        friends.Add(v);
      }
    }
    var knownLangCount = new int[langCount + 1];
    foreach (var friend in friends)
    {
      foreach (var lang in languages[friend])
        knownLangCount[lang]++;
    }
    return knownLangCount.Min(c => friends.Count - c);
  }
}

[TestFixture]
public class SolutionTests
{
  [TestCase(2, "[[1],[2],[1,2]]", "[[1,2],[1,3],[2,3]]", 1)]
  [TestCase(3, "[[2],[1,3],[1,2],[3]]", "[[1,4],[1,2],[3,4],[2,3]]", 2)]
  [TestCase(11,
    "[[3,11,5,10,1,4,9,7,2,8,6],[5,10,6,4,8,7],[6,11,7,9],[11,10,4],[6,2,8,4,3],[9,2,8,4,6,1,5,7,3,10],[7,5,11,1,3,4],[3,4,11,10,6,2,1,7,5,8,9],[8,6,10,2,3,1,11,5],[5,11,6,4,2]]",
    "[[7,9],[3,7],[3,4],[2,9],[1,8],[5,9],[8,9],[6,9],[3,5],[4,5],[4,9],[3,6],[1,7],[1,3],[2,8],[2,6],[5,7],[4,6],[5,8],[5,6],[2,7],[4,8],[3,8],[6,8],[2,5],[1,4],[1,9],[1,6],[6,7]]",
    0)]
  public void Test(int n, string languages, string friendships, int expected)
  {
    new Solution().MinimumTeachings(n, languages.Array2(), friendships.Array2()).Should().Be(expected);
  }
}
