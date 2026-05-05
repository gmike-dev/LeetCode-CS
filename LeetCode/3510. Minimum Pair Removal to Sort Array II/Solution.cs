using System.IO;

namespace LeetCode._3510._Minimum_Pair_Removal_to_Sort_Array_II;

public class Solution
{
    public int MinimumPairRemoval(int[] nums)
    {
        var n = nums.Length;
        Span<long> value = stackalloc long[n];
        Span<int> next = stackalloc int[n];
        Span<int> prev = stackalloc int[n];
        Span<int> versions = stackalloc int[n];
        var queue = new PriorityQueue<(int index, int version), (long sum, int index)>();
        var inversions = 0;
        for (var i = 0; i < n; i++)
        {
            value[i] = nums[i];
            prev[i] = i - 1;
            next[i] = i + 1;
            if (i > 0)
            {
                queue.Enqueue((i - 1, 0), (value[i - 1] + value[i], i - 1));
                if (value[i - 1] > value[i])
                    inversions++;
            }
        }
        var result = 0;
        while (inversions > 0)
        {
            var (node, version) = queue.Dequeue();
            if (versions[node] == -1 || versions[node] != version)
            {
                continue;
            }
            if (value[node] > value[next[node]])
            {
                inversions--;
            }
            if (next[next[node]] != n && value[next[node]] > value[next[next[node]]])
            {
                inversions--;
            }
            if (prev[node] != -1 && value[prev[node]] > value[node])
            {
                inversions--;
            }

            value[node] += value[next[node]];
            versions[next[node]] = -1;
            next[node] = next[next[node]];
            if (next[node] != n)
            {
                prev[next[node]] = node;
            }

            if (next[node] != n)
            {
                versions[node]++;
                queue.Enqueue((node, versions[node]), (value[node] + value[next[node]], node));
            }
            if (prev[node] != -1)
            {
                versions[prev[node]]++;
                queue.Enqueue((prev[node], versions[prev[node]]), (value[prev[node]] + value[node], prev[node]));
            }
            result++;

            if (prev[node] != -1 && value[prev[node]] > value[node])
            {
                inversions++;
            }
            if (next[node] != n && value[node] > value[next[node]])
            {
                inversions++;
            }
        }
        return result;
    }
}

[TestFixture]
public class SolutionTests
{
    [TestCase("[5,2,3,1]", 2)]
    [TestCase("[1,2,2]", 0)]
    [TestCase("[1]", 0)]
    [TestCase("[1, -1]", 1)]
    [TestCase("[2,2,-1,3,-2,2,1,1,1,0,-1]", 9)]
    public void Test(string nums, int expected)
    {
        new Solution().MinimumPairRemoval(nums.Array()).Should().Be(expected);
    }

    [TestCaseSource(nameof(GetTestCases))]
    public void TestLargeInput(string nums, int expected)
    {
        new Solution().MinimumPairRemoval(nums.Array()).Should().Be(expected);
    }

    public static IEnumerable<object> GetTestCases()
    {
        string source = Path.Join(TestContext.CurrentContext.WorkDirectory,
            "3510. Minimum Pair Removal to Sort Array II", "TestCases.txt");
        using var sr = new StreamReader(source);
        while (!sr.EndOfStream)
        {
            yield return new object[]
            {
                sr.ReadLine() ?? throw new InvalidOperationException(),
                int.Parse(sr.ReadLine() ?? throw new InvalidOperationException())
            };
        }
    }
}
