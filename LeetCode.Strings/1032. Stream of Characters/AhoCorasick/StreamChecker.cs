namespace LeetCode.Strings._1032._Stream_of_Characters.AhoCorasick;

public class StreamChecker
{
    private class Node
    {
        public readonly Node[] Next = new Node[26];
        public bool IsTerminal;
    }

    private Node state;

    public StreamChecker(string[] words)
    {
        var root = new Node();
        state = root;

        foreach (string p in words)
        {
            Node node = root;
            foreach (char c in p)
            {
                node = node.Next[c - 'a'] ??= new Node();
            }
            node.IsTerminal = true;
        }

        var queue = new Queue<(Node node, Node fail)>();
        for (int i = 0; i < 26; i++)
        {
            if (root.Next[i] != null)
            {
                queue.Enqueue((root.Next[i], root));
            }
            else
            {
                root.Next[i] = root;
            }
        }
        while (queue.Count > 0)
        {
            var (current, fail) = queue.Dequeue();
            if (fail.IsTerminal)
            {
                current.IsTerminal = true;
            }
            for (int i = 0; i < 26; i++)
            {
                var next = current.Next[i];
                if (next != null)
                {
                    queue.Enqueue((next, fail.Next[i]));
                }
                else
                {
                    current.Next[i] = fail.Next[i];
                }
            }
        }
    }

    public bool Query(char letter)
    {
        state = state.Next[letter - 'a'];
        return state.IsTerminal;
    }
}

[TestFixture]
public class StreamCheckerTests
{
    [Test]
    public void Test1()
    {
        var streamChecker = new StreamChecker(["cd", "f", "kl"]);
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('c').Should().BeFalse();
        streamChecker.Query('d').Should().BeTrue();
        streamChecker.Query('e').Should().BeFalse();
        streamChecker.Query('f').Should().BeTrue();
        streamChecker.Query('g').Should().BeFalse();
        streamChecker.Query('h').Should().BeFalse();
        streamChecker.Query('i').Should().BeFalse();
        streamChecker.Query('j').Should().BeFalse();
        streamChecker.Query('k').Should().BeFalse();
        streamChecker.Query('l').Should().BeTrue();
    }

    [Test]
    public void Test2()
    {
        var streamChecker = new StreamChecker(["ab", "ba", "aaab", "abab", "baa"]);
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('b').Should().BeFalse();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('a').Should().BeFalse();
        streamChecker.Query('b').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('a').Should().BeTrue();
        streamChecker.Query('a').Should().BeFalse();
    }
}
