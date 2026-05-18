namespace LeetCode.__Binary_Search._3934._Smallest_Unique_Subarray;

public class RollingHashSolution1
{
    public int SmallestUniqueSubarray(int[] nums)
    {
        int n = nums.Length;

        // Rolling hash
        const long p = 91138233; // must be > size of dictionary
        const long mod = (int)1e9 + 9;
        long[] prefixHash = new long[n + 1];
        long[] powers = new long[n + 1];
        powers[0] = 1;
        for (int i = 0; i < n; i++)
        {
            powers[i + 1] = powers[i] * p % mod;
        }
        for (int i = 0; i < n; i++)
        {
            prefixHash[i + 1] = (prefixHash[i] * p + nums[i]) % mod;
        }

        int l = 1;
        int r = n;
        while (l <= r)
        {
            int m = (l + r) / 2;
            if (HasUnique(m))
            {
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }
        return l;

        bool HasUnique(int m)
        {
            Dictionary<long, int> count = new();
            for (int i = n - m; i >= 0; i--)
            {
                long h = GetHash(i, i + m - 1);
                count[h] = count.GetValueOrDefault(h) + 1;
            }
            return count.Values.Any(c => c == 1);
        }

        long GetHash(int l, int r)
        {
            return (prefixHash[r + 1] - prefixHash[l] * powers[r - l + 1] % mod + mod) % mod;
        }
    }
}

[TestFixture]
public class RollingHashSolution1Tests
{
    [TestCase("[3,3,3]", 3)]
    [TestCase("[2,1,2,3,3]", 1)]
    [TestCase("[1,1,2,2,1]", 2)]
    [TestCase("[56,23017,56]", 1)]
    [TestCase("[2,1,32]", 1)]
    public void Test(string nums, int expected)
    {
        new RollingHashSolution1().SmallestUniqueSubarray(nums.Array()).Should().Be(expected);
    }
}
