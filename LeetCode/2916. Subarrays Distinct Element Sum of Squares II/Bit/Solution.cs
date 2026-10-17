using System.IO;

namespace LeetCode._2916._Subarrays_Distinct_Element_Sum_of_Squares_II.Bit;

public class Solution
{
    public int SumCounts(int[] nums)
    {
        int n = nums.Length;
        int[] last = new int[100001];
        RangeSumBit t = new(n);
        long cur = 0;
        long res = 0;
        const long mod = (long)1e9 + 7;
        for (int i = 0; i < n; i++)
        {
            int j = last[nums[i]];
            long q = t.Query(j, i);
            cur = (cur + q * 2 + i - j + 1) % mod;
            res = (res + cur) % mod;
            t.Add(j, i, 1);
            last[nums[i]] = i + 1;
        }
        return (int)res;
    }

    private class RangeSumBit(int n)
    {
        private readonly long[] tree1 = new long[n + 1];
        private readonly long[] tree2 = new long[n + 1];

        public void Add(int l, int r, int delta)
        {
            Add(l, delta);
            Add(r + 1, -delta);
        }

        public long Query(int l, int r)
        {
            return Query(r) - Query(l - 1);
        }

        private void Add(int i, int delta)
        {
            i += 1;
            long rawIndex = i;
            while (i <= n)
            {
                tree1[i] += delta;
                tree2[i] += rawIndex * delta;
                i += Lso(i);
            }
        }

        private long Query(int i)
        {
            i += 1;
            long rawIndex = i + 1;
            if (i > n)
            {
                i = n;
            }
            long res = 0;
            while (i > 0)
            {
                res += rawIndex * tree1[i] - tree2[i];
                i -= Lso(i);
            }
            return res;
        }

        /// <summary>
        /// Least significant 1-bit.
        /// </summary>
        private static int Lso(int i)
        {
            return i & -i;
        }
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[1,2,1]", 15)]
    [TestCase("[2,2]", 3)]
    public void Test(string nums, int expected)
    {
        new Solution().SumCounts(nums.Array()).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "2916. Subarrays Distinct Element Sum of Squares II", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[] { sr.ReadLine(), int.Parse(sr.ReadLine()!) };
        }
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string nums, int expected)
    {
        new Solution().SumCounts(nums.Array()).Should().Be(expected);
    }
}
