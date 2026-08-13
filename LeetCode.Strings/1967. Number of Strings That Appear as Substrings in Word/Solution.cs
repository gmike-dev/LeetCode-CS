namespace LeetCode.Strings._1967._Number_of_Strings_That_Appear_as_Substrings_in_Word;

/// <summary>
/// https://leetcode.com/problems/number-of-strings-that-appear-as-substrings-in-word/
/// </summary>
public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        return patterns.Count(word.Contains);
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase(new[] { "a", "abc", "bc", "d" }, "abc", 3)]
    [TestCase(new[] { "a", "b", "c" }, "aaaaabbbbb", 2)]
    [TestCase(new[] { "a", "a", "a" }, "ab", 3)]
    public void Test(string[] patterns, string word, int expected)
    {
        new Solution().NumOfStrings(patterns, word).Should().Be(expected);
    }
}
