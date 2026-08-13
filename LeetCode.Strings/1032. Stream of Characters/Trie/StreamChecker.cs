namespace LeetCode.Strings._1032._Stream_of_Characters.Trie;

public class StreamChecker
{
    private class Trie
    {
        public bool EndOfWord;
        public readonly Trie[] Next = new Trie[26];
    }

    private readonly Trie trie = new();
    private readonly List<char> stream = [];

    public StreamChecker(string[] words)
    {
        foreach (string w in words)
        {
            Trie t = trie;
            for (int i = w.Length - 1; i >= 0; i--)
            {
                int c = w[i] - 'a';
                Trie next = t.Next[c];
                if (next == null)
                {
                    next = new();
                    t.Next[c] = next;
                }
                t = next;
            }
            t.EndOfWord = true;
        }
    }

    public bool Query(char letter)
    {
        stream.Add(letter);

        Trie t = trie;
        for (int i = stream.Count - 1; i >= 0; i--)
        {
            Trie next = t.Next[stream[i] - 'a'];
            if (next == null)
            {
                break;
            }
            if (next.EndOfWord)
            {
                return true;
            }
            t = next;
        }
        return false;
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
