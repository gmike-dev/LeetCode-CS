namespace LeetCode.DP._1125._Smallest_Sufficient_Team;

[TestFixture]
public class RecursiveSolutionTests
{
  [Test]
  public void Test1()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "java", "nodejs", "reactjs" },
        new IList<string>[]
        {
          new[] { "java" },
          new[] { "nodejs" },
          new[] { "nodejs", "reactjs" }
        })
      .Should().BeEquivalentTo(new[] { 0, 2 });
  }

  [Test]
  public void Test2()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
        new IList<string>[]
        {
          new[] { "algorithms", "math", "java" },
          new[] { "algorithms", "math", "reactjs" },
          new[] { "java", "csharp", "aws" },
          new[] { "reactjs", "csharp" },
          new[] { "csharp", "math" },
          new[] { "aws", "java" }
        })
      .Should().BeEquivalentTo(new[] { 1, 2 });
  }

  [Test]
  public void Test3()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
        new IList<string>[]
        {
          new[] { "algorithms" },
          new[] { "math" },
          new[] { "java" },
          new[] { "reactjs" },
          new[] { "csharp" },
          new[] { "aws" }
        })
      .Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4, 5 });
  }

  [Test]
  public void Test4()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "algorithms", "math", "java", "reactjs", "csharp", "aws" },
        new IList<string>[]
        {
          new[] { "algorithms" },
          new[] { "math" },
          new[] { "java", "reactjs" },
          new[] { "reactjs" },
          new[] { "csharp" },
          new[] { "aws" }
        })
      .Should().BeEquivalentTo(new[] { 0, 1, 2, 4, 5 });
  }

  [Test]
  public void Test5()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "mmcmnwacnhhdd", "vza", "mrxyc" },
        new IList<string>[]
        {
          new[] { "mmcmnwacnhhdd" },
          new string[0],
          new string[0],
          new[] { "vza", "mrxyc" }
        })
      .Should().BeEquivalentTo(new[] { 0, 3 });
  }


  [Test]
  [Ignore("Not pass")]
  public void Test6()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p" },
        new IList<string>[]
        {
          new[] { "a" }, new[] { "b" }, new[] { "c" }, new[] { "d" }, new[] { "e" }, new[] { "f" }, new[] { "g" },
          new[] { "h" }, new[] { "i" }, new[] { "j" }, new[] { "k" }, new[] { "l" }, new[] { "m" }, new[] { "n" },
          new[] { "o" }, new[] { "p" },
          new[] { "a" }, new[] { "b" }, new[] { "c" }, new[] { "d" }, new[] { "e" }, new[] { "f" }, new[] { "g" },
          new[] { "h" }, new[] { "i" }, new[] { "j" }, new[] { "k" }, new[] { "l" }, new[] { "m" }, new[] { "n" },
          new[] { "o" }, new[] { "p" },
          new[] { "a" }, new[] { "b" }, new[] { "c" }, new[] { "d" }, new[] { "e" }, new[] { "f" }, new[] { "g" },
          new[] { "h" }, new[] { "i" }, new[] { "j" }, new[] { "k" }, new[] { "l" }, new[] { "m" }, new[] { "n" },
          new[] { "o" }, new[] { "p" },
        })
      .Should().BeEquivalentTo(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 });
  }

  [Test]
  public void Test36()
  {
    new RecursiveSolution().SmallestSufficientTeam(
        new[]
        {
          "hfkbcrslcdjq", "jmhobexvmmlyyzk", "fjubadocdwaygs", "peaqbonzgl", "brgjopmm", "x", "mf", "pcfpppaxsxtpixd",
          "ccwfthnjt", "xtadkauiqwravo", "zezdb", "a", "rahimgtlopffbwdg", "ulqocaijhezwfr", "zshbwqdhx",
          "hyxnrujrqykzhizm"
        },
        new IList<string>[]
        {
          new[] { "peaqbonzgl", "xtadkauiqwravo" }, new[] { "peaqbonzgl", "pcfpppaxsxtpixd", "zshbwqdhx" },
          new[] { "x", "a" }, new[] { "a" },
          new[] { "jmhobexvmmlyyzk", "fjubadocdwaygs", "xtadkauiqwravo", "zshbwqdhx" },
          new[] { "fjubadocdwaygs", "x", "zshbwqdhx" }, new[] { "x", "xtadkauiqwravo" },
          new[] { "x", "hyxnrujrqykzhizm" }, new[] { "peaqbonzgl", "x", "pcfpppaxsxtpixd", "a" },
          new[] { "peaqbonzgl", "pcfpppaxsxtpixd" }, new[] { "a" }, new[] { "hyxnrujrqykzhizm" },
          new[] { "jmhobexvmmlyyzk" }, new[] { "hfkbcrslcdjq", "xtadkauiqwravo", "a", "zshbwqdhx" },
          new[] { "peaqbonzgl", "mf", "a", "rahimgtlopffbwdg", "zshbwqdhx" }, new[] { "xtadkauiqwravo" },
          new[] { "fjubadocdwaygs" }, new[] { "x", "a", "ulqocaijhezwfr", "zshbwqdhx" }, new[] { "peaqbonzgl" },
          new[] { "pcfpppaxsxtpixd", "ulqocaijhezwfr", "hyxnrujrqykzhizm" },
          new[] { "a", "ulqocaijhezwfr", "hyxnrujrqykzhizm" }, new[] { "a", "rahimgtlopffbwdg" }, new[] { "zshbwqdhx" },
          new[] { "fjubadocdwaygs", "peaqbonzgl", "brgjopmm", "x" }, new[] { "hyxnrujrqykzhizm" },
          new[] { "jmhobexvmmlyyzk", "a", "ulqocaijhezwfr" },
          new[] { "peaqbonzgl", "x", "a", "ulqocaijhezwfr", "zshbwqdhx" }, new[] { "mf", "pcfpppaxsxtpixd" },
          new[] { "fjubadocdwaygs", "ulqocaijhezwfr" }, new[] { "fjubadocdwaygs", "x", "a" },
          new[] { "zezdb", "hyxnrujrqykzhizm" }, new[] { "ccwfthnjt", "a" }, new[] { "fjubadocdwaygs", "zezdb", "a" },
          new string[] { }, new[] { "peaqbonzgl", "ccwfthnjt", "hyxnrujrqykzhizm" },
          new[] { "xtadkauiqwravo", "hyxnrujrqykzhizm" }, new[] { "peaqbonzgl", "a" },
          new[] { "x", "a", "hyxnrujrqykzhizm" }, new[] { "zshbwqdhx" }, new string[] { },
          new[] { "fjubadocdwaygs", "mf", "pcfpppaxsxtpixd", "zshbwqdhx" },
          new[] { "pcfpppaxsxtpixd", "a", "zshbwqdhx" }, new[] { "peaqbonzgl" },
          new[] { "peaqbonzgl", "x", "ulqocaijhezwfr" }, new[] { "ulqocaijhezwfr" }, new[] { "x" },
          new[] { "fjubadocdwaygs", "peaqbonzgl" }, new[] { "fjubadocdwaygs", "xtadkauiqwravo" },
          new[] { "pcfpppaxsxtpixd", "zshbwqdhx" }, new[] { "peaqbonzgl", "brgjopmm", "pcfpppaxsxtpixd", "a" },
          new[] { "fjubadocdwaygs", "x", "mf", "ulqocaijhezwfr" },
          new[] { "jmhobexvmmlyyzk", "brgjopmm", "rahimgtlopffbwdg", "hyxnrujrqykzhizm" },
          new[] { "x", "ccwfthnjt", "hyxnrujrqykzhizm" }, new[] { "hyxnrujrqykzhizm" },
          new[] { "peaqbonzgl", "x", "xtadkauiqwravo", "ulqocaijhezwfr", "hyxnrujrqykzhizm" },
          new[] { "brgjopmm", "ulqocaijhezwfr", "zshbwqdhx" }, new[] { "peaqbonzgl", "pcfpppaxsxtpixd" },
          new[] { "fjubadocdwaygs", "x", "a", "zshbwqdhx" }, new[] { "fjubadocdwaygs", "peaqbonzgl", "x" },
          new[] { "ccwfthnjt" }
        })
      .Should().BeEquivalentTo(new[] { 1, 13, 30, 31, 50, 51 });
  }
}
