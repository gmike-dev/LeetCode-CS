namespace LeetCode._920._Number_of_Music_Playlists;

[TestFixture]
public class Tests
{
  [TestCase(3, 3, 1, 6)]
  [TestCase(2, 3, 0, 6)]
  [TestCase(2, 3, 1, 2)]
  [TestCase(16, 19, 5, 64612811)]
  public void Test1(int n, int goal, int k, int expected)
  {
    new Solution().NumMusicPlaylists(n, goal, k).Should().Be(expected);
  }
}
