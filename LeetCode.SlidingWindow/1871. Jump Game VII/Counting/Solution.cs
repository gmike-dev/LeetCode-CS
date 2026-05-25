namespace LeetCode.SlidingWindow._1871._Jump_Game_VII.Counting;

/// <summary>
/// https://leetcode.com/problems/jump-game-vii
/// </summary>
public class Solution
{
    public bool CanReach(string s, int minJump, int maxJump)
    {
        int n = s.Length;
        if (s[n - 1] != '0')
        {
            return false;
        }
        Span<bool> reachable = stackalloc bool[n];
        reachable[0] = true;
        int reachableInWindow = 0;
        for (int i = 1; i < n; i++)
        {
            if (i - maxJump - 1 >= 0 && reachable[i - maxJump - 1])
            {
                reachableInWindow--;
            }
            if (i - minJump >= 0 && reachable[i - minJump])
            {
                reachableInWindow++;
            }
            if (s[i] == '0')
            {
                reachable[i] = reachableInWindow > 0;
            }
        }
        return reachableInWindow > 0;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("011010", 2, 3, true)]
    [TestCase("01101110", 2, 3, false)]
    [TestCase("0000000000", 2, 5, true)]
    [TestCase("010101110", 1, 1, false)]
    [TestCase("010101110", 1, 3, false)]
    [TestCase("010101110", 1, 4, true)]
    [TestCase("00111010", 3, 5, false)]
    [TestCase("00111011", 3, 50, false)]
    public void Test(string s, int minJump, int maxJump, bool expected)
    {
        new Solution().CanReach(s, minJump, maxJump).Should().Be(expected);
    }
}
