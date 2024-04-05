namespace LeetCode._2810._Faulty_Keyboard;

[TestFixture]
public class Tests
{
  [TestCase("string", "rtsng")]
  [TestCase("poiinter", "ponter")]
  public void Test(string s, string expected)
  {
    new QuadraticSolution().FinalString(s).Should().Be(expected);
    new DequeSolution().FinalString(s).Should().Be(expected);
    new TwoStringsSolution().FinalString(s).Should().Be(expected);
  }
}
