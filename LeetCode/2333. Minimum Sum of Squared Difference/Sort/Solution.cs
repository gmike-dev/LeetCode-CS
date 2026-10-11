namespace LeetCode._2333._Minimum_Sum_of_Squared_Difference.Sort;

public class Solution
{
    public long MinSumSquareDiff(int[] nums1, int[] nums2, int k1, int k2)
    {
        int n = nums1.Length;
        Span<int> diffs = stackalloc int[n + 1];
        for (int i = 0; i < n; i++)
        {
            diffs[i] = Math.Abs(nums1[i] - nums2[i]);
        }
        diffs.Sort((x, y) => y - x);
        long k = k1 + k2;
        long x = diffs[0];
        long result = 0;
        for (int i = 1; i <= n; i++)
        {
            long diff = (long)(diffs[i - 1] - diffs[i]) * i;
            if (k >= diff)
            {
                x = diffs[i];
                k -= diff;
            }
            else
            {
                long a = k / i;
                long b = i - k % i;
                x -= a;
                result += x * x * b;
                result += (x - 1) * (x - 1) * (i - b);
                for (int j = i; i < n; i++)
                {
                    result += (long)diffs[i] * diffs[i];
                }
                return result;
            }
        }
        return 0L;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[1,2,3,4]", "[2,10,20,19]", 0, 0, 579)]
    [TestCase("[1,4,10,12]", "[5,8,6,9]", 1, 1, 43)]
    public void Test(string nums1, string nums2, int k1, int k2, long expected)
    {
        new Solution().MinSumSquareDiff(nums1.Array(), nums2.Array(), k1, k2).Should().Be(expected);
    }
}
