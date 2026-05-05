using System.IO;

namespace LeetCode.__Binary_Search._2560._House_Robber_IV;

/// <summary>
/// <see href="https://leetcode.com/problems/house-robber-iv/"/>
/// </summary>
public class Solution
{
    public int MinCapability(int[] nums, int k)
    {
        var l = 1;
        var r = nums.Max();
        while (l < r)
        {
            var m = l + (r - l) / 2;
            if (CanRob(m))
                r = m;
            else
                l = m + 1;
        }
        return r;

        bool CanRob(int maxReward)
        {
            var count = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] <= maxReward)
                {
                    count++;
                    i++;
                }
            }
            return count >= k;
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase(new[] { 2, 3, 5, 9 }, 2, 5)]
    [TestCase(new[] { 2, 7, 9, 3, 1 }, 2, 2)]
    [TestCase(new[] { 1, 2, 3, 4, 3, 2, 1 }, 4, 3)]
    [TestCase(new[] { 1, 2, 3, 4, 3, 2, 1, 2, 3 }, 4, 3)]
    [TestCase(new[] { 3 }, 1, 3)]
    [TestCase(new[] { 3, 2 }, 1, 2)]
    public void Test(int[] nums, int k, int expected)
    {
        new Solution().MinCapability(nums, k).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string nums, int k, int expected)
    {
        new Solution().MinCapability(nums.Array(), k).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "# Binary Search", "2560. House Robber IV", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine(),
                int.Parse(sr.ReadLine()),
                int.Parse(sr.ReadLine())
            };
        }
    }
}
