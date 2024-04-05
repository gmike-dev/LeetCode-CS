namespace LeetCode._880._Decoded_String_at_Index;

[TestFixture]
public class Tests
{
  [TestCase("leet2code3", 10, "o")]
  [TestCase("ha22", 5, "h")]
  [TestCase("a2345678999999999999999", 1, "a")]
  [TestCase("a2b3c4d5e6f7g8h9", 10, "c")]
  [TestCase("a2b3c4d5e6f7g8h9", 9, "b")]
  [TestCase("a2b3c4d5e6f7g8h9", 8, "a")]
  [TestCase("a2b3c4d5e6f7g8h9", 11, "a")]
  [TestCase("ixm5xmgo78", 711, "x")]
  [TestCase("czjkk9elaqwiz7s6kgvl4gjixan3ky7jfdg3kyop3husw3fm289thisef8blt7a7zr5v5lhxqpntenvxnmlq7l34ay3jaayikjps", 768077956, "c")]
  public void Test(string s, int k, string expected)
  {
    new Solution().DecodeAtIndex(s, k).Should().Be(expected);
  }
}
