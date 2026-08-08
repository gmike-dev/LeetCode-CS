namespace LeetCode.Strings._1967._Number_of_Strings_That_Appear_as_Substrings_in_Word;

public class AhoCorasickSolution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        AhoCorasick ahoCorasick = new(patterns);
        return ahoCorasick.MatchesCount(word);
    }

    private class AhoCorasick
    {
        private readonly string[] dictionary;
        private readonly Node root = new();

        private class Node
        {
            public readonly Dictionary<char, Node> Next = new();
            public readonly List<int> Words = [];
            public Node Fail;
            public Node Output;
        }

        public AhoCorasick(string[] dictionary)
        {
            this.dictionary = dictionary;
            BuildTrie();
            BuildFailAndOutputLinks();
        }

        private void BuildTrie()
        {
            for (int i = 0; i < dictionary.Length; i++)
            {
                Node node = root;
                foreach (char c in dictionary[i])
                {
                    if (!node.Next.TryGetValue(c, out var next))
                    {
                        next = new Node();
                        node.Next[c] = next;
                    }
                    node = next;
                }
                node.Words.Add(i);
            }
        }

        private void BuildFailAndOutputLinks()
        {
            var queue = new Queue<Node>();

            foreach (var node in root.Next.Values)
            {
                node.Fail = root;
                queue.Enqueue(node);
            }

            while (queue.Count > 0)
            {
                Node current = queue.Dequeue();

                foreach ((char c, var child) in current.Next)
                {
                    Node failNode = current.Fail;
                    while (failNode != null && !failNode.Next.ContainsKey(c))
                    {
                        failNode = failNode.Fail;
                    }
                    child.Fail = failNode != null ? failNode.Next[c] : root;
                    child.Output = child.Fail.Words.Count > 0 ? child.Fail : child.Fail.Output;

                    queue.Enqueue(child);
                }
            }
        }

        public int MatchesCount(string text)
        {
            int count = 0;
            bool[] isMatch = new bool[dictionary.Length];

            var current = root;
            foreach (char c in text)
            {
                while (current != root && !current.Next.ContainsKey(c))
                {
                    current = current.Fail;
                }

                current = current.Next.GetValueOrDefault(c, root);

                for (var outputNode = current; outputNode != null; outputNode = outputNode.Output)
                {
                    foreach (int j in outputNode.Words)
                    {
                        if (!isMatch[j])
                        {
                            count++;
                            isMatch[j] = true;
                        }
                    }
                }
            }
            return count;
        }
    }
}

[TestFixture]
public class AhoCorasickSolutionTests
{
    [TestCase(new[] { "a", "abc", "bc", "d" }, "abc", 3)]
    [TestCase(new[] { "a", "b", "c" }, "aaaaabbbbb", 2)]
    [TestCase(new[] { "a", "a", "a" }, "ab", 3)]
    public void Test(string[] patterns, string word, int expected)
    {
        new AhoCorasickSolution().NumOfStrings(patterns, word).Should().Be(expected);
    }
}
