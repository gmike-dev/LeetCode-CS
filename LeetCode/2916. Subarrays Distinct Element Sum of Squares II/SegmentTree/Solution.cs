using System.IO;

namespace LeetCode._2916._Subarrays_Distinct_Element_Sum_of_Squares_II.SegmentTree;

public class Solution
{
    public int SumCounts(int[] nums)
    {
        int n = nums.Length;
        Span<int> last = new int[100001];
        last.Fill(-1);
        SegmentTree t = new(n);
        long cur = 0;
        long res = 0;
        const long mod = (long)1e9 + 7;
        for (int i = 0; i < n; i++)
        {
            int j = last[nums[i]] + 1;
            long q = t.GetSum(j, i);
            cur = (cur + q * 2 + i - j + 1) % mod;
            res = (res + cur) % mod;
            t.Add(j, i, 1);
            last[nums[i]] = i;
        }
        return (int)res;
    }

    private class SegmentTree(int n)
    {
        private readonly SegmentTreeNode root = new(0, n - 1);

        public void Add(int l, int r, int value)
        {
            root.Add(l, r, value);
        }

        public long GetSum(int l, int r)
        {
            return root.GetSum(l, r);
        }
    }

    private class SegmentTreeNode(int left, int right)
    {
        private long sum;
        private long acc;
        private SegmentTreeNode leftNode;
        private SegmentTreeNode rightNode;

        public void Add(int l, int r, long val)
        {
            if (l > r)
            {
                return;
            }
            if (l == left && r == right)
            {
                Add(val);
                return;
            }
            int m = left + (right - left) / 2;
            leftNode ??= new SegmentTreeNode(left, m);
            rightNode ??= new SegmentTreeNode(m + 1, right);
            PushDown();
            leftNode.Add(l, Math.Min(r, m), val);
            rightNode.Add(Math.Max(l, m + 1), r, val);
            sum = leftNode.sum + rightNode.sum;
        }

        public long GetSum(int l, int r)
        {
            if (l > r)
            {
                return 0;
            }
            if (l == left && r == right)
            {
                return sum;
            }
            int m = left + (right - left) / 2;
            leftNode ??= new SegmentTreeNode(left, m);
            rightNode ??= new SegmentTreeNode(m + 1, right);
            PushDown();
            return leftNode.GetSum(l, Math.Min(r, m)) + rightNode.GetSum(Math.Max(l, m + 1), r);
        }

        private void PushDown()
        {
            if (acc != 0)
            {
                leftNode.Add(acc);
                rightNode.Add(acc);
                acc = 0;
            }
        }

        private void Add(long val)
        {
            sum += val * (right - left + 1);
            acc += val;
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
