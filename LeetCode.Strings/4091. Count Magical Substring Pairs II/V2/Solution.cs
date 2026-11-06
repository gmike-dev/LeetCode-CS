namespace LeetCode.Strings._4091._Count_Magical_Substring_Pairs_II.V2;

public class Solution
{
    public long CountMagicalPairs(string s)
    {
        int n = s.Length;
        int[,] prefix = new int[n, 27];
        int[,] suffix = new int[n, 27];
        Span<int> masks = stackalloc int[26];
        Span<int> count = stackalloc int[26];
        Span<int> nextMasks = stackalloc int[26];
        Span<int> nextCount = stackalloc int[26];
        int mc = 0;
        for (int i = 0; i < n; i++)
        {
            int c = (1 << (s[i] - 'a'));
            nextMasks[0] = c;
            nextCount[0] = 1;
            int nc = 1;
            for (int j = 0; j < mc; j++)
            {
                int m = masks[j] | c;
                if (m != nextMasks[nc - 1])
                {
                    nextMasks[nc] = m;
                    nextCount[nc] = count[j];
                    nc++;
                }
                else
                {
                    nextCount[nc - 1] += count[j];
                }
            }
            for (int j = 0; j < nc; j++)
            {
                prefix[i, j + 1] += nextCount[j];
            }
            var t1 = nextMasks;
            nextMasks = masks;
            masks = t1;
            var t2 = nextCount;
            nextCount = count;
            count = t2;
            mc = nc;
        }
        mc = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            int c = (1 << (s[i] - 'a'));
            nextMasks[0] = c;
            nextCount[0] = 1;
            int nc = 1;
            for (int j = 0; j < mc; j++)
            {
                int m = masks[j] | c;
                if (m != nextMasks[nc - 1])
                {
                    nextMasks[nc] = m;
                    nextCount[nc] = count[j];
                    nc++;
                }
                else
                {
                    nextCount[nc - 1] += count[j];
                }
            }
            for (int j = 0; j < nc; j++)
            {
                suffix[i, j + 1] += nextCount[j];
            }
            var t1 = nextMasks;
            nextMasks = masks;
            masks = t1;
            var t2 = nextCount;
            nextCount = count;
            count = t2;
            mc = nc;
        }
        long result = 0;
        for (int i = 1; i < n; i++)
        {
            for (int cnt = 0; cnt < 27; cnt++)
            {
                result += (long)prefix[i - 1, cnt] * suffix[i, cnt];
            }
        }
        return result;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("aba", 2)]
    [TestCase("kkk", 4)]
    [TestCase("abcac", 7)]
    [TestCase("obdda", 8)]
    public void Test(string s, long expected)
    {
        new Solution().CountMagicalPairs(s).Should().Be(expected);
    }
}
