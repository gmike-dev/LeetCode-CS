namespace LeetCode.Strings._1967._Number_of_Strings_That_Appear_as_Substrings_in_Word;

public class AhoCorasickFastSolution
{
    private class Node
    {
        public readonly Node[] Next = new Node[26];
        public int Count;
        public Node Fail;
        public Node Output;
    }

    public int NumOfStrings(string[] patterns, string word)
    {
        Node root = new();

        foreach (string p in patterns)
        {
            Node node = root;
            foreach (char c in p)
            {
                node = node.Next[c - 'a'] ??= new Node();
            }
            node.Count++;
        }

        var queue = new Queue<Node>();
        foreach (var node in root.Next)
        {
            if (node != null)
            {
                node.Fail = root;
                queue.Enqueue(node);
            }
        }
        while (queue.Count > 0)
        {
            Node current = queue.Dequeue();
            for (int i = 0; i < current.Next.Length; i++)
            {
                var next = current.Next[i];
                if (next != null)
                {
                    Node failNode = current.Fail;
                    while (failNode != null && failNode.Next[i] == null)
                    {
                        failNode = failNode.Fail;
                    }
                    next.Fail = failNode != null ? failNode.Next[i] : root;
                    next.Output = next.Fail.Count > 0 ? next.Fail : next.Fail.Output;

                    queue.Enqueue(next);
                }
            }
        }
        int count = 0;
        var curr = root;
        foreach (char c in word)
        {
            while (curr != root && curr.Next[c - 'a'] == null)
            {
                curr = curr.Fail;
            }

            curr = curr.Next[c - 'a'] ?? root;

            for (var outputNode = curr; outputNode != null; outputNode = outputNode.Output)
            {
                count += outputNode.Count;
                outputNode.Count = 0;
            }
        }
        return count;
    }
}

[TestFixture]
public class AhoCorasickFastSolutionTests
{
    [TestCase(new[] { "a", "abc", "bc", "d" }, "abc", 3)]
    [TestCase(new[] { "a", "b", "c" }, "aaaaabbbbb", 2)]
    [TestCase(new[] { "a", "a", "a" }, "ab", 3)]
    public void Test(string[] patterns, string word, int expected)
    {
        new AhoCorasickFastSolution().NumOfStrings(patterns, word).Should().Be(expected);
    }
}
