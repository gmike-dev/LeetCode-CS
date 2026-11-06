namespace LeetCode.Strings._4091._Count_Magical_Substring_Pairs_II.V1;

public class Solution
{
    public long CountMagicalPairs(string s)
    {
        int n = s.Length;
        int[][] prefix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            prefix[i] = new int[27];
        }
        int[][] suffix = new int[n][];
        for (int i = 0; i < n; i++)
        {
            suffix[i] = new int[27];
        }
        Dictionary<int, int> d = [];
        d[0] = 0;
        for (int i = 0; i < n; i++)
        {
            int c = (1 << (s[i] - 'a'));
            Dictionary<int, int> nd = [];
            nd[c] = 1;
            foreach ((int k, int v) in d)
            {
                if ((k & c) == 0)
                {
                    nd[k | c] = nd.GetValueOrDefault(k | c) + v;
                }
                else
                {
                    nd[k] = nd.GetValueOrDefault(k) + v;
                }
            }
            foreach ((int k, int v) in nd)
            {
                prefix[i][BitOperations.PopCount((uint)k)] += v;
            }
            d = nd;
        }
        d = [];
        d[0] = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            int c = (1 << (s[i] - 'a'));
            Dictionary<int, int> nd = [];
            nd[c] = 1;
            foreach ((int k, int v) in d)
            {
                if ((k & c) == 0)
                {
                    nd[k | c] = nd.GetValueOrDefault(k | c) + v;
                }
                else
                {
                    nd[k] = nd.GetValueOrDefault(k) + v;
                }
            }
            foreach ((int k, int v) in nd)
            {
                suffix[i][BitOperations.PopCount((uint)k)] += v;
            }
            d = nd;
        }
        long result = 0;
        for (int i = 1; i < n; i++)
        {
            for (int cnt = 0; cnt < 27; cnt++)
            {
                result += (long)prefix[i - 1][cnt] * suffix[i][cnt];
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
