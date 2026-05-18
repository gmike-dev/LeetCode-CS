namespace LeetCode.__Binary_Search._3934._Smallest_Unique_Subarray;

public class RollingHashSolution2
{
    public int SmallestUniqueSubarray(int[] nums)
    {
        int n = nums.Length;

        // Rolling hash
        const long p = 91138233; // must be > size of dictionary
        long[] prefixHash = new long[n + 1];
        long[] powers = new long[n + 1];
        powers[0] = 1;
        for (int i = 0; i < n; i++)
        {
            powers[i + 1] = powers[i] * p;
        }
        for (int i = 0; i < n; i++)
        {
            prefixHash[i + 1] = prefixHash[i] * p + nums[i];
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
                long h = prefixHash[i + m] - prefixHash[i] * powers[m];
                count[h] = count.GetValueOrDefault(h) + 1;
            }
            foreach (int c in count.Values)
            {
                if (c == 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

[TestFixture]
public class RollingHashSolution2Tests
{
    [TestCase("[3,3,3]", 3)]
    [TestCase("[2,1,2,3,3]", 1)]
    [TestCase("[1,1,2,2,1]", 2)]
    [TestCase("[56,23017,56]", 1)]
    [TestCase("[2,1,32]", 1)]
    public void Test(string nums, int expected)
    {
        new RollingHashSolution2().SmallestUniqueSubarray(nums.Array()).Should().Be(expected);
    }
}
